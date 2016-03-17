//��Ӣ�粼������ն
skill(300101)
{
  section(1333)
  {
    movecontrol(true);
    animation("SwordS_01") {
      speed(1.5);
    };
    addimpacttoself(0, 30010100);
    sceneeffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Monster_YuJing_Line_01", 1500, vector3(0, 0, 0), 10, eular(0, 0, 0), vector3(1, 1, 1), true);//��������������λ����Ȼ�в�ͬ����������
    startcurvemove(266, true, 0.4, 0, 0, -0.07, 0, 0, -0.5);
  };
  section(1500)
  {
    animation("SwordS_02")
    {
      wrapmode(2);
    };
    startcurvemove(0, true, 1.5, 0, 0, 3.5, 0, 0, 0);
    charactereffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_SwordS_01", 1550, "Bone_Root", 0);
    playsound(10, "huiwu", "Sound/Npc/Mon_Loop", 1500, "Sound/Npc/guaiwu_xuanfengzhan_01", false);

    areadamage(100, 0, 1, 0.5, 2.5, true) {
      stateimpact("kDefault", 30010101);
    };
    playsound(20, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
    shakecamera2(150, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));

    cleardamagestate(650);
    areadamage(700, 0, 1, 0.5, 2.5, true) {
      stateimpact("kDefault", 30010101);
    };
    playsound(710, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
    shakecamera2(750, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));

    cleardamagestate(1250);
    areadamage(1300, 0, 1, 0.5, 2.5, true) {
      stateimpact("kDefault", 30010101);
    };
    playsound(1310, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
    shakecamera2(1350, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
    stopsound(1495, "huiwu");
  };
  section(1833)
  {
    animation("SwordS_03");
    startcurvemove(0, true, 0.8, 0, 0, 1.5, 0, 0, -2.5);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    stopeffect(0);
    stopsound(0, "huiwu");
  };
};

//��Ӣ�粼�ֻӿ�
skill(300102)
{
  section(1400)
  {
    movecontrol(true);
    animation("Attack_01");
    charactereffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_DaoGuang_03", 2000, "Bone_Root", 100);
    startcurvemove(630, true, 0.05, 0, 0, 6, 0, 0, 0);
    playsound(630, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    areadamage(680, 0, 1, 0.5, 3, false) {
      stateimpact("kDefault", 30010201);
    };
    playsound(690, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
//    lockframe(720, "Attack_01", true, 0, 100, 1, 100);
//    shakecamera(740, true, 40, 20, 100, 0.5);
    shakecamera2(740, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
  };
};


//С���粼������
skill(300103)
{
  section(933)
  {
    movecontrol(true);
    animation("Attack_01A");
    charactereffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_DaoGuang_02", 2000, "Bone_Root", 520);
  };
  section(267)
  {
    animation("Attack_01B");
    startcurvemove(10, true, 0.07, 0, 0, 5, 0, 0, 100);
    playsound(10, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    areadamage(50, 0, 1, 1.5, 2, true) {
      stateimpact("kDefault", 30010301);
    };
    playsound(60, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
    shakecamera2(90, 250, true, true, vector3(0,0.15,0.2), vector3(0,150,150),vector3(0,0.5,0.5),vector3(0,40,60));
  };
  section(833)
  {
    animation("Attack_01C");
    startcurvemove(5, true, 0.2, 0, 0, -1, 0, 0, 0);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    stopeffect(0);
  };
};


//С���粼������
skill(300104)
{
  section(167)
  {
    movecontrol(true);
    animation("Attack_02A");
    findmovetarget(0, vector3(0,0,0),2.5,60,0.5,0.5,0,-2);
    startcurvemove(30, true, 0.09, 0, 0, 5, 0, 0, 30, 0.04, 0, 0, 3, 0, 0, -60);
    charactereffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_DaoGuang_01", 2000, "Bone_Root", 100) {
      transform(vector3(0,0,-0.5));
    };
  };
  section(800)
  {
    animation("Attack_02B");
    startcurvemove(130, true, 0.09, 0, 0, 8, 0, 0, 0);
    playsound(275, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuxiao_02", false);
    areadamage(320, 0, 1, 0.8, 2, true) {
      stateimpact("kDefault", 30010401);
    };
    playsound(330, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
    shakecamera2(370, 250, true, true, vector3(0,0,0.3), vector3(0,0,150),vector3(0,0,0.6),vector3(0,0,80));
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    stopeffect(0);
  };
};


//��ì�粼��
skill(300105)
{
  section(1433)
  {
    movecontrol(true);
    animation("Attack_01") ;
    startcurvemove(130, true, 0.07, 0, 0, 5, 0, 0, 0);
    setchildvisible(770,"5_Mon_Bluelf_02_w_01",false);
    summonnpc(770, 101, "Monster/Campaign_Wild/01_Bluelf/5_Mon_Bluelf_02_w_01", 390002, vector3(0, 0, 0));
    setchildvisible(1410,"5_Mon_Bluelf_02_w_01",true);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_02_w_01",true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_02_w_01",true);
  };
};


//��ƿ�粼��
skill(300106)
{
  section(3000)
  {
    movecontrol(true);
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(0,0.2,6.6));
    animation("Attack_01");
    startcurvemove(2100, true, 0.1, 0, 0, 3, 0, 0, 0);
    setchildvisible(2480,"5_Mon_Bluelf_w_04",false);
    summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390003, vector3(0, 0, 0));
    setchildvisible(2950,"5_Mon_Bluelf_w_04",true);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
};


//��ƿ�粼��40M
skill(300107)
{
  section(3000)
  {
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(0,0.4,40));
    animation("Attack_01");
    setchildvisible(2480,"5_Mon_Bluelf_w_04",false);
    summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 300108, vector3(0, 0, 0));
    setchildvisible(2950,"5_Mon_Bluelf_w_04",true);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
};

//Ͷ��ȼ��ƿ40M
skill(300108)
{
  section(5500)
  {
    movecontrol(true);
    setenable(0, "Visible", true);
    rotate(15, 2500, vector3(-720, 0, 0));
    settransform(0," ",vector3(0,1.1,0),eular(0,0,0),"RelativeOwner",false);
    startcurvemove(10, true, 3,0,6,20,0,-7,0);
    colliderdamage(500, 3000, false, false, 0, 0)
    {
      stateimpact("kDefault", 30010600);
      oncollidelayer("Terrains", "onterrain");
      oncollidelayer("Default", "onterrain");
      boneboxcollider(vector3(0.4, 0.4, 0.4), "Bone", vector3(0, 0, 0), eular(0, 0, 0), true, false);
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
      stateimpact("kDefault", 30010601);
    };
    sceneeffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_BaoZha_01", 1500, vector3(0,0,0));
    sceneeffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_RanShao_01", 5000, vector3(0,0,0));
//ȼ�ճ����˺�
    cleardamagepool(200);//���֮ǰ����˺��ļ�¼
    colliderdamage(500, 3500, true , true, 1000, 4) {
      stateimpact("kDefault", 30010602);
      sceneboxcollider(vector3(3,3,3), vector3(0, 0, 0), eular(0, 0, 0), false, false);
    };
    playsound(400, "ranshao", "Sound/Npc/Mon", 3000, "Sound/Npc/guaiwu_touzhixiao_02", false);
    destroyself(4000);
  };
};


//��ƿ�粼��30M
skill(300109)
{
  section(3000)
  {
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(0,0.4,30));
    animation("Attack_01");
    setchildvisible(2480,"5_Mon_Bluelf_w_04",false);
    summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 300110, vector3(0, 0, 0));
    setchildvisible(2950,"5_Mon_Bluelf_w_04",true);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
};

//Ͷ��ȼ��ƿ30M
skill(300110)
{
  section(5500)
  {
    movecontrol(true);
    setenable(0, "Visible", true);
    rotate(15, 2500, vector3(-720, 0, 0));
    settransform(0," ",vector3(0,1.1,0),eular(0,0,0),"RelativeOwner",false);
    startcurvemove(10, true, 3, 0, 6, 15, 0, -6.5, 0);
    colliderdamage(500, 3000, false, false, 0, 0)
    {
      stateimpact("kDefault", 30010600);
      oncollidelayer("Terrains", "onterrain");
      oncollidelayer("Default", "onterrain");
      boneboxcollider(vector3(0.4, 0.4, 0.4), "Bone", vector3(0, 0, 0), eular(0, 0, 0), true, false);
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
      stateimpact("kDefault", 30010601);
    };
    sceneeffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_BaoZha_01", 1500, vector3(0,0,0));
    sceneeffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_RanShao_01", 5000, vector3(0,0,0));
//ȼ�ճ����˺�
    cleardamagepool(200);//���֮ǰ����˺��ļ�¼
    colliderdamage(500, 3500, true , true, 1000, 4) {
      stateimpact("kDefault", 30010602);
      sceneboxcollider(vector3(3,3,3), vector3(0, 0, 0), eular(0, 0, 0), false, false);
    };
    playsound(400, "ranshao", "Sound/Npc/Mon", 3000, "Sound/Npc/guaiwu_touzhixiao_02", false);
    destroyself(4000);
  };
};



//��ƿ�粼��20M
skill(300121)
{
  section(3000)
  {
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(0,0.4,18));
    animation("Attack_01");
    setchildvisible(2480,"5_Mon_Bluelf_w_04",false);
    summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 300122, vector3(0, 0, 0));
    setchildvisible(2950,"5_Mon_Bluelf_w_04",true);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
};

//Ͷ��ȼ��ƿ20M
skill(300122)
{
  section(5500)
  {
    movecontrol(true);
    setenable(0, "Visible", true);
    rotate(15, 2500, vector3(-720, 0, 0));
    settransform(0," ",vector3(0,1.1,0),eular(0,0,0),"RelativeOwner",false);
    startcurvemove(10, true, 3, 0, 5, 9.8, 0, -6, 0);
    colliderdamage(500, 3000, false, false, 0, 0)
    {
      stateimpact("kDefault", 30010600);
      oncollidelayer("Terrains", "onterrain");
      oncollidelayer("Default", "onterrain");
      boneboxcollider(vector3(0.4, 0.4, 0.4), "Bone", vector3(0, 0, 0), eular(0, 0, 0), true, false);
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
      stateimpact("kDefault", 30010601);
    };
    sceneeffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_BaoZha_01", 1500, vector3(0,0,0));
    sceneeffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_RanShao_01", 5000, vector3(0,0,0));
//ȼ�ճ����˺�
    cleardamagepool(200);//���֮ǰ����˺��ļ�¼
    colliderdamage(500, 3500, true , true, 1000, 4) {
      stateimpact("kDefault", 30010602);
      sceneboxcollider(vector3(3,3,3), vector3(0, 0, 0), eular(0, 0, 0), false, false);
    };
    playsound(400, "ranshao", "Sound/Npc/Mon", 3000, "Sound/Npc/guaiwu_touzhixiao_02", false);
    destroyself(4000);
  };
};

//��ƿ�粼��
skill(300120)
{
  section(3000)
  {
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(0,0.2,6.6));
    animation("Attack_01");
    setchildvisible(2480,"5_Mon_Bluelf_w_04",false);
    summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390003, vector3(0, 0, 0));
    setchildvisible(2950,"5_Mon_Bluelf_w_04",true);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
};

//��ƿ�粼���Ա�
skill(300123)
{
  section(3000)
  {
    movecontrol(true);
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(0,0.2,1.5));
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(0,0.2,-1.5));
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(1.5,0.2,0));
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(-1.5,0.2,0));

    summonnpc(1000, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390008, vector3(0, 0, 0));
    summonnpc(1000, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390009, vector3(0, 0, 0));
    summonnpc(1000, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390010, vector3(0, 0, 0));
    summonnpc(1000, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390011, vector3(0, 0, 0));
	
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

