using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DashFireSpatial;
using ScriptRuntime;
using DashFire;

namespace WindowsFormsApplication1
{
  public enum FunctionType
  {
    kMoveObj = 0,
    kGetCell,
    kSetStaticBlock,
    kHitPoint,
    kRayCast,
  };

  public enum KeyHit
  {
    W = 1,
    A = 2,
    S = 4,
    D = 8,
  }

  public partial class Form1 : Form
  {
    private Pen line_pen = new Pen(Color.Red, 1.0f);
    private Pen path_pen = new Pen(Color.Yellow, 1.0f);
    private Pen obj_pen = new Pen(Color.Blue, 1.0f);
    private Pen point_pen = new Pen(Color.Gold, 1.0f);
    private Pen[] level_pen_floor = new Pen[] { new Pen(Color.FromArgb(0x88,0x33,0x33,0), 0.01f), 
      new Pen(Color.FromArgb(0x88,0x66,0x66,0), 0.01f), 
      new Pen(Color.FromArgb(0x88,0x99,0x99,0), 0.01f), 
      new Pen(Color.FromArgb(0x88,0xcc,0xcc,0), 0.01f), 
      new Pen(Color.FromArgb(0x88,0xff,0xff,0), 0.01f)
    };
    private Pen[] level_pen_underfloor = new Pen[] { new Pen(Color.FromArgb(0x88,0,0,0x80), 0.01f), 
      new Pen(Color.FromArgb(0x88,0,0,0xff), 0.01f)
    };

    private Pen pen = new Pen(Color.FromArgb(100, Color.Red), 1.0f);
    private Pen shotproof_pen = new Pen(Color.FromArgb(100, Color.OrangeRed), 1.0f);
    private Pen roadblock_pen = new Pen(Color.FromArgb(200, Color.Green), 1.0f);
    private Pen energywall_pen = new Pen(Color.FromArgb(100, Color.Cyan), 1.0f);
    private Pen grid_pen = new Pen(Color.FromArgb(100, Color.White), 1.0f);
    private Pen blinding_pen = new Pen(Color.FromArgb(255, Color.Gray), 1.0f);
    private Pen fov_pen = new Pen(Color.FromArgb(32, Color.LightBlue), 1.0f);

    private SolidBrush brush = new SolidBrush(Color.FromArgb(32, Color.Red));
    private SolidBrush shotproof_brush = new SolidBrush(Color.FromArgb(32, Color.OrangeRed));
    private SolidBrush roadblock_brush = new SolidBrush(Color.FromArgb(32, Color.Green));
    private SolidBrush energywall_brush = new SolidBrush(Color.FromArgb(32, Color.Cyan));
    private SolidBrush blinding_brush = new SolidBrush(Color.FromArgb(255, Color.Gray));
    private SolidBrush fov_brush = new SolidBrush(Color.FromArgb(16, Color.LightBlue));
    private SolidBrush point_brush = new SolidBrush(Color.Black);
    private Timer mFormsTimer;
    private BufferedGraphicsContext context_;
    private BufferedGraphics graphics_;
    private BufferedGraphics obstacle_graphics_;
    private Image back_image_;

    private string map_file_ = "D:/webjet/Public/Resource/Public/Scenes/Scene_1/Scene1.map";
    private string obstacle_file_ = "D:/webjet/Public/Resource/Public/Scenes/Scene_1/Scene1.tmx";
    private string map_patch_file_ = "D:/webjet/Public/Resource/Public/Scenes/Scene_1/Scene1.map.patch";
    private string map_image_ = "D:/webjet/Public/Resource/Public/Scenes/Scene_1/Scene1.jpg";
    private float map_actual_width_ = 256;
    private float map_actual_height_;
    private float cell_actual_width_ = 0.5f;
    private float map_width_;
    private float map_height_;
    private float scale;
    private float cell_width_;
    private Point line_start_;
    private Point line_end_;
    private MapParser map_parser_ = null;
    private MapPatchParser map_patch_parser_ = null;
    private CellManager cell_manager_ = null;
    private SpatialSystem spatial_system_ = null;
    private ICellMapView cell_map_view_ = null;
    private PrecisePermissive precise_permissive_ = null;
    private ShadowFov shadow_fov_ = null;
    private SpatialBoard spatial_board_ = null;
    private TestSpaceObject control_obj_ = new TestSpaceObject(1);
    private Collide collide_detector_ = new Collide();
    private List<CellPos> hit_points_ = new List<CellPos>();
    private List<Vector3> found_path_ = null;
    private FunctionType left_button_function_ = FunctionType.kMoveObj;
    private bool is_mouse_down_;
    private long last_tick_time_;

