

/****    �չ�����    ****/

skill(120002)
{
  section(1)//��ʼ��
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //˲���༼�ܴ��
    addbreaksection(11, 1, 30000);
    //
  };

  section(133)//��һ��
  {
    animation("Cike_Hit_02_01")
    {
      speed(2);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 16, 0, 0, -100);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.1, 2.2, true)
		{
			stateimpact("kDefault", 12000201);
			stateimpact("kLauncher", 12000204);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_PuGong_02_001", 500, "Bone_Root", 1);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_03", false);
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Voice_PuGong_02", false)
    {
	audiogroup("None", "None");
    };

    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true)
{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};
  };

  section(194)//�ڶ���
  {
    animation("Cike_Hit_02_02")
    {
      speed(1.2);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 15, 0, 0, 0);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.1, 2.2, true)
		{
			stateimpact("kDefault", 12000202);
			stateimpact("kLauncher", 12000205);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_PuGong_02_002", 500, "Bone_Root", 1);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_04", false);

    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true)
{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		}; 
    //
    //��֡Ч��
    //lockframe(30, "Cike_Hit_01_02", true, 0.1, 100, 1, 100);
    //
    //����
    //shakecamera2(1, 400, false, true, vector3(0, 0, 1), vector3(0, 0, 400), vector3(0, 0, 0.1), vector3(0, 0, 100));
  };

  section(138)//������
  {
    animation("Cike_Hit_02_03")
    {
      speed(1.2);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(1, true, 0.1, 0, 0, 20, 0, 0, 0);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12000203);
			stateimpact("kLauncher", 12000206);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0;)
		};
    //
    //��Ч
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_PuGong_02_003", 2000, "Bone_Root", 1);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_05", false);
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Voice_PuGong_04", false)
    {
	audiogroup("None", "None");
    };

    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true)
{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};
    //
    //��֡Ч��
    //lockframe(30, "Cike_Hit_01_02", true, 0.1, 100, 1, 100);
    //
    //����
    //shakecamera2(1, 400, false, true, vector3(0, 0, 1), vector3(0, 0, 400), vector3(0, 0, 0.1), vector3(0, 0, 100));
    //
    //���
    //addbreaksection(10, 1, 233);
  };

  section(388)//Ӳֱ
  {
    animation("Cike_Hit_02_04")
    {
      speed(1.2);
    };
    //
    //���
    addbreaksection(1, 99, 2000);
    addbreaksection(10, 100, 2000);
    addbreaksection(21, 100, 2000);
    addbreaksection(100, 100, 2000);
  };

  section(366)//����
  {
    animation("Cike_Hit_02_99")
    {
      speed(1);
    };
    //
  };
};
