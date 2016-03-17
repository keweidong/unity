//��Ͷ�����ȶ�ˮ��
skill(310301)
{
  section(2533)
  {
    movecontrol(true);
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 3000, vector3(0,0.2,6));
    animation("Attack_01");
    startcurvemove(1760, true, 0.1, 0, 0, 2, 0, 0, 0);
    setchildvisible(1760,"5_Mon_BombMiner_01_w_01",false);
    summonnpc(1740, 101, "Monster/Campaign_Dungeon/03_Miner/5_Mon_BombMiner_01_w_01", 310302, vector3(0, 0, 0));
    setchildvisible(2500,"5_Mon_BombMiner_01_w_01",true);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setchildvisible(2500,"5_Mon_BombMiner_01_w_01",true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setchildvisible(2500,"5_Mon_BombMiner_01_w_01",true);
  };
};


//Ͷ��ˮ��
skill(310302)
{
  section(6000)
  {
    movecontrol(true);
    setenable(0, "Visible", true);
    rotate(10, 2500, vector3(40, 0, 0));
    settransform(0," ",vector3(0,1.5,0),eular(0,0,0),"RelativeOwner",false);
    startcurvemove(10, true, 3,0,5,4.5,0,-9,0);
    colliderdamage(10, 3000, false, false, 0, 0)
    {
      stateimpact("kDefault", 31030101);
      oncollidelayer("Terrains", "onterrain");
      oncollidelayer("Default", "onterrain");
      boneboxcollider(vector3(0.8, 0.8, 0.8), "Bone001", vector3(0, 0, 0), eular(0, 0, 0), true, false);
    };
    destroyself(6000);
  };
  onmessage("onterrain")
  {
    cleardamagepool(0);//���֮ǰ����˺��ļ�¼
    playsound(0, "baozha", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_touzhixiao_01", false);
    setenable(0, "CurveMove", false);
    setenable(0, "Rotate", false);
    setenable(0, "Visible", false);
//��ը�˺�
    areadamage(10, 0, 0.5, 0, 3, false) {
      stateimpact("kDefault", 31030102);
    };
    sceneeffect("Monster_FX/Campaign_Wild/03_KDArmy/6_Mon_KDM_BaoZha_01", 2000, vector3(0,0,0));
  };
};


//������
skill(310303)
{
  section(2433)
  {
    movecontrol(true);
    animation("Attack_01");
    charactereffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_DaoGuang_02", 2000, "Bone_Root", 1070) {
      transform(vector3(0,0.5,-0.1));
    };
    findmovetarget(1533, vector3(0,0,0),3,50,0.5,0.5,0,-2);
    startcurvemove(1566, true, 0.07, 0, 0, 4, 0, 0, 100);
    areadamage(1667, 0, 1, 0.5, 2, true) {
      stateimpact("kDefault", 31030301);
    };
    //sound("Sound/Swordman/TiaoKong", 0);//�޶�֡ʱ����Ч��ʼʱ��
    shakecamera2(1670, 250, true, true, vector3(0,0.15,0.2), vector3(0,150,150),vector3(0,0.5,0.5),vector3(0,40,60));
  };
};

//�󹤻ӿ�
skill(310304)
{
  section(2267)
  {
    animation("Skill_01");
    charactereffect("Monster_FX/Campaign_Dungeon/03_Miner/6_Mon_HoeMiner_DaoGuang_01", 2000, "Bone_Root", 1510);
    //sound("Sound/Swordman/TiaoKong", 1500);//�޶�֡ʱ����Ч��ʼʱ��
    areadamage(1533, 0, 1, 1, 2.5, false) {
      stateimpact("kDefault", 31030401);
    };
//    lockframe(720, "Bluelf03_Attack_01", true, 0, 100, 1, 100);
//    shakecamera(740, true, 40, 20, 100, 0.5);
    shakecamera2(1540, 200, true, true, vector3(0,0,0.1), vector3(0,0,50),vector3(0,0,1),vector3(0,0,50));
  };
};


//���Ա�
skill(310305)
{
  section(3000)
  {
    movecontrol(true);
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(0,0.2,1.5));
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(0,0.2,-1.5));
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(1.5,0.2,0));
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(-1.5,0.2,0));

    summonnpc(1000, 101, "Monster/Campaign_Dungeon/03_Miner/5_Mon_BombMiner_01_w_01", 310306, vector3(0, 0, 0));
    summonnpc(1000, 101, "Monster/Campaign_Dungeon/03_Miner/5_Mon_BombMiner_01_w_01", 310307, vector3(0, 0, 0));
    summonnpc(1000, 101, "Monster/Campaign_Dungeon/03_Miner/5_Mon_BombMiner_01_w_01", 310308, vector3(0, 0, 0));
    summonnpc(1000, 101, "Monster/Campaign_Dungeon/03_Miner/5_Mon_BombMiner_01_w_01", 310309, vector3(0, 0, 0));
    setenable(1000, "Visible", false);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setenable(0, "Visible", true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setenable(0, "Visible", true);
  };
};


