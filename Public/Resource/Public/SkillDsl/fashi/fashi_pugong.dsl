skill(130001)
{
	section(266)
	{
		addbreaksection(1, 400, 600);
		addbreaksection(10, 500, 600);
		addbreaksection(20, 0, 600);
		addbreaksection(30, 200, 300);
		addbreaksection(30, 500, 600);
		movecontrol(true);
		animation("fashi_pugong_01");
        //charactereffect("Hero_FX/6_Fashi/6_hero_fashi_pugong_youshou", 300, "ef_rightweapon01", 100, true);
		//findmovetarget(100, vector3(0, 0, 0), 3, 180, 0.8, 0.2, 0, -0.8);
		//startcurvemove(200, true, 0.05, 0, 0, 4, 0, 0, 80, 0.05, 0, 0, 8, 0, 0, -80);
		//֡1
		//setanimspeed(33, "fashi_pugong_01", 2);
		//֡3
		//setanimspeed(66, "fashi_pugong_01", 1);
        //  14
		//playsound(285, "skill0101", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/zhankuang/zhankuang_pugong_01_new", false);	
		//charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_pugong_01_01", 500, "Bone_Root", 285, false);
		areadamage(100, 0, 1.7, 1, 2.3, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16000102);
			stateimpact("kDefault", 16000101);
		};
		//playsound(300, "hit0001", "Sound/zhankuang/zhankuang_sound", 1500, "Sound/Cike/guaiwu_shouji_01", true)
		//{
		//	audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		//};   
	};
	section(333)
	{
		animation("fashi_pugong_02");
		//startcurvemove(200, true, 0.05, 0, 0, 0, 0, 0, 560, 0.05, 0, 0, 28, 0, 0, -500);
        //charactereffect("Hero_FX/6_Fashi/6_hero_fashi_pugong_zuoshou", 300, "ef_leftweapon01", 200, true);
        areadamage(133, 0, 1.7, 1, 2.3, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16000102);
			stateimpact("kDefault", 16000101);
		};
	};
	
	oninterrupt()
	{
		stopeffect(300);
	};
	
	onstop()
	{
		stopeffect(300);
	};
};

skill(130002)
{
	section(800)
	{
		addbreaksection(1, 400, 800);
		addbreaksection(10, 650, 800);
		addbreaksection(20, 0, 800);
		addbreaksection(30, 0, 200);
		addbreaksection(30, 400, 800);
		movecontrol(true);
		animation("fashi_pugong_03");
		//֡1
		setanimspeed(33, "fashi_pugong_03", 2);
		//֡7
		setanimspeed(133, "fashi_pugong_03", 1);
		//֡10
		setanimspeed(233, "fashi_pugong_03", 2);
		//֡20
		setanimspeed(400, "fashi_pugong_03", 1);
        //  30
		startcurvemove(33, true, 0.1, 0, 0, 0, 0, 0, 140, 0.1, 0, 0, 14, 0, 0, -120);
		startcurvemove(500, true, 0.1, 0, 0, 0, 0, 0, 140, 0.1, 0, 0, 14, 0, 0, -120);
        //charactereffect("Hero_FX/6_Fashi/6_hero_fashi_pugong_youshou", 500, "ef_rightweapon01", 200, true);
		areadamage(300, 0, 1.7, 1, 2.3, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16000202);
			stateimpact("kDefault", 16000201);
		};
	};
	oninterrupt()
	{
		stopeffect(300);
	};
	
	onstop()
	{
		stopeffect(300);
	};
};

skill(130003)
{
	section(1066)
	{
		addbreaksection(1, 900, 1266);
		addbreaksection(10, 1000, 1266);
		addbreaksection(20, 0, 1266);
		addbreaksection(30, 0, 650);
		addbreaksection(30, 800, 1266);
		movecontrol(true);
		animation("fashi_pugong_04");
		//֡1
		setanimspeed(33, "fashi_pugong_04", 0.5);
		//֡10
		setanimspeed(633, "fashi_pugong_04", 1);
        //  29
        //charactereffect("Hero_FX/6_Fashi/6_hero_fashi_pugong_houtui", 170, "ef_leftfoot_01", 0, true);
        //charactereffect("Hero_FX/6_Fashi/6_hero_fashi_pugong_youshou", 200, "ef_rightweapon01", 300, true);
		startcurvemove(0, true, 0.1, 0, 0, 0, 0, 0, -200, 0.1, 0, 0, -20, 0, 0, 100, 0.5, 0, 0, -10, 0, 0, 20);
		startcurvemove(700, true, 0.05, 0, 0, 100, 0, 0, 0);
        setcamerafollowspeed(0, 50, 0.5, 50, 2, 1);
        resetcamerafollowspeed(750);
        //movecamera(1350, false, 0.05, 0, -72, 72, 0, 0, 0);
        //setenable(1350,  "CameraFollow", false);
        //movecamera(1400, false, 0.1, 0, 24, -24, 0, 0, 0);
        //movecamera(1500, false, 0.2, 0, 6, -6, 0, 0, 0);
        //movecamera(1700, true, 0.2, 0, 10, 0, 0, 0, 0);
        //setenable(1900,  "CameraFollow", true);
		areadamage(750, 0, 1.7, 1, 2.3, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16000202);
			stateimpact("kDefault", 16000201);
		};
	};
	oninterrupt()
	{
		stopeffect(300);
        resetcamerafollowspeed(0);
	};

	onstop()
	{
		stopeffect(300);
        resetcamerafollowspeed(0);
	};
};

skill(130004)
{
	section(1166)
	{
		addbreaksection(1, 900, 1300);
		addbreaksection(10, 1000, 1300);
		addbreaksection(20, 0, 1300);
		addbreaksection(30, 0, 500);
		addbreaksection(30, 700, 1300);
		movecontrol(true);
		animation("fashi_pugong_05");
		//֡1
		setanimspeed(33, "fashi_pugong_05", 0.25);
		//֡4
		setanimspeed(433, "fashi_pugong_05", 2);
		//֡14
		setanimspeed(600, "fashi_pugong_05", 1);
        //  35
        //charactereffect("Hero_FX/6_Fashi/6_hero_fashi_pugong_zuoshou", 900, "ef_leftweapon01", 0, true);
		areadamage(600, 0, 1.7, 1, 2.3, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16000202);
			stateimpact("kDefault", 16000201);
		};
	};

	oninterrupt()
	{
		stopeffect(300);
	};
	
	onstop()
	{
		stopeffect(300);
	};
};