//��ƿ�粼�־�Ӣ�����ƿ
skill(300124)
{
  section(3000)
  {
    movecontrol(true);
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(-6,0.2,3.3));
    //sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(-4.6,0.2,4.6));
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(-3.3,0.2,6));
    //sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(-1.5,0.2,6.3));
    //sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(1.5,0.2,6.3));
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(3.3,0.2,6));
    //sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(4.6,0.2,4.6));
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_YuJing_01", 4500, vector3(6,0.2,3.3));
    animation("Attack_01");
    startcurvemove(2100, true, 0.1, 0, 0, 3, 0, 0, 0);
    setchildvisible(2480,"5_Mon_Bluelf_w_04",false);
    summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390014, vector3(0, 0, 0));
    //summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390015, vector3(0, 0, 0));
    summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390016, vector3(0, 0, 0));
    //summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390017, vector3(0, 0, 0));
    //summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390018, vector3(0, 0, 0));
    summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390019, vector3(0, 0, 0));
    //summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390020, vector3(0, 0, 0));
    summonnpc(2480, 101, "Monster/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_Bomb_01", 390021, vector3(0, 0, 0));
    setchildvisible(2950,"5_Mon_Bluelf_w_04",true);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_w_04",true);
  };
};


//��ì�粼�־�Ӣ
skill(300125)
{
  section(716)
  {
    settransform(0, " ", vector3(0, 0, 0), eular(0, -30, 0), "RelativeSelf", true);
    movecontrol(true);
    animation("Attack_01")
	{
		speed(2);
	};
    setchildvisible(335,"5_Mon_Bluelf_02_w_02",false);
    summonnpc(335, 101, "Monster/Campaign_Wild/01_Bluelf/5_Mon_Bluelf_02_w_01", 390002, vector3(0, 0, 0));
    setchildvisible(705,"5_Mon_Bluelf_02_w_02",true);
  };
  section(716)
  {
    settransform(0, " ", vector3(0, 0, 0), eular(0, 15, 0), "RelativeSelf", true);
    movecontrol(true);
    animation("Attack_01")
	{
		speed(2);
	};
    setchildvisible(335,"5_Mon_Bluelf_02_w_02",false);
    summonnpc(335, 101, "Monster/Campaign_Wild/01_Bluelf/5_Mon_Bluelf_02_w_01", 390002, vector3(0, 0, 0));
    setchildvisible(705,"5_Mon_Bluelf_02_w_02",true);
  };
  section(716)
  {
    settransform(0, " ", vector3(0, 0, 0), eular(0, 15, 0), "RelativeSelf", true);
    movecontrol(true);
    animation("Attack_01")
	{
		speed(2);
	};
    setchildvisible(335,"5_Mon_Bluelf_02_w_02",false);
    summonnpc(335, 101, "Monster/Campaign_Wild/01_Bluelf/5_Mon_Bluelf_02_w_01", 390002, vector3(0, 0, 0));
    setchildvisible(705,"5_Mon_Bluelf_02_w_02",true);
  };
  section(716)
  {
    settransform(0, " ", vector3(0, 0, 0), eular(0, 15, 0), "RelativeSelf", true);
    movecontrol(true);
    animation("Attack_01")
	{
		speed(2);
	};
    setchildvisible(335,"5_Mon_Bluelf_02_w_02",false);
    summonnpc(335, 101, "Monster/Campaign_Wild/01_Bluelf/5_Mon_Bluelf_02_w_01", 390002, vector3(0, 0, 0));
    setchildvisible(705,"5_Mon_Bluelf_02_w_02",true);
  };
  section(716)
  {
    settransform(0, " ", vector3(0, 0, 0), eular(0, 15, 0), "RelativeSelf", true);
    movecontrol(true);
    animation("Attack_01")
	{
		speed(2);
	};
    setchildvisible(335,"5_Mon_Bluelf_02_w_02",false);
    summonnpc(335, 101, "Monster/Campaign_Wild/01_Bluelf/5_Mon_Bluelf_02_w_01", 390002, vector3(0, 0, 0));
    setchildvisible(705,"5_Mon_Bluelf_02_w_02",true);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_02_w_02",true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setchildvisible(0,"5_Mon_Bluelf_02_w_02",true);
  };
};


//С���粼������
skill(300126)
{
  section(466)
  {
    movecontrol(true);
    animation("Attack_01A")
	{
		speed(2);
	};
    charactereffect("Monster_FX/Campaign_Wild/01_Bluelf/6_Mon_Bluelf_DaoGuang_02", 2000, "Bone_Root", 260);
  };
  section(267)
  {
    animation("Attack_01B")
	{
		speed(2);
	};
    playsound(10, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    areadamage(25, 0, 1, 1.5, 2, true) {
      stateimpact("kDefault", 30010301);
    };
    playsound(30, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
    shakecamera2(45, 250, true, true, vector3(0,0.15,0.2), vector3(0,150,150),vector3(0,0.5,0.5),vector3(0,40,60));
  };
  section(416)
  {
    animation("Attack_01C")
	{
		speed(2);
	};
    startcurvemove(5, true, 0.2, 0, 0, -1, 0, 0, 0);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    stopeffect(0);
  };
};