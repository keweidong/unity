

/****    ���� �Ľ�    ****/

skill(120241)
{
  section(1)//��ʼ��  1
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //˲���༼�ܴ��
    addbreaksection(11, 1, 30000);
    //
  };

  section(266)//����  2
  {
    animation("Cike_Skill02_01_01")
    {
      speed(1);
    };
    //
    //�������Ӱ���buff
    addimpacttoself(0, 12990001, 500);
  };

  section(166)//��һ��  3
  {
    animation("Cike_Skill02_01_02")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 20, 0, 0, -100);
    //
    //�˺��ж�
    /*
    areadamage(20, 0, 0.5, 1.5, 2.2, false)
		{
			stateimpact("kDefault", 12020101);
      //showtip(200, 0, 1, 0);
		};
    areadamage(90, 0, 0.5, 2.0, 2.2, false)
		{
			stateimpact("kDefault", 12020102);
      //showtip(200, 0, 0, 1);
		};
    */
    areadamage(30, 0, 0.5, 2.5, 2.8, true)
		{
			stateimpact("kDefault", 12020103);
      //showtip(200, 0, 1, 1);
		};
    //
    //��Ч
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShangTiao_01", 3000, vector3(0, 0, 1), 10, eular(0, 0, 0), vector3(1, 1, 1), true);
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShangTiao_02_003", 3000, vector3(0, 0, 1.8), 10, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Skill02_ShangTiao_01", false);

    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Voice_ShangTiao_01", false)
    {
	    audiogroup("None", "None");
    };
    //
		findmovetarget(160, vector3(0, 0, 1), 2, 60, 0.1, 0.9, 0, 0);
    //
    //�ж�
    gotosection(165, 5, 0)
    {
      targetcondition(true);
    };
  };

  section(30)//Ӳֱ  4
  {
    forbidnextskill(0);
  };

  section(100)//Ӳֱ  5
  {
    animation("Cike_Skill02_01_03")
    {
      speed(1);
    };
    //
    //���
    addbreaksection(1, 20, 333);
    addbreaksection(10, 20, 333);
    addbreaksection(21, 20, 333);
    addbreaksection(100, 20, 333);
  };

  section(533)//����  6
  {
    animation("Cike_Skill02_01_99")
    {
      speed(1);
    };
  };

  onmessage("oncollide")  //�����¼�, "oncollide"��Ĭ����ײ�¼�
  {
    gotosection(0, 4, 0);
  };
};
