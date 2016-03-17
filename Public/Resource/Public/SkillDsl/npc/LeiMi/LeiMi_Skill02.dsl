

/****    ���� С��    ****/

skill(440201)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(300)//����
  {
    animation("Skill02_01");
  };

  section(200)//��һ��
  {
    animation("Skill02_02");
    //
    //ģ����ʧ
    setenable(30, "Visible", false);
    //
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.2, 0, 0, 20, 0, 0, 0);
    //
    //�ٻ�NPC  �������ӳ��˺�
    summonnpc(0, 101, "Hero/3_Cike/None", 4402011, vector3(0, 0, 0));
    summonnpc(150, 101, "Hero/3_Cike/None", 4402011, vector3(0, 0, 0));
    //
    //��Ч
    sceneeffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill02_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Npc/LeiMi/boss_LeiMi_XiaoChong_01", false);
  };

  section(600)//����
  {
    settransform(0, " ", vector3(0, 0, 0), eular(0, 180, 0), "RelativeSelf", true);
    setenable(30, "Visible", true);
    animation("Skill02_03")
    {
        speed(2);
    };
    //��Ч
    sceneeffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill02_03", 3000, vector3(0, 0, 0), 60, eular(0, 0, 0), vector3(1, 1, 1), true);
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.4, 0, 0, -20, 0, 0, 50);
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


skill(4402011)
{
  section(450)
  {
    movecontrol(true);
    //
    //�趨����Ϊʩ���߷���
    settransform(0," ",vector3(0,0,0),eular(0,0,0),"RelativeOwner",false);
    //
    //�˺��ж�
    areadamage(30, 0, 1, 0, 2.4, true)
		{
			stateimpact("kDefault", 44010201);
      //showtip(200, 0, 1, 1);
		};
    areadamage(90, 0, 1, 0, 2.4, true)
		{
			stateimpact("kDefault", 44010201);
		};
    areadamage(150, 0, 1, 0, 2.4, true)
		{
			stateimpact("kDefault", 44010201);
		};
    areadamage(210, 0, 1, 0, 2.4, true)
		{
			stateimpact("kDefault", 44010201);
		};
    areadamage(210, 0, 1, 0, 2.4, true)
		{
			stateimpact("kDefault", 44010201);
		};
    areadamage(330, 0, 1, 0, 2.4, true)
		{
			stateimpact("kDefault", 44010201);
		};
    areadamage(390, 0, 1, 0, 2.4, true)
		{
			stateimpact("kDefault", 44010201);
		};
    areadamage(420, 0, 1, 0, 2.4, true)
		{
			stateimpact("kDefault", 44010201);
		};
    //��Ч
    sceneeffect("Monster_FX/LeiMi/6_Mon_LeiMi_Skill02_02", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
  };
};
