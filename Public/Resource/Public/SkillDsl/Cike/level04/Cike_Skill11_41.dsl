

/****    �����һ��    ****/

skill(121141)
{
  section(1)//��ʼ��
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //˲���෨�����
    addbreaksection(11, 1, 30000);
    //
		//findmovetarget(0, vector3(0, 0, 1), 2.5, 60, 0.1, 0.9, 0, -0.8);
  };

  section(366)//��һ��
  {
    animation("Cike_Skill11_01_01")
    {
      speed(1);
    };
    //
    //�ٻ�����
    summonnpc(50, 101, "Hero_FX/3_Cike/3_Hero_Cike_FeiBiao_01", 125501, vector3(0, 0, 0));
    summonnpc(100, 101, "Hero_FX/3_Cike/3_Hero_Cike_FeiBiao_01", 125502, vector3(0, 0, 0));
    summonnpc(150, 101, "Hero_FX/3_Cike/3_Hero_Cike_FeiBiao_01", 125503, vector3(0, 0, 0));
  };

  section(733)//�ڶ���
  {
    animation("Cike_Skill11_01_02")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.3, 0, 0, -8, 0, 0, 0);
    startcurvemove(300, true, 0.2, 0, 0, -5, 0, 0, 0);
    startcurvemove(500, true, 0.1, 0, 0, -2, 0, 0, 0);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
    //
    //�ٻ�����
    summonnpc(0, 101, "Hero_FX/3_Cike/3_Hero_Cike_FeiBiao_01", 125504, vector3(0, 0, 0));
    summonnpc(50, 101, "Hero_FX/3_Cike/3_Hero_Cike_FeiBiao_01", 125505, vector3(0, 0, 0));
    summonnpc(100, 101, "Hero_FX/3_Cike/3_Hero_Cike_FeiBiao_01", 125506, vector3(0, 0, 0));
  };


  section(566)//Ӳֱ
  {
    animation("Cike_Skill11_01_03")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.05, 0, 0, -30, 0, 0, 0);
    startcurvemove(50, true, 0.1, 0, 0, -5, 0, 0, 0);
    startcurvemove(150, true, 0.1, 0, 0, -2, 0, 0, 0);
    //
    //�ٻ������
    summonnpc(0, 101, "Hero_FX/3_Cike/3_Hero_Cike_FeiBiaoDa_01", 125511, vector3(0, 0, 0));
  };

  section(166)//����
  {
    animation("Cike_Skill11_01_99")
    {
      speed(1);
    };
    //
    //���
    addbreaksection(1, 1, 2000);
    addbreaksection(10, 1, 2000);
    addbreaksection(21, 1, 2000);
    addbreaksection(100, 1, 2000);
    //
  };
};
