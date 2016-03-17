//�ٻ����������
skill(3204001)
{
  section(500)
  {
    animation("Stand");
    sceneeffect("Monster_FX/Campaign_Wild/6_Monster_ChuSheng_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
  };
};

//Ŀ�����˲��
skill(3204002)
{
  section(466)//����
  {
    movecontrol(true);
    animation("Skill02_01");
    setenable(300, "Visible", false);
    sceneeffect("Monster_FX/Campaign_Desert/03_Assassin/5_Mon_Assassin_ShanShen_01", 3000, vector3(0, 0, 0), 290, eular(0, 0, 0), vector3(1, 1, 1), true);
  };

  section(100)//˲��
  {
    addimpacttoself(1, 12990001, 500);
    findmovetarget(0, vector3(0, 0, 1), 10, 60, 0.1, 0.9, 0, 5);
    startcurvemove(10, true, 0.05, 0, 0, 20, 0, 0, 0);
    settransform(90, " ", vector3(0, 0, 0), eular(0, 180, 0), "RelativeSelf", true);
  };

  section(966)//����
  {
    animation("Skill02_02");
    setenable(0, "Visible", true);
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

//�������˲��
skill(3204003)
{
  section(466)//����
  {
    movecontrol(true);
    animation("Skill02_01");
    setenable(300, "Visible", false);
    sceneeffect("Monster_FX/Campaign_Desert/03_Assassin/5_Mon_Assassin_ShanShen_01", 3000, vector3(0, 0, 0), 290, eular(0, 0, 0), vector3(1, 1, 1), true);
  };

  section(100)//��һ��
  {
    startcurvemove(1, true, 0.1, 0, 0, -30, 0, 0, 0);
  };

  section(966)//����
  {
    animation("Skill02_02");
    setenable(0, "Visible", true);
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

//˲��
skill(3204004)
{
  section(466)
  {
    animation("Skill02_01");
    movecontrol(true);
    findmovetarget(5,vector3(0,0,0),10,90,0.5,0.5,0,1);
  };

  section(100)
  {
    setenable(0, "Visible", false);
    sceneeffect("Monster_FX/Campaign_Desert/03_Assassin/5_Mon_Assassin_ShanShen_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    settransform(10," ",vector3(3,0.2,-6),eular(0,0,0),"RelativeTarget",false,true);
  };

  section(966)
  {
    animation("Skill02_02");
    setenable(0, "Visible", true);
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

//ƽ��
skill(3204005)
{
  section(1200)
  {
    movecontrol(true);
    animation("Walk");
    startcurvemove(1, false, 1.2, 3, 0, 0.01, 0, 0, 0);
    findmovetarget(100,vector3(0,0,0),10,360,0.5,0.5,0,5);
    facetotarget(101,1000,300);
  };
};

//ƽ��2
skill(3204006)
{
  section(1200)
  {
    movecontrol(true);
    animation("Walk");
    startcurvemove(1, false, 1.2, -3, 0, 0.01, 0, 0, 0);
    findmovetarget(100,vector3(0,0,0),10,360,0.5,0.5,0,5);
    facetotarget(101,1000,300);
  };
};


//��Ӱ��
skill(320407)
{
  section(600)//��һ��
  {
    animation("Skill01_01");
  };

  section(1566)//�ڶ���
  {
    animation("Skill01_02");
    //�ٻ�����
    summonnpc(0, 101, "Monster_FX/Campaign_Desert/04_Wizard/6_Mon_Wizard_AnYingJian_01", 3204071, vector3(0, 0, 0));
  };
};

//��Ӱ������
skill(3204071)
{
  section(3000)//��һ��
  {
    movecontrol(true);
    //�趨����Ϊʩ���߷���
    settransform(0," ",vector3(0, 1.5, 0),eular(0,0,0),"RelativeOwner",false);
    //��ɫ�ƶ�
    startcurvemove(10, true, 3, 0, 0, 10, 0, 0, 0);
    //��ײ��
    colliderdamage(0, 3000, true, true, 0, 1)
    {
      stateimpact("kDefault", 32040301);
      sceneboxcollider(vector3(0.7, 0.7, 0.7), vector3(0, 0, 0), eular(0, 0, 0), true, false);
    };
    //����
    destroyself(2990);
  };

  onmessage("oncollide")  //�����¼�, "oncollide"��Ĭ����ײ�¼�
  {
    summonnpc(0, 101, "Monster_FX/Campaign_Desert/04_Wizard/6_Mon_Wizard_AnYingJian_02", 320400, vector3(0, 0, 1.2));
    destroyself(0);
  };
};




//�ٻ���ս��
skill(320408)
{
  section(466)//��һ��
  {
    animation("Skill02_01");
  };

  section(1500)//�ڶ���
  {
    animation("Skill02_02");
    //�ٻ�NPC
    summonnpc(0, 3014, "", 3204001, vector3(0, 0, 2), eular(0, 0, 0), 20001, false);
  };
};

//�ٻ�Զ�̱�
skill(320409)
{
  section(466)//��һ��
  {
    animation("Skill02_01");
  };

  section(1500)//�ڶ���
  {
    animation("Skill02_02");
    //�ٻ�NPC
    summonnpc(0, 3015, "", 3204001, vector3(0, 0, 2), eular(0, 0, 0), 20002, false);
  };
};

//�ٻ���Ӣ��ս��
skill(320410)
{
  section(466)//��һ��
  {
    animation("Skill02_01");
  };

  section(1500)//�ڶ���
  {
    animation("Skill02_02");
    //�ٻ�NPC
    summonnpc(0, 3024, "", 3204001, vector3(0, 0, 2), eular(0, 0, 0), 20001, false);
  };
};

//�ٻ���ӢԶ�̱�
skill(320411)
{
  section(466)//��һ��
  {
    animation("Skill02_01");
  };

  section(1500)//�ڶ���
  {
    animation("Skill02_02");
    //�ٻ�NPC
    summonnpc(0, 3025, "", 3204001, vector3(0, 0, 2), eular(0, 0, 0), 20001, false);
  };
};

//�ٻ���׳
skill(320412)
{
  section(466)//��һ��
  {
    animation("Skill02_01");
  };

  section(1500)//�ڶ���
  {
    animation("Skill02_02");
    //�ٻ�NPC
    summonnpc(0, 1063, "", 3204001, vector3(0, 0, 2), eular(0, 0, 0), 20001, false);
  };
};



