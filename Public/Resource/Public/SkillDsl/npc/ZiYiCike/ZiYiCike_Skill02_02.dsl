

/****    �����ػ�    ****/

skill(430202)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
    addimpacttoself(0, 12990001, 1000);
  };

  section(566)//����
  {
    animation("Skill02_02_01")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 12, 0, 0, 0);
  };

  section(833)//��һ��
  {
    animation("Skill02_02_02")
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
			stateimpact("kDefault", 43020201);
			stateimpact("kLauncher", 43020201);
			stateimpact("kKnockDown", 43020201);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    charactereffect("Monster_FX/ZiYiCiKe/3_Hero_ZiYiCiKe_ZhongJi_01", 500, "Bone_Root", 1);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_04", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

};
