
/****    ���� ��ת    ****/

skill(440301)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(100)//����
  {
    animation("Skill03_01");
    {
        speed(2);
    }
  };

  section(533)//��һ��
  {
    animation("Skill03_02");
    //�˺��ж�
    areadamage(0, 0, 1.5, 0, 3.5, true)
		{
			stateimpact("kDefault", 44010301);
			stateimpact("kLauncher", 44010302);
		};
    areadamage(50, 0, 1.5, 0, 3.2, true)
		{
			stateimpact("kDefault", 44010301);
			stateimpact("kLauncher", 44010302);
		};
    areadamage(100, 0, 1.5, 0, 3.2, true)
		{
			stateimpact("kDefault", 44010301);
			stateimpact("kLauncher", 44010302);
		};
    areadamage(150, 0, 1.5, 0, 3.2, true)
		{
			stateimpact("kDefault", 44010301);
			stateimpact("kLauncher", 44010302);
		};
    areadamage(200, 0, 1.5, 0, 3.2, true)
		{
			stateimpact("kDefault", 44010301);
			stateimpact("kLauncher", 44010302);
		};
    areadamage(250, 0, 1.5, 0, 3.2, true)
		{
			stateimpact("kDefault", 44010301);
			stateimpact("kLauncher", 44010302);
		};
    areadamage(300, 0, 1.5, 0, 3.2, true)
		{
			stateimpact("kDefault", 44010301);
			stateimpact("kLauncher", 44010302);
		};
    areadamage(350, 0, 1.5, 0, 3.2, true)
		{
			stateimpact("kDefault", 44010301);
			stateimpact("kLauncher", 44010302);
		};
    areadamage(400, 0, 1.5, 0, 3.5, true)
		{
			stateimpact("kDefault", 44010303);
			stateimpact("kLauncher", 44010302);
		};

    charactereffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill03_01", 2000, "Bone_Root", 0);
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Npc/LeiMi/boss_LeiMi_XuanZhuan_01", false);
  };

  section(533)//����
  {
    animation("Skill03_03");
  };
};

