

/****    ���� �Ľ�    ****/

skill(120141)
{
  section(1)//��ʼ��
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
  };

  section(66)//����
  {
    animation("Cike_Skill01_01_01")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 15, 0, 0, 0);
    //
    //���
    playpartanimation(0, "CiBang_02", "Close");
  };

  section(566)//��һ��
  {
    animation("Cike_Skill01_01_02")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.566, 0, 10, 10, 0, -40, 0);
    //
    //�˺��ж�
    areadamage(30, 0, 1, 1, 2.2, true)
		{
			stateimpact("kDefault", 12010201);
			stateimpact("kKnockDown", 12990000);
			stateimpact("kLauncher", 12010202);
      //showtip(200, 0, 1, 0);
		};
    shakecamera2(40, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
    areadamage(130, 0, 1, 1, 2.2, true)
		{
			stateimpact("kDefault", 12010201);
			stateimpact("kKnockDown", 12990000);
			stateimpact("kLauncher", 12010202);
      //showtip(200, 0, 1, 0);
		};
    areadamage(230, 0, 1, 1, 2.2, true)
		{
			stateimpact("kDefault", 12010201);
			stateimpact("kKnockDown", 12990000);
			stateimpact("kLauncher", 12010202);
      //showtip(200, 0, 1, 0);
		};
    shakecamera2(240, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
    areadamage(330, 0, 1, 1, 2.2, true)
		{
			stateimpact("kDefault", 12010201);
			stateimpact("kKnockDown", 12990000);
			stateimpact("kLauncher", 12010202);
      //showtip(200, 0, 1, 0);
		};
    areadamage(430, 0, 1, 1, 2.2, true)
		{
			stateimpact("kDefault", 12010201);
			stateimpact("kKnockDown", 12990000);
			stateimpact("kLauncher", 12010202);
      //showtip(200, 0, 1, 0);
		};
    shakecamera2(440, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
    areadamage(530, 0, 1, 1, 2.2, true)
		{
			stateimpact("kDefault", 12010203);
			stateimpact("kKnockDown", 12990000);
			stateimpact("kLauncher", 12010204);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_TuZhanYiDuan_01", 500, "Bone_Root", 10);
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_TuZhanYiDuan_01_01", 500, "Bone_Root", 10);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_LuoDiYan_02", 3000, vector3(0, 0, 0), 500, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Skill01_TuZhan_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Voice_RenXuan_01", false)
    {
	    audiogroup("None",None");
    };

    playsound(500, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Skill01_TuZhan_04", false);
    //
    //��֡Ч��
    //lockframe(30, "Cike_Hit_01_02", true, 0.1, 100, 1, 100);
  };

  section(66)//Ӳֱ
  {
    animation("Cike_Skill01_01_03")
    {
      speed(1);
    };
    //
    //���
    addbreaksection(1, 66, 3000);
    addbreaksection(10, 66, 3000);
    addbreaksection(21, 66, 3000);
    addbreaksection(100, 66, 3000);
  };

  section(1)//����
  {
    animation("Cike_Skill01_01_99")
    {
      speed(1);
    };
    //
    //���
    //addbreaksection(10, 499, 900);
  };

  oninterrupt()
  {
		//movechild(0, "1_JianShi_w_01", "ef_rightweapon01");
    //���
    playpartanimation(0, "CiBang_02", "Idle", 2);
  };

  onstop()
  {
		//movechild(0, "1_JianShi_w_01", "ef_rightweapon01");
    //���
    playpartanimation(0, "CiBang_02", "Idle", 2);
  };
};
