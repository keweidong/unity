

/****    ����һ�� �Ľ�    ****/

skill(120941)
{
  section(1)//��ʼ  0
  {
    //
    //����������������
    setcamerafollowspeed(0, 40, 5, 15, 5, 1);
    //
    //���ð���
    addimpacttoself(0, 12990001, 500);
  };

  section(1)//��ʼ��  1
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //˲���෨�����
    addbreaksection(11, 1, 30000);
  };

  section(33)//����  2
  {
    animation("Cike_Skill09_01_01")
    {
      speed(1);
    };
    //
		findmovetarget(0, vector3(0, 0, 1), 7, 240, 0.1, 0.9, 0, -3);
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 12, 0, 0, 0);
    //
    gotosection(0, 20, 0)
    {
      targetcondition(false);
    };
  };

  section(66)//��һ��  3
  {
    animation("Cike_Skill09_01_02")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 20, 0, 0, -100);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12000101);
			stateimpact("kLauncher", 12000103);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_01_DaoGuang_01", 500, "Bone_Root", 1);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_01_DaoGuang_01", 3000, vector3(0, 0, 2), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_01_ShouJi_01", 3000, vector3(0, 0, 2), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

  section(133)//Ӳֱ  4
  {
    animation("Cike_Skill09_01_03")
    {
      speed(1);
    };
    //
    //ģ����ʧ
    //setenable(10, "Visible", false);
    //ģ����ʾ
    //setenable(90, "Visible", true);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.1, 0, 0, -50, 0, 0, 0);
    //����
    settransform(0, " ", vector3(0, 0, 0), eular(0, 144, 0), "RelativeSelf", true);
  };

  //////////////////////////         2222222         ////////////////////////////////
  //////////////////////////////////////////////////////////////////////////////////

  section(200)//����  5
  {
    animation("Cike_Skill09_02_01")
    {
      speed(1);
    };
    //
		findmovetarget(0, vector3(0, 0, 1), 7, 240, 0.1, 0.9, 0, -3);
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 12, 0, 0, 0);
    //
    //
    gotosection(0, 20, 0)
    {
      targetcondition(false);
    };
  };

  section(66)//��һ��  6
  {
    animation("Cike_Skill09_02_02")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 20, 0, 0, -100);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12000101);
			stateimpact("kLauncher", 12000103);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_02_DaoGuang_01", 500, "Bone_Root", 1);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_02_DaoGuang_01", 3000, vector3(0, 0, 2), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_02_ShouJi_01", 3000, vector3(0, 0, 2), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

  section(133)//Ӳֱ  7
  {
    animation("Cike_Skill09_02_03")
    {
      speed(1);
    };
    //
    //ģ����ʧ
    //setenable(10, "Visible", false);
    //ģ����ʾ
    //setenable(90, "Visible", true);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.1, 0, 0, -50, 0, 0, 0);
    //����
    settransform(0, " ", vector3(0, 0, 0), eular(0, 144, 0), "RelativeSelf", true);
  };

  ////////////////////////////////    33333333     //////////////////////////////////
  //////////////////////////////////////////////////////////////////////////////////

  section(33)//����  8
  {
    animation("Cike_Skill09_03_01")
    {
      speed(1);
    };
    //
		findmovetarget(0, vector3(0, 0, 1), 7, 240, 0.1, 0.9, 0, -3);
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 12, 0, 0, 0);
    //
    gotosection(0, 20, 0)
    {
      targetcondition(false);
    };
  };

  section(33)//��һ��  9
  {
    animation("Cike_Skill09_03_02")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 20, 0, 0, -100);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12000101);
			stateimpact("kLauncher", 12000103);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_03_Xian_01", 500, "Bone_Root", 1);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_03_Xian_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_03_ShouJi_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_03_ShouJi_02", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

  section(233)//Ӳֱ  10
  {
    animation("Cike_Skill09_03_03")
    {
      speed(1);
    };
    //
    //ģ����ʧ
    //setenable(10, "Visible", false);
    //ģ����ʾ
    //setenable(90, "Visible", true);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.1, 0, 0, -50, 0, 0, 0);
    //����
    settransform(0, " ", vector3(0, 0, 0), eular(0, 144, 0), "RelativeSelf", true);
  };

  //////////////////////////////     444444       ///////////////////////////////////
  //////////////////////////////////////////////////////////////////////////////////

  section(100)//����  11
  {
    animation("Cike_Skill09_04_01")
    {
      speed(1);
    };
    //
		findmovetarget(0, vector3(0, 0, 1), 7, 240, 0.1, 0.9, 0, -3);
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 12, 0, 0, 0);
    //
    gotosection(0, 20, 0)
    {
      targetcondition(false);
    };
  };

  section(66)//��һ��  12
  {
    animation("Cike_Skill09_04_02")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 20, 0, 0, -100);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12000101);
			stateimpact("kLauncher", 12000103);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_04_DaoGuang_01", 500, "Bone_Root", 1);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_04_DaoGuang_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_04_ShouJi_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

  section(33)//Ӳֱ  13
  {
    animation("Cike_Skill09_04_03")
    {
      speed(1);
    };
    //
    //ģ����ʧ
    //setenable(10, "Visible", false);
    //ģ����ʾ
    //setenable(90, "Visible", true);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.1, 0, 0, -50, 0, 0, 0);
    //����
    settransform(0, " ", vector3(0, 0, 0), eular(0, 144, 0), "RelativeSelf", true);
  };


  //////////////////////////////     5555555       ///////////////////////////////////
  //////////////////////////////////////////////////////////////////////////////////

  section(33)//����  14
  {
    animation("Cike_Skill09_05_01")
    {
      speed(1);
    };
    //
		findmovetarget(0, vector3(0, 0, 1), 7, 240, 0.1, 0.9, 0, -3);
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 12, 0, 0, 0);
    //
    gotosection(0, 20, 0)
    {
      targetcondition(false);
    };
  };

  section(33)//��һ��  15
  {
    animation("Cike_Skill09_05_02")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 20, 0, 0, -100);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12000101);
			stateimpact("kLauncher", 12000103);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_05_Xian_02", 500, "Bone_Root", 1);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_05_Xian_02", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_05_ShouJi_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_05_ShouJi_02", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

  section(33)//Ӳֱ  16
  {
    animation("Cike_Skill09_05_03")
    {
      speed(1);
    };
    //
    //ģ����ʧ
    //setenable(10, "Visible", false);
    //ģ����ʾ
    //setenable(90, "Visible", true);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.1, 0, 0, -50, 0, 0, 0);
    //����
    settransform(0, " ", vector3(0, 0, 0), eular(0, 144, 0), "RelativeSelf", true);
  };

  //////////////////////////////     666666       ///////////////////////////////////
  //////////////////////////////////////////////////////////////////////////////////

  section(33)//����  17
  {
    animation("Cike_Skill09_06_01")
    {
      speed(1);
    };
    //
		findmovetarget(0, vector3(0, 0, 1), 7, 240, 0.1, 0.9, 0, -3);
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 12, 0, 0, 0);
    //
    gotosection(0, 20, 0)
    {
      targetcondition(false);
    };
  };

  section(100)//��һ��  18
  {
    animation("Cike_Skill09_06_02")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 20, 0, 0, -100);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12000101);
			stateimpact("kLauncher", 12000103);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_06_Xian_01", 500, "Bone_Root", 1);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_06_Xian_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_06_ShouJi_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_06_ShouJi_02", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

  section(166)//Ӳֱ  19
  {
    animation("Cike_Skill09_06_03")
    {
      speed(1);
    };
    //
    //ģ����ʧ
    //setenable(10, "Visible", false);
    //ģ����ʾ
    //setenable(90, "Visible", true);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.1, 0, 0, -50, 0, 0, 0);
    //����
    settransform(0, " ", vector3(0, 0, 0), eular(0, 144, 0), "RelativeSelf", true);
  };

    //////////////////////////////     7777777       ///////////////////////////////////
  //////////////////////////////////////////////////////////////////////////////////

  section(1)//����  20
  {
    animation("Cike_Skill09_07_01")
    {
      speed(1);
    };
  };

  section(200)//��һ��  21
  {
    //
    //���������
    resetcamerafollowspeed(0);
    //
    animation("Cike_Skill09_07_02")
    {
      speed(1);
    };
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12000101);
			stateimpact("kLauncher", 12000103);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_WuDiZhan_07_LuoDi_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

  section(300)//Ӳֱ  22
  {
    animation("Cike_Skill09_07_99")
    {
      speed(1);
    };
  };


  //////////////////////////////////////////////////////////
  //////////////////////////////////////////////////////////
  //////////////////////////////////////////////////////////


  section(1)//����  23
  {
  };

  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
    //
    //���������
    resetcamerafollowspeed(0);
  };

  onstop() //������������ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
    //
    //���������
    resetcamerafollowspeed(0);
  };
};




