skill(160201)
{
	section(2100)
	{
		//ȫ�ֲ���
		addbreaksection(1, 1100, 2100);
		addbreaksection(10, 1100, 2100);
		addbreaksection(20, 0, 2100);
		addbreaksection(30, 1100, 2100);
		movecontrol(true);
		animation("zhankuang_fenglunzhan_01");
		movechild(0, "1_JianShi_w_01", "ef_rightweapon01");
		
		//֡6
		setanimspeed(200, "zhankuang_fenglunzhan_01", 3);
		
		//֡15
		setanimspeed(300, "zhankuang_fenglunzhan_01", 1);
		
		//֡17
		//setanimspeed(433, "zhankuang_fenglunzhan_01", 1);
		
		//֡23
		setanimspeed(566, "zhankuang_fenglunzhan_01", 0.5);

		//֡25
		setanimspeed(700, "zhankuang_fenglunzhan_01", 3);

		//֡34
		setanimspeed(800, "zhankuang_fenglunzhan_01", 1);
		//֡77
			
		playsound(250, "skill0201", "Sound/zhankuang/zhankuang_sound", 2000, "Sound/zhankuang/zhankuang_fenglunzhan_01", false);

		playsound(800, "skill0202", "Sound/zhankuang/zhankuang_sound", 2000, "Sound/zhankuang/zhankuang_fenglunzhan_02", false);
		playsound(750, "skill0203", "Sound/zhankuang/zhankuang_sound", 2000, "Sound/zhankuang/ZK_Voice_FengLunZhan_01", false);

		startcurvemove(200, true, 0.1, 0, 0, 5, 0, 0, 100, 0.03, 0, 0, 6, 0, 0, -80, 0.3, 0, 3, 0, 0, 30, 50, 0.1, 0, 3, 15, 0, -60, -120, 0.2, 0, -3, 10, 0, -300, -40);

		//sceneeffect("Hero_FX/5_zhankuang/5_hero_zhankuang_fenglunzhan_01",1000,vector3(0,0,0.5),233,eular(0,0,0),vector3(1,1,1),true);
	
		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_fenglunzhan_01_01",1000,"Bone_Root",200);

		areadamage(300, 0, 1, 1, 3, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16020102);
			stateimpact("kDefault", 16020101);
		};
	
		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_fenglunzhan_01_03",1000,"Bone_Root",766);

		areadamage(833, 0, 1, 1.5, 3, true) 
		{
			stateimpact("kDefault", 16020111);
			stateimpact("kLauncher", 16020112);
		};

		playsound(320, "hit0201", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/Cike/guaiwu_shouji_01", true)
		{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};

		playsound(850, "hit0202", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/Cike/guaiwu_shouji_01", true)
		{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};
		//shakecamera2(833, 200, false, true, vector3(0.3, 0.4, 0), vector3(40, 40, 0), vector3(12, 14, 0), vector3(80, 60, 0));
		//sceneeffect("Hero_FX/5_zhankuang/5_hero_zhankuang_fenglunzhan_01",1000,vector3(0,0,0),866,eular(0,0,0),vector3(1.3,1.3,1.3),true);
		sceneeffect("Hero_FX/5_zhankuang/5_hero_zhankuang_fenglunzhan_01_04",1000,vector3(0,0,2.3),866);
	};
	
	oninterrupt()
	{
		stopeffect(0);
	};
	
	onstop()
	{
		stopeffect(500);
	};
};

skill(160202)
{
	section(1800)
	{
		//ȫ�ֲ���
		addbreaksection(1, 1000, 1800);
		addbreaksection(10, 900, 1800);
		addbreaksection(20, 0, 1800);
		addbreaksection(30, 900, 1800);
		movecontrol(true);
		animation("zhankuang_fenglunzhan_03");
	
		//֡0
		setanimspeed(0, "zhankuang_fenglunzhan_03", 0.66);
		
		//֡2
		setanimspeed(100, "zhankuang_fenglunzhan_03", 1.8);
		
		//֡11
		setanimspeed(266, "zhankuang_fenglunzhan_03", 2);
		
		//֡21
		setanimspeed(433, "zhankuang_fenglunzhan_03", 2.33);

		//֡28
		setanimspeed(533, "zhankuang_fenglunzhan_03", 0.5);

		//֡30
		setanimspeed(666, "zhankuang_fenglunzhan_03", 3);

		//֡33
		setanimspeed(700, "zhankuang_fenglunzhan_03", 1);
		//֡81
				
		playsound(200, "skill0211", "Sound/zhankuang/zhankuang_sound", 2000, "Sound/zhankuang/zhankuang_fenglunzhan_03", false);
		playsound(50, "skill0212", "Sound/zhankuang/zhankuang_sound", 2000, "Sound/zhankuang/ZK_Voice_FengLunZhan_02", false);

		playsound(650, "skill0213", "Sound/zhankuang/zhankuang_sound", 2000, "Sound/zhankuang/zhankuang_fenglunzhan_NO.4_04_01", false);
		playsound(700, "skill0214", "Sound/zhankuang/zhankuang_sound", 2000, "Sound/zhankuang/ZK_Voice_FengLunZhan_03", false);

		startcurvemove(0, true, 0.57, 0, 10, 10, 0, -12, 0, 0.07, 0, -80, 30, 0, 0, 0);

		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_fenglunzhan_03_01",1000,"Bone_Root",133);
	
		colliderdamage(200, 350, true, true, 60, 5)
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16020202);
			stateimpact("kDefault", 16020201);
			bonecollider("hero/5_zhankuang/fenglunzhancollider","Bone_Root", true);
		};

		playsound(250, "hit02021", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/Cike/guaiwu_shouji_01", true)
		{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};
		playsound(350, "hit02022", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/Cike/guaiwu_shouji_01", true)
		{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};
		playsound(450, "hit02023", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/Cike/guaiwu_shouji_01", true)
		{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};

		sceneeffect("Hero_FX/5_zhankuang/5_hero_zhankuang_fenglunzhan_03_02",1000,vector3(0,0,1.8),700);
		areadamage(700, 0, 1.5, 1, 4, true) 
		{
			stateimpact("kLauncher", 16020212);
			stateimpact("kDefault", 16020211);
		};
		
		shakecamera2(700, 200, false, true, vector3(0.3, 0.4, 0), vector3(40, 40, 0), vector3(12, 14, 0), vector3(80, 60, 0));
	};

	
	oninterrupt()
	{
		stopeffect(0);
	};
	
	onstop()
	{
		stopeffect(500);
	};
};
