using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Google.ProtocolBuffers.ProtoGen;

namespace DashFireProtoGen
{
  internal class GenerateRule
  {
    public GenerateRule(string name, List<string> proto_file_paths)
    {
      Name = name;
      proto_file_paths_ = proto_file_paths;
      ValidatePath();
    }

    public string Name { get; private set; }
    public List<string> ProtoFilePaths { get { return proto_file_paths_; } }

    // check timestamp against the timestamp which stored in temporary path
    public bool IsExpired
    {
      get
      {
        UpdateTimeStamp();
        string ts_file = Name + ".protogen.timestamp";
        return File.Exists(ts_file) ? LoadTimeStamp(ts_file) < timestamp_ : true;
      }
    }

    public void StoreTimeStamp()
    {
      string f = Name + ".protogen.timestamp";
      using (FileStream s = File.Open(f, FileMode.OpenOrCreate, FileAccess.Write))
      {
        byte[] bytes = BitConverter.GetBytes(timestamp_.ToBinary());
        s.Write(bytes, 0, bytes.Length);
      }
    }

    private DateTime LoadTimeStamp(string f)
    {
      using (FileStream s = File.Open(f, FileMode.Open, FileAccess.Read))
      {
        byte[] bytes = new byte[s.Length];
        s.Read(bytes, 0, (int)s.Length);
        return DateTime.FromBinary(BitConverter.ToInt64(bytes, 0));
      }
    }

    private void UpdateTimeStamp()
    {
      timestamp_ = new DateTime();
      foreach (string p in proto_file_paths_)
      {
        DateTime ts = File.GetLastWriteTime(p);
        if (ts > timestamp_)
          timestamp_ = ts;
      }
    }

    private void ValidatePath()
    {
      foreach (string p in proto_file_paths_)
      {
        // TODO: exception
        if (!File.Exists(p))
          throw new Exception(p + " is not exist.");
      }
    }

    private List<string> proto_file_paths_;
    private DateTime timestamp_;
  }
}