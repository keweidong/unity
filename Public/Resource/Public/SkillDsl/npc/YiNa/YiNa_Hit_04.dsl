

/****    �����չ��Ķ�    ****/

skill(400004)
{
  section(1)//��ʼ��
  {
    movechild(0, "5_IP_YiNa_01_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "5_IP_YiNa_01_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //˲���༼�ܴ��
    addbreaksection(11, 1, 30000);
    //
  };

  section(266)//����
  {
    animation("YiNa_Hit_04_01")
    {
      speed(1.5);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(1, true, 0.12, 0, 0, 16, 0, 0, 0);
    //
  };
  section(66)//��һ��
  {
    animation("YiNa_Hit_04_02")
    {
      speed(1.5);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(1, true, 0.1, 0, 0, 16, 0, 0, -30);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.8, true)
		{
			stateimpact("kDefault", 40000109);
			stateimpact("kLauncher", 40000110);
			stateimpact("kKnockDown", 40000001);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_PuGong_04_01", 500, "Bone_Root", 1);
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_PuGong_04_02", 500, "Bone_Root", 1);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_08", false);
    playsound(20, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_02", true);
    playsound(20, "Hit03", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_Voice_01", false);
  };

  section(177)//Ӳֱ
  {
    animation("YiNa_Hit_04_03")
    {
      speed(1.5);
    };
  };

  section(222)//����
  {
    animation("YiNa_Hit_04_99")
    {
      speed(1.5);
    };
    //
    //���
    addbreaksection(1, 1, 2000);
    addbreaksection(10, 1, 2000);
    addbreaksection(100, 1, 2000);
  };
};


//�����չ��޺�ҡ

skill(400004)
{
  section(1)//��ʼ��
  {
    movechild(0, "5_IP_YiNa_01_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "5_IP_YiNa_01_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //˲���༼�ܴ��
    addbreaksection(11, 1, 30000);
    //
  };

  section(266)//����
  {
    animation("YiNa_Hit_04_01")
    {
      speed(1.5);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(1, true, 0.12, 0, 0, 16, 0, 0, 0);
    //
  };
  section(66)//��һ��
  {
    animation("YiNa_Hit_04_02")
    {
      speed(1.5);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(1, true, 0.1, 0, 0, 16, 0, 0, -30);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.8, true)
		{
			stateimpact("kDefault", 40000109);
			stateimpact("kLauncher", 40000110);
			stateimpact("kKnockDown", 40000001);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_PuGong_04_01", 500, "Bone_Root", 1);
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_PuGong_04_02", 500, "Bone_Root", 1);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_08", false);
    playsound(20, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_02", true);
    playsound(20, "Hit03", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_Voice_01", false);
  };

  section(177)//Ӳֱ
  {
    animation("YiNa_Hit_04_03")
    {
      speed(1.5);
    };
  };
};
