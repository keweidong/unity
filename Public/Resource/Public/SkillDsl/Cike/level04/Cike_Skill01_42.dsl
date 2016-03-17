

/****    Ӱ�� �Ľ�    ****/

skill(120142)
{
  section(1)//��ʼ��
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
  };

  section(200)//����
  {
    animation("Cike_Skill01_02_01")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(30, true, 0.2, 0, 0, 12, 0, 0, -40);
    //
    //�������Ӱ���buff
    //addimpacttoself(1, 12990001, 500);
    //
    //ģ����ʧ
    setenable(30, "Visible", false);
    //ģ����ʾ
    setenable(120, "Visible", true);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 10, eular(0, 0, 0), vector3(1, 1, 1), true);

    //���
    playpartanimation(0, "CiBang_02", "Open");
  };

  section(166)//��һ��
  {
    animation("Cike_Skill01_02_02")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 20, 0, 0, -100);
    //
    //�ٻ�NPC  �������ӳ��˺�
    summonnpc(30, 101, "Hero/3_Cike/None", 120143, vector3(0, 0, 3));
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_TuZhanYiDuan_02", 3000, vector3(0, 0, 0), 10, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_TuZhanYiDuan_02_01", 3000, vector3(0, 0, 0), 10, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_LuoDiYan_01", 3000, vector3(-0.6, 0, 1.5), 10, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Skill01_TuZhan_03", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Voice_RenXuan_02", false)
    {
	    audiogroup("None");
    };
    //
    //��֡Ч��
    //lockframe(30, "Cike_Hit_01_02", true, 0.1, 100, 1, 100);
    //
    //����
    //shakecamera2(1, 400, false, true, vector3(0, 0, 1), vector3(0, 0, 400), vector3(0, 0, 0.1), vector3(0, 0, 100));
  };

  section(266)//Ӳֱ
  {
    animation("Cike_Skill01_02_03")
    {
      speed(1);
    };
    //
    //���
    addbreaksection(1, 266, 3000);
    addbreaksection(10, 266, 3000);
    addbreaksection(21, 266, 3000);
    addbreaksection(100, 266, 3000);
  };

  section(500)//����
  {
    animation("Cike_Skill01_02_99")
    {
      speed(1);
    };
  };

  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
    //���
    playpartanimation(0, "CiBang_02", "Idle", 2);
  };

  onstop() //������������ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
    //���
    playpartanimation(0, "CiBang_02", "Idle", 2);
  };
};


skill(120143)
{
  section(450)
  {
    movecontrol(true);
    //
    //�趨����Ϊʩ���߷���
    settransform(0," ",vector3(0,0,0),eular(0,0,0),"RelativeOwner",false);
    //
    //�˺��ж�
    areadamage(1, 0, 1.5, 2, 3, true)
		{
			stateimpact("kDefault", 12010301);
			stateimpact("kLauncher", 12010303);
			stateimpact("kKnockDown", 12010303);
      //showtip(200, 0, 1, 1);
		};
    shakecamera2(40, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
    areadamage(60, 0, 1.5, 2, 2.8, true)
		{
			stateimpact("kDefault", 12010301);
			stateimpact("kLauncher", 12010303);
			stateimpact("kKnockDown", 12010303);
      //showtip(200, 0, 1, 1);
		};
    areadamage(120, 0, 1.5, 2, 2.8, true)
		{
			stateimpact("kDefault", 12010301);
			stateimpact("kLauncher", 12010303);
			stateimpact("kKnockDown", 12010303);
      //showtip(200, 0, 1, 1);
		};
    areadamage(180, 0, 1.5, 2, 3, true)
		{
			stateimpact("kDefault", 12010301);
			stateimpact("kLauncher", 12010303);
			stateimpact("kKnockDown", 12010303);
      //showtip(200, 0, 1, 1);
		};
    shakecamera2(220, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
    areadamage(240, 0, 1.5, 2.5, 3.2, true)
		{
			stateimpact("kDefault", 12010302);
			stateimpact("kLauncher", 12010304);
			stateimpact("kKnockDown", 12010304);
      //showtip(200, 0, 1, 1);
		};
  };
};