//Ͷ��ˮ��
skill(310306)
{
  section(6000)
  {
    movecontrol(true);
    setenable(0, "Visible", true);
    rotate(10, 2500, vector3(100, 0, 0));
    settransform(0," ",vector3(0,1.5,0),eular(0,0,0),"RelativeOwner",false);
    startcurvemove(10, true, 3,0,5,1,0,-9,0);
    colliderdamage(10, 3000, false, false, 0, 0)
    {
      stateimpact("kDefault", 31030101);
      oncollidelayer("Terrains", "onterrain");
      oncollidelayer("Default", "onterrain");
      boneboxcollider(vector3(0.8, 0.8, 0.8), "Bone001", vector3(0, 0, 0), eular(0, 0, 0), true, false);
    };
    destroyself(6000);
  };
  onmessage("onterrain")
  {
    cleardamagepool(0);//���֮ǰ����˺��ļ�¼
    playsound(0, "baozha", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_touzhixiao_01", false);
    setenable(0, "CurveMove", false);
    setenable(0, "Rotate", false);
    setenable(0, "Visible", false);
//��ը�˺�
    areadamage(10, 0, 0.5, 0, 3, false) {
      stateimpact("kDefault", 31030102);
    };
    sceneeffect("Monster_FX/Campaign_Wild/03_KDArmy/6_Mon_KDM_BaoZha_01", 2000, vector3(0,0,0));
  };
};


//Ͷ��ˮ��
skill(310307)
{
  section(6000)
  {
    movecontrol(true);
    setenable(0, "Visible", true);
    rotate(10, 2500, vector3(100, 0, 0));
    settransform(0," ",vector3(0,1.5,0),eular(0,90,0),"RelativeOwner",false);
    startcurvemove(10, true, 3,0,5,1,0,-9,0);
    colliderdamage(10, 3000, false, false, 0, 0)
    {
      stateimpact("kDefault", 31030101);
      oncollidelayer("Terrains", "onterrain");
      oncollidelayer("Default", "onterrain");
      boneboxcollider(vector3(0.8, 0.8, 0.8), "Bone001", vector3(0, 0, 0), eular(0, 0, 0), true, false);
    };
    destroyself(6000);
  };
  onmessage("onterrain")
  {
    cleardamagepool(0);//���֮ǰ����˺��ļ�¼
    playsound(0, "baozha", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_touzhixiao_01", false);
    setenable(0, "CurveMove", false);
    setenable(0, "Rotate", false);
    setenable(0, "Visible", false);
//��ը�˺�
    areadamage(10, 0, 0.5, 0, 3, false) {
      stateimpact("kDefault", 31030102);
    };
    sceneeffect("Monster_FX/Campaign_Wild/03_KDArmy/6_Mon_KDM_BaoZha_01", 2000, vector3(0,0,0));
  };
};


//Ͷ��ˮ��
skill(310308)
{
  section(6000)
  {
    movecontrol(true);
    setenable(0, "Visible", true);
    rotate(10, 2500, vector3(100, 0, 0));
    settransform(0," ",vector3(0,1.5,0),eular(0,180,0),"RelativeOwner",false);
    startcurvemove(10, true, 3,0,5,1,0,-9,0);
    colliderdamage(10, 3000, false, false, 0, 0)
    {
      stateimpact("kDefault", 31030101);
      oncollidelayer("Terrains", "onterrain");
      oncollidelayer("Default", "onterrain");
      boneboxcollider(vector3(0.8, 0.8, 0.8), "Bone001", vector3(0, 0, 0), eular(0, 0, 0), true, false);
    };
    destroyself(6000);
  };
  onmessage("onterrain")
  {
    cleardamagepool(0);//���֮ǰ����˺��ļ�¼
    playsound(0, "baozha", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_touzhixiao_01", false);
    setenable(0, "CurveMove", false);
    setenable(0, "Rotate", false);
    setenable(0, "Visible", false);
//��ը�˺�
    areadamage(10, 0, 0.5, 0, 3, false) {
      stateimpact("kDefault", 31030102);
    };
    sceneeffect("Monster_FX/Campaign_Wild/03_KDArmy/6_Mon_KDM_BaoZha_01", 2000, vector3(0,0,0));
  };
};


//Ͷ��ˮ��
skill(310309)
{
  section(6000)
  {
    movecontrol(true);
    setenable(0, "Visible", true);
    rotate(10, 2500, vector3(100, 0, 0));
    settransform(0," ",vector3(0,1.5,0),eular(0,270,0),"RelativeOwner",false);
    startcurvemove(10, true, 3,0,5,1,0,-9,0);
    colliderdamage(10, 3000, false, false, 0, 0)
    {
      stateimpact("kDefault", 31030101);
      oncollidelayer("Terrains", "onterrain");
      oncollidelayer("Default", "onterrain");
      boneboxcollider(vector3(0.8, 0.8, 0.8), "Bone001", vector3(0, 0, 0), eular(0, 0, 0), true, false);
    };
    destroyself(6000);
  };
  onmessage("onterrain")
  {
    cleardamagepool(0);//���֮ǰ����˺��ļ�¼
    playsound(0, "baozha", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_touzhixiao_01", false);
    setenable(0, "CurveMove", false);
    setenable(0, "Rotate", false);
    setenable(0, "Visible", false);
//��ը�˺�
    areadamage(10, 0, 0.5, 0, 3, false) {
      stateimpact("kDefault", 31030102);
    };
    sceneeffect("Monster_FX/Campaign_Wild/03_KDArmy/6_Mon_KDM_BaoZha_01", 2000, vector3(0,0,0));
  };
};