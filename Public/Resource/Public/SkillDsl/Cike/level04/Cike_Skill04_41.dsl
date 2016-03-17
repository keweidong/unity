

/****    ˲��һ�� �Ľ�    ****/

skill(120441)
{
  section(1)//��ʼ�� 0
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //�������Ӱ���buff
    addimpacttoself(0, 12990001, 1000);
    addimpacttoself(0, 12990003, 1000);
  };

  section(50)//�ж� 1
  {
    gotosection(0, 2, 50)
    {
      statecondition(true, "kStiffness");
    };

     gotosection(50, 4, 1);
  };

  section(50)//�ж� 2
  {
    addimpacttoself(0, 12990004, 500);
    addimpacttoself(1, 12990001, 1000);
    gotosection(0, 3, 50)
    {
      statecondition(true, "kStand");
    };
  };

  section(500)//�����֧ 3
  {
    //
    //�ٻ�NPC
    summonnpc(0, 101, "Hero/3_Cike/3_Cike_02", 125301, vector3(0, 0, 0));
    //
    movecontrol(true);
    animation("Cike_Skill04_03_01")
    {
      speed(1);
    };
    //
    //ת��
    //settransform(0, " ", vector3(0, 0, 0), eular(0, 180, 0), "RelativeSelf", true);
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.12, 0, 0, -25, 0, 0, 0);
    startcurvemove(120, true, 0.30, 0, 0, -15, 0, 0, 40);
    //
    //�������Ӱ���buff
    //addimpacttoself(1, 12990001, 400);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 10, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_001", 3000, vector3(0, 0, 0), 80, eular(0, 0, 0), vector3(1, 1, 1), true);
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_001", 3000, "Bone_Root", 10);
    //
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShen_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_LuoDiYan_03", 3000, vector3(0, 0, 0), 120, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_LuoDiYan_03", 3000, vector3(0, 0, 0), 220, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_LuoDiYan_03", 3000, vector3(0, 0, 0), 320, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Sound01", "Sound/Cike/CikeSkillSound01", 2000, "Sound/Cike/Cike_Skill04_ShunShen_01", false);

    playsound(20, "Hit03", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Voice_ShunShen_01", false)
    {
	    audiogroup("Sound/Cike/Cike_Voice_ShunShen_02");
    };
    //
    //ģ����ʧ
    setenable(0, "Visible", false);
    //ģ����ʾ
    setenable(120, "Visible", true);
    //
    //��ת
    gotosection(500, 6, 1);
    //
    //��ת
    addbreaksection(1, 450, 1000);
    addbreaksection(10, 450, 1000);
    addbreaksection(11, 450, 1000);
    addbreaksection(21, 450, 1000);
    addbreaksection(100, 450, 1000);
  };

  section(233)//������֧ 4
  {

    movecontrol(true);
    animation("Cike_Skill04_01_01")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.22, 0, 0, 30, 0, 0, -40);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 10, eular(0, 0, 0), vector3(1, 1, 1), true);
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenXian_01", 3000, vector3(0, 0, 0), 100, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Sound01", "Sound/Cike/CikeSkillSound01", 2000, "Sound/Cike/Cike_Skill04_ShunShen_01", false);

    playsound(20, "Hit03", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Voice_ShunShen_01", false)
    {
	    audiogroup("Sound/Cike/Cike_Voice_ShunShen_02");
    };
    //ģ����ʧ
    setenable(50, "Visible", false);
    //ģ����ʾ
    setenable(180, "Visible", true);
    //
    //���
    addbreaksection(1, 200, 1000);
    addbreaksection(10, 200, 1000);
    addbreaksection(11, 200, 1000);
    addbreaksection(21, 200, 1000);
    addbreaksection(100, 200, 1000);
    //
  };

  section(66)//�������� 5
  {
    animation("Cike_Skill04_01_99")
    {
      speed(1);
    };
    //
    //��ת
    gotosection(65, 7, 1);
  };

  section(733)//�������� 6
  {
    animation("Cike_Skill04_03_99")
    {
      speed(1);
    };
    //
    //���
    addbreaksection(1, 1, 1000);
  };

  section(1)//���� 7
  {
  };

  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
  };

  onstop() //������������ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
  };
};
