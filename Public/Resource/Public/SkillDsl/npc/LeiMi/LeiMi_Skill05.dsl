
/****    ���� ��ת    ****/

skill(440501)
{
//////////     һ�׶�
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(166)//����
  {
    animation("Skill05_01_01");
    startcurvemove(100, true, 0.66, 0, 0, 15, 0, 0, 0);
  };

  section(366)//��һ��
  {
    animation("Skill05_01_02");
    //
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.1, 0, 15, 15, 0, 0, 0);
    startcurvemove(100, true, 0.1, 0, 6, 6, 0, 0, 0);
    startcurvemove(200, true, 0.1, 0, 2, 2, 0, 0, 0);
    startcurvemove(300, true, 0.06, 0, 1, 1, 0, 0, 0);
    //
    //�˺��ж�
    areadamage(0, 0, 1.5, 1, 2.2, true)
		{
			stateimpact("kDefault", 44010501);
		};
    areadamage(100, 0, 1.5, 1, 2.2, true)
		{
			stateimpact("kDefault", 44010501);
		};
    areadamage(200, 0, 1.5, 1, 2.2, true)
		{
			stateimpact("kDefault", 44010501);
		};
    //
    //��Ч
    charactereffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill05_01", 2000, "Bone_Root", 0);
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Npc/LeiMi/boss_LeiMi_ShanYao_01", false);
  };



//////////     ���׶�
  section(300)
  {
    animation("Skill05_02_01");
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.05, 0, 8, 0, 0, 0, 0);
    sceneeffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill05_02_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    areadamage(0, 0, 1.5, 0, 3.5, true)
    {
        stateimpact("kDefault", 12990000);
        stateimpact("kLauncher", 44010502);
    };
    playsound(10, "Hit2", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Npc/LeiMi/boss_LeiMi_ShanYao_02", false);
    //ģ����ʧ
    setenable(0, "Visible", false);
    //ģ����ʾ
    setenable(200, "Visible", true);
    //
  };
  section(300)
  {
    animation("Skill05_02_02");
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.05, 0, 8, 0, 0, 0, 0);
    sceneeffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill05_02_02", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    areadamage(0, 0, 1.5, 0, 3.5, true)
    {
        stateimpact("kDefault", 12990000);
        stateimpact("kLauncher", 44010502);
    };
    playsound(10, "Hit3", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Npc/LeiMi/boss_LeiMi_ShanYao_02", false);
    //ģ����ʧ
    setenable(0, "Visible", false);
    //ģ����ʾ
    setenable(200, "Visible", true);
    //
  };
  section(300)
  {
    animation("Skill05_02_03");
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.05, 0, 8, 0, 0, 0, 0);
    sceneeffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill05_02_03", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    areadamage(0, 0, 1.5, 0, 3.5, true)
    {
        stateimpact("kDefault", 12990000);
        stateimpact("kLauncher", 44010502);
    };
    playsound(10, "Hit4", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Npc/LeiMi/boss_LeiMi_ShanYao_02", false);
    //ģ����ʧ
    setenable(0, "Visible", false);
    //ģ����ʾ
    setenable(200, "Visible", true);
    //
  };
  section(300)

  {
    animation("Skill05_02_04");
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.05, 0, 8, 0, 0, 0, 0);
    sceneeffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill05_02_04", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    areadamage(0, 0, 1.5, 0, 3.5, true)
    {
        stateimpact("kDefault", 12990000);
        stateimpact("kLauncher", 44010502);
    };
    playsound(10, "Hit5", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Npc/LeiMi/boss_LeiMi_ShanYao_02", false);
    //ģ����ʧ
    setenable(0, "Visible", false);
    //ģ����ʾ
    setenable(200, "Visible", true);
    //
  };



//////////     ���׶�
  section(733)
  {
    animation("Skill05_03")
    {
        speed(1.5);
    };
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.1, 0, 8, 0, 0, 0, 0);
    charactereffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill05_03", 2000, "Bone_Root", 0);
  };

  section(400)
  {
    animation("Skill05_04")
    {
        speed(1.5);
    };
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.05, 0, 10, -12, 0, 0, 0);
    startcurvemove(50, true, 0.1, 0, 5, -6, 0, 0, 0);
    startcurvemove(150, true, 0.25, 0, 5, -6, 0, 0, 0);
    charactereffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill05_04", 2000, "Bone_Root", 0);
    sceneeffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill05_05", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    areadamage(0, 0, 1.5, 0, 3.5, true)
    {
        stateimpact("kLauncher", 44010503);
    };
    areadamage(150, 0, -5, 0, 3.5, true)
    {
        stateimpact("kDefault", 44010504);
    };
    //��Ƶ
    playsound(10, "Hit6", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Npc/LeiMi/boss_LeiMi_ShanYao_03", false);
  };

  section(833)
  {
    animation("Skill05_05");
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.8, 0, 5, 0, 0, -40, 0);
   sceneeffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill05_06", 3000, vector3(0, 0, 0), 700, eular(0, 0, 0), vector3(1, 1, 1), true);
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