    private KeyHit key_hit_;
    private double last_movedir_;
    private int last_adjust_;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      mFormsTimer = new System.Windows.Forms.Timer();
      mFormsTimer.Interval = 50;
      mFormsTimer.Tick += new System.EventHandler(this.TimerEventProcessor);
      mFormsTimer.Start();

      context_ = BufferedGraphicsManager.Current;
      last_tick_time_ = TimeUtility.GetElapsedTimeUs() / 1000;
      last_movedir_ = 0;
      last_adjust_ = 0;

      operation.SelectedIndex = 0;

      LogSystem.OnOutput += (Log_Type type, string msg) => {
        Console.WriteLine("Log {0}:{1}", type, msg);
      };
    }
    
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (!IsValid())
        return;
      switch (e.KeyCode) {
        case Keys.A:
          key_hit_ |= KeyHit.A;
          break;
        case Keys.S:
          key_hit_ |= KeyHit.S;
          break;
        case Keys.D:
          key_hit_ |= KeyHit.D;
          break;
        case Keys.W:
          key_hit_ |= KeyHit.W;
          break;
      }
    }

    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
      if (!IsValid())
        return;
      switch (e.KeyCode) {
        case Keys.A:
          key_hit_ &= (~KeyHit.A);
          break;
        case Keys.S:
          key_hit_ &= (~KeyHit.S);
          break;
        case Keys.D:
          key_hit_ &= (~KeyHit.D);
          break;
        case Keys.W:
          key_hit_ &= (~KeyHit.W);
          break;
      }
    }
    
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
      if (!IsValid())
        return;
      line_end_ = new Point(e.X, e.Y);
      CellPos end;
      cell_manager_.GetCell(new Vector3(e.X, 0, map_height_ - e.Y), out end.row, out end.col);
      CellPos start;
      cell_manager_.GetCell(new Vector3(line_start_.X, 0, map_height_ - line_start_.Y), out start.row, out start.col);

      if (e.Button == MouseButtons.Left) {
        switch (left_button_function_) {
          case FunctionType.kSetStaticBlock:
            {
              int row = end.row;
              int col = end.col;
              byte obstacle = byte.Parse(obstacleType.Text);
              byte oldObstacle = cell_manager_.GetCellStatus(row, col);
              cell_manager_.SetCellStatus(row, col, obstacle);

              if (map_patch_parser_.Exist(row, col)) {
                map_patch_parser_.Update(row, col, obstacle);
              } else {
                map_patch_parser_.Update(row, col, obstacle, oldObstacle);
              }

              UpdateObstacleGraph();
            }
            break;
          case FunctionType.kHitPoint: {
            List<CellPos> result = cell_manager_.GetCellsCrossByLine(new Vector3(line_start_.X, 0, map_height_ - line_start_.Y),
                                                         new Vector3(line_end_.X, 0, map_height_ - line_end_.Y));

              DashFireSpatial.Line line = new DashFireSpatial.Line(new Vector3(line_start_.X, 0, line_start_.Y), new Vector3(e.X, 0, e.Y));
              hit_points_.Clear();
              foreach (CellPos pos in result) {
                hit_points_.Add(pos);
              }
            }
            break;
          case FunctionType.kRayCast: {
              Vector3 hitpoint;
              if (spatial_system_.RayCastForShoot(new Vector3(line_start_.X, 0, map_height_ - line_start_.Y), new Vector3(line_end_.X, 0, map_height_ - line_end_.Y), out hitpoint)) {
                int row, col;
                cell_manager_.GetCell(hitpoint, out row, out col);
                hit_points_.Clear();
                hit_points_.Add(new CellPos(row,col));
              }
            }
            break;
          case FunctionType.kGetCell: {
              byte obstacle = cell_manager_.GetCellStatus(end.row, end.col);
              obstacleType.Text = obstacle.ToString();
              this.Text = "pos(" + e.X + "," + e.Y + ") cell(" + end.row + "," + end.col + ") obstacle:" + obstacle;
            }
            break;
        }
      } else {
        if (e.Button == MouseButtons.Right && left_button_function_ == FunctionType.kSetStaticBlock) {
          int row, col;
          cell_manager_.GetCell(new Vector3(e.X, 0, e.Y), out row, out col);
          byte oldObstacle = cell_manager_.GetCellStatus(row, col);
          byte obstacle = BlockType.NOT_BLOCK | BlockType.BLINDING_NOTHING | BlockType.LEVEL_GROUND;
          cell_manager_.SetCellStatus(end.row, end.col, obstacle);
          
          if (map_patch_parser_.Exist(row, col)) {
            map_patch_parser_.Update(row, col, obstacle);
          } else {
            map_patch_parser_.Update(row, col, obstacle, oldObstacle);
          }

          UpdateObstacleGraph();
        } else {
          long stTime = TimeUtility.GetElapsedTimeUs();
          found_path_ = spatial_system_.FindPath(new Vector3(line_start_.X, 0, map_height_ - line_start_.Y), new Vector3(line_end_.X, 0, map_height_ - line_end_.Y), 1);
          long edTime = TimeUtility.GetElapsedTimeUs();
          this.Text = "findpath:" + new Vector2(line_start_.X, map_height_ - line_start_.Y).ToString() + " to " + new Vector2(line_end_.X, map_height_ - line_end_.Y).ToString() + " consume " + (edTime - stTime) / 1000.0f + "ms";
        }
      }
      is_mouse_down_ = false;
      key_hit_ = 0;
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (!IsValid())
        return;
      line_start_ = new Point(e.X, e.Y);
      is_mouse_down_ = true;
      key_hit_ = 0;
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
      if (!IsValid())
        return;
      if (is_mouse_down_) {
        switch (left_button_function_) {
          case FunctionType.kMoveObj:
            Vector3 new_pos = new Vector3(e.X, 0, map_height_ - e.Y);
            control_obj_.SetPosition(new_pos);
            control_obj_.GetCollideShape().Transform(control_obj_.GetPosition(), control_obj_.CosDir, control_obj_.SinDir);
            UpdateFov(new_pos);
            break;
        }
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      openFileDialog1.InitialDirectory = @"D:/webjet/Public/Resource/Public/Scenes";
      DialogResult dr = openFileDialog1.ShowDialog();
      if (dr == DialogResult.OK) {
        imageFile.Text = openFileDialog1.FileName;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      map_image_ = imageFile.Text;
      string path = Path.GetDirectoryName(map_image_);
      string fileName = Path.GetFileNameWithoutExtension(map_image_);
      obstacle_file_ = Path.Combine(path, fileName + ".tmx");
      map_file_ = Path.Combine(path, fileName + ".map");
      map_patch_file_ = map_file_ + ".patch";
      map_actual_width_ = float.Parse(mapWidth.Text);

      Reset();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      map_patch_parser_.Save(map_patch_file_);
    }

    private void operation_SelectedIndexChanged(object sender, EventArgs e)
    {
      hit_points_.Clear();
      left_button_function_ = (FunctionType)operation.SelectedIndex;
    }

    private void Tick(long deltaTime)
    {
      bool isMoving = true;
      double dir = 0;
      switch (key_hit_) {
        case KeyHit.W:
          dir = Math.PI;
          break;
        case KeyHit.A:
          dir = Math.PI*3/2;
          break;
        case KeyHit.S:
          dir = 0;
          break;
        case KeyHit.D:
          dir = Math.PI / 2;
          break;
        case KeyHit.W | KeyHit.A:
          dir = Math.PI * 5 / 4;
          break;
        case KeyHit.W | KeyHit.D:
          dir = Math.PI * 3 / 4;
          break;
        case KeyHit.S | KeyHit.A:
          dir = Math.PI * 7 / 4;
          break;
        case KeyHit.S | KeyHit.D:
          dir = Math.PI / 4;
          break;
        default:
          isMoving = false;
          break;
      }
      if (isMoving) {
        if (!Geometry.IsSameDouble(dir, last_movedir_)) {
          last_adjust_ = 0;
        }
        DoMove(dir, deltaTime);
        last_movedir_ = dir;
      } else {
        last_adjust_ = 0;
      }
    }

    private void DoMove(double dir,long deltaTime)
    {
      double PI_1 = Math.PI;
      double PI_2 = 2 * Math.PI;
      double forecastDistance = 0.75 * cell_width_ / 0.5;
      double speed = 5.0 * cell_width_ / 0.5;
      Vector3 old_pos = control_obj_.GetPosition();
      Vector3 new_pos = new Vector3();
      double distance = (speed * deltaTime) / 1000;

      for (int ct=0; ct<8; ++ct) {
        double cosV = Math.Cos(dir);
        double sinV = Math.Sin(dir);
        double y = old_pos.Z + distance * cosV;
        double x = old_pos.X + distance * sinV;
        double checkY, checkX;
        if (distance < forecastDistance) {
          checkY = old_pos.Z + forecastDistance * cosV;
          checkX = old_pos.X + forecastDistance * sinV;
        } else {
          checkY = y;
          checkX = x;
        }

        new_pos = new Vector3((float)x, 0, (float)y);
        Vector3 check_pos = new Vector3((float)checkX, 0, (float)checkY);
        if (spatial_system_.CanPass(control_obj_, check_pos)) {
          //正常移动
          control_obj_.SetPosition(new_pos);
          control_obj_.GetCollideShape().Transform(control_obj_.GetPosition(), control_obj_.CosDir, control_obj_.SinDir);
          UpdateFov(new_pos);
          break;
        } else {
          //自动调节方向
          double newDir = (dir + PI_1 / 4) % PI_2;
          if (last_adjust_>=0 && CanGo(old_pos.X, old_pos.Z, newDir, forecastDistance)) {
            LogSystem.Debug("adjust dir:{0}->{1} success, last adjust:{2}", dir, newDir, last_adjust_);
            dir = newDir;
            last_adjust_ = 1;
          } else {
            LogSystem.Debug("adjust dir:{0}->{1} failed, last adjust:{2}", dir, newDir, last_adjust_);
            newDir = (dir + PI_2 - PI_1 / 4) % PI_2;
            if (last_adjust_ <= 0 && CanGo(old_pos.X, old_pos.Z, newDir, forecastDistance)) {
              LogSystem.Debug("adjust dir:{0}->{1} success, last adjust:{2}", dir, newDir, last_adjust_);
              dir = newDir;
              last_adjust_ = -1;
            } else {
              LogSystem.Debug("adjust dir:{0}->{1} failed, last adjust:{2}", dir, newDir, last_adjust_);
              newDir = (dir + PI_1 / 2) % PI_2;
              if (last_adjust_ >= 0 && CanGo(old_pos.X, old_pos.Z, newDir, forecastDistance)) {
                LogSystem.Debug("adjust dir:{0}->{1} success, last adjust:{2}", dir, newDir, last_adjust_);
                dir = newDir;
                last_adjust_ = 1;
              } else {
                LogSystem.Debug("adjust dir:{0}->{1} failed, last adjust:{2}", dir, newDir, last_adjust_);
                newDir = (dir + PI_2 - PI_1 / 2) % PI_2;
                if (last_adjust_ <= 0 && CanGo(old_pos.X, old_pos.Z, newDir, forecastDistance)) {
                  LogSystem.Debug("adjust dir:{0}->{1} success, last adjust:{2}", dir, newDir, last_adjust_);
                  dir = newDir;
                  last_adjust_ = -1;
                } else {
                  LogSystem.Debug("adjust dir:{0}->{1} failed, last adjust:{2}", dir, newDir, last_adjust_);
                  break;
                }
              }
            }
          }
        }
      }
    }

    private bool CanGo(float x, float y, double dir, double forecastDistance)
    {
      double cosV = Math.Cos(dir);
      double sinV = Math.Sin(dir);
      float tryY = (float)(y + forecastDistance * cosV);
      float tryX = (float)(x + forecastDistance * sinV);
      Vector3 spos = new Vector3(x, 0, y);
      Vector3 dpos = new Vector3(tryX, 0, tryY);
      bool ret = spatial_system_.CanPass(spos, dpos); 
      int srow, scol, drow, dcol;
      cell_manager_.GetCell(spos, out srow, out scol);
      cell_manager_.GetCell(dpos, out drow, out dcol);
      if (ret) {
        LogSystem.Debug("CanGo return true, ({0},{1})->({2},{3})", srow, scol, drow, dcol);
      } else {
        LogSystem.Debug("CanGo return false, ({0},{1})->({2},{3})", srow, scol, drow, dcol);
      }
      return ret;
    }

    private void UpdateFov(Vector3 pos)
    {
      long st = TimeUtility.GetElapsedTimeUs();
      int row = 0;
      int col = 0;
      cell_map_view_.GetCell(pos, out row, out col);
      spatial_board_.ResetVisited(col, row, 20);
      //precise_permissive_.VisitFieldOfView(col, row, 20);
      shadow_fov_.CalculateFOV(col, row, 20);
      long ed = TimeUtility.GetElapsedTimeUs();
      this.Text = "Fov Time (ms):" + (ed - st) / 1000.0f + " RepeatCountForVisit:" + spatial_board_.RepeatCountForVisit + "/" + spatial_board_.TotalCountForVisit;
    }

    private void Reset()
    {
      map_parser_ = new MapParser();
      map_patch_parser_ = new MapPatchParser();
      spatial_system_ = new SpatialSystem();
      cell_manager_ = new CellManager();

      back_image_ = Image.FromFile(map_image_);
      pictureBox1.Image = back_image_;
      pictureBox1.Size = back_image_.Size;
      map_width_ = back_image_.Width;
      map_height_ = back_image_.Height;

      context_.MaximumBuffer = new Size((int)map_width_, (int)map_height_);
      Graphics targetDC = this.pictureBox1.CreateGraphics();
      graphics_ = context_.Allocate(targetDC, new Rectangle(0, 0, (int)map_width_, (int)map_height_));
      obstacle_graphics_ = context_.Allocate(targetDC, new Rectangle(0, 0, (int)map_width_, (int)map_height_));

      scale = map_width_ / map_actual_width_;
      cell_width_ = cell_actual_width_ * scale;
      if (cell_width_ < 1)
        cell_width_ = 1;
      map_actual_height_ = map_height_ * map_actual_width_ / map_width_;

      ///*
      cell_manager_.Init(map_actual_width_, map_actual_height_, cell_actual_width_);
      cell_manager_.Scale(map_width_ / map_actual_width_);            
      map_parser_.ParseTiledData(obstacle_file_, map_width_, map_height_);
      map_parser_.GenerateObstacleInfo(cell_manager_);
      cell_manager_.Scale(map_actual_width_ / map_width_);
      cell_manager_.Save(map_file_);
      //*/

      spatial_system_.Init(map_file_, null);
      cell_manager_ = spatial_system_.GetCellManager();
      cell_manager_.Scale(scale);

      map_patch_parser_.Load(map_patch_file_);
      map_patch_parser_.VisitPatches((int row, int col, byte obstacle) => {
        cell_manager_.SetCellStatus(row, col, obstacle);
        LogSystem.Debug("map patch:{0},{1}->{2}", row, col, obstacle);
      });

      control_obj_.SetPosition(new Vector3(0, 0, 0));
      spatial_system_.AddObj(control_obj_);

      cell_map_view_ = new CellMapViewWithMapData(cell_manager_, 2);
      spatial_board_ = new SpatialBoard(cell_map_view_);
      precise_permissive_ = new PrecisePermissive(spatial_board_);
      shadow_fov_ = new ShadowFov(spatial_board_);

      UpdateObstacleGraph();
      hit_points_.Clear();
    }

    private void UpdateObstacleGraph()
    {
      //绘制静态阻挡
      obstacle_graphics_.Graphics.Clear(Color.Black);
      obstacle_graphics_.Graphics.DrawImage(back_image_, 0, 0, map_width_, map_height_);
      DrawBlockSquare();
    }
    
    private void DrawBlockSquare()
    {
      for (int row = 0; row < cell_manager_.GetMaxRow(); ++row) {
        for (int col = 0; col < cell_manager_.GetMaxCol(); ++col) {
          Vector3 pos = cell_manager_.GetCellCenter(row, col);
          byte status = cell_manager_.GetCellStatus(row, col);
          byte block = BlockType.GetBlockType(status);
          byte subtype = BlockType.GetBlockSubType(status);
          byte blinding = BlockType.GetBlockBlinding(status);
          byte level = BlockType.GetBlockLevel(status);
          DrawSquare((int)pos.X, (int)(map_height_ - pos.Z), (int)cell_width_, block, subtype, blinding, level);
        }
      }
    }

    private void DrawSquare(int x, int y, int width, byte block, byte subtype, byte blinding, byte level)
    {
      if (block != BlockType.NOT_BLOCK) {
        switch (subtype) {
          case BlockType.SUBTYPE_OBSTACLE:
            obstacle_graphics_.Graphics.FillRectangle(brush, x - width / 2, y - width / 2, width, width);
            break;
          case BlockType.SUBTYPE_ROADBLOCK:
            obstacle_graphics_.Graphics.FillRectangle(roadblock_brush, x - width / 2, y - width / 2, width, width);
            break;
          case BlockType.SUBTYPE_SHOTPROOF:
            obstacle_graphics_.Graphics.FillRectangle(shotproof_brush, x - width / 2, y - width / 2, width, width);
            break;
          case BlockType.SUBTYPE_ENERGYWALL:
            obstacle_graphics_.Graphics.FillRectangle(energywall_brush, x - width / 2, y - width / 2, width, width);
            break;
        }
      }
      if (BlockType.BLINDING_BLINDING == blinding) {
        obstacle_graphics_.Graphics.FillRectangle(blinding_brush, x - width / 2, y - width / 2, width, width);
      }
      if (level != BlockType.LEVEL_GROUND) {
        DrawSquareLevel(x, y, width, level);
      }
      if (block != BlockType.NOT_BLOCK) {
        switch (subtype) {
          case BlockType.SUBTYPE_OBSTACLE:
            obstacle_graphics_.Graphics.DrawRectangle(pen, x - width / 2, y - width / 2, width, width);
            break;
          case BlockType.SUBTYPE_ROADBLOCK:
            obstacle_graphics_.Graphics.DrawRectangle(roadblock_pen, x - width / 2, y - width / 2, width, width);
            break;
          case BlockType.SUBTYPE_SHOTPROOF:
            obstacle_graphics_.Graphics.DrawRectangle(shotproof_pen, x - width / 2, y - width / 2, width, width);
            break;
          case BlockType.SUBTYPE_ENERGYWALL:
            obstacle_graphics_.Graphics.DrawRectangle(energywall_pen, x - width / 2, y - width / 2, width, width);
            break;
          default:
            obstacle_graphics_.Graphics.DrawRectangle(grid_pen, x - width / 2, y - width / 2, width, width);
            break;
        }
      }
    }

    private void DrawSquareLevel(int x, int y, int width, byte level)
    {
      switch (level) {
        case BlockType.LEVEL_FLOOR_1:
          obstacle_graphics_.Graphics.DrawRectangle(level_pen_floor[0], x - width / 2, y - width / 2, width, width);
          break;
        case BlockType.LEVEL_FLOOR_2:
          obstacle_graphics_.Graphics.DrawRectangle(level_pen_floor[1], x - width / 2, y - width / 2, width, width);
          break;
        case BlockType.LEVEL_FLOOR_3:
          obstacle_graphics_.Graphics.DrawRectangle(level_pen_floor[2], x - width / 2, y - width / 2, width, width);
          break;
        case BlockType.LEVEL_FLOOR_4:
          obstacle_graphics_.Graphics.DrawRectangle(level_pen_floor[3], x - width / 2, y - width / 2, width, width);
          break;
        case BlockType.LEVEL_FLOOR_BLINDAGE:
          obstacle_graphics_.Graphics.DrawRectangle(level_pen_floor[4], x - width / 2, y - width / 2, width, width);
          break;
        case BlockType.LEVEL_UNDERFLOOR_1:
          obstacle_graphics_.Graphics.DrawRectangle(level_pen_underfloor[0], x - width / 2, y - width / 2, width, width);
          break;
        case BlockType.LEVEL_UNDERFLOOR_2:
          obstacle_graphics_.Graphics.DrawRectangle(level_pen_underfloor[1], x - width / 2, y - width / 2, width, width);
          break;
      }
    }

    private void DrawLine()
    {
      if (!is_mouse_down_) {
        graphics_.Graphics.DrawLine(line_pen, line_start_, line_end_);
      }
    }

    private void DrawFovBlockSquare()
    {
      for (int row = 0; row < cell_manager_.GetMaxRow(); ++row) {
        for (int col = 0; col < cell_manager_.GetMaxCol(); ++col) {
          Vector3 pos = cell_manager_.GetCellCenter(row, col);
          int col_ = 0;
          int row_ = 0;
          cell_map_view_.GetCell(pos, out row_, out col_);
          if (spatial_board_.IsVisited(col_, row_)) {
            DrawSquareFov((int)pos.X, (int)(map_height_ - pos.Z), (int)cell_width_);
          }
        }
      }
    }

    private void DrawSquareFov(int x, int y, int width)
    {
      graphics_.Graphics.FillRectangle(fov_brush, x - width / 2, y - width / 2, width, width);
      graphics_.Graphics.DrawRectangle(fov_pen, x - width / 2, y - width / 2, width, width);
    }

    private void DrawPath()
    {
      if (null != found_path_ && found_path_.Count>=2) {
        bool isFirst = true;
        Point one=new Point(),two=new Point();
        foreach(Vector3 pos in found_path_){
          Point pt = new Point((int)pos.X, (int)(map_height_ - pos.Z));
          if (isFirst) {
            one = pt;
            isFirst = false;
          } else {
            two = pt;
            graphics_.Graphics.DrawLine(path_pen, one, two);
            one = two;
          }
        }
      }
    }

    private void DrawHitPoints()
    {
      foreach (CellPos p in hit_points_) {
        Vector3 pos = Transform(cell_manager_.GetCellCenter(p.row, p.col));
        graphics_.Graphics.FillRectangle(point_brush, pos.X - cell_width_ / 2, pos.Z - cell_width_ / 2, cell_width_, cell_width_);
        graphics_.Graphics.DrawRectangle(point_pen, pos.X - cell_width_ / 2, pos.Z - cell_width_ / 2, cell_width_, cell_width_);
      }
    }

    private bool IsValid()
    {
      bool ret = true;
      if (null == graphics_ ||
        null == back_image_ ||
        null == map_parser_ ||
        null == cell_manager_ ||
        null == spatial_system_)
        ret = false;
      return ret;
    }

    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
    {
      long curTime = TimeUtility.GetElapsedTimeUs() / 1000;
      long deltaTime = curTime - last_tick_time_;
      last_tick_time_ = curTime;
      if (null != graphics_ && null != back_image_) {
        Tick(deltaTime);

        graphics_.Graphics.Clear(Color.White);
        obstacle_graphics_.Render(graphics_.Graphics);
        DrawHitPoints();
        DrawLine();
        DrawPath();
        DrawFovBlockSquare();
        Vector3 pos = Transform(control_obj_.GetPosition());
        graphics_.Graphics.DrawEllipse(obj_pen, pos.X - cell_width_, pos.Z - cell_width_, cell_width_ * 2, cell_width_ * 2);
        graphics_.Render();
      }
    }

    private Vector3 Transform(Vector3 pos)
    {
      return new Vector3(pos.X, pos.Y, map_height_ - pos.Z);
    }
  }
}
