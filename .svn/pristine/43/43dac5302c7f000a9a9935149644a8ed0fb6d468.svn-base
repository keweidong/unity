skill(161501)
{
	section(6000)
	{
		//ȫ�ֲ���
		addbreaksection(1, 5600, 6000);
		addbreaksection(10, 5600, 6000);
		addbreaksection(20, 5600, 6000);
		addbreaksection(30, 5600, 6000);
		movecontrol(true);

		addimpacttoself(0, 16150199);
		addimpacttoself(0, 16150198);
		addimpacttoself(0, 16150197);
		
		setuivisible(200, "SkillBar", false);
		setuivisible(5100, "SkillBar", true);

		storepos(0);

		settransform(1, "", vector3(0, 0, 0), eular(0, 0, 0), "RelativeWorld", false);

		restorepos(2);

		timescale(0, 0.5, 300);

		movecamera(0, true, 0.1, 0, 100, 100, 0, -2000, -2000, 0.1, 0, -100, -100, 0, 400, 400);

		movecamera(200, false, 0.1, 0, 10, 80, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0);
		skyboxmaterial(0, 5900, "");
		//rotatecamera(0, 200, vector3(-215, 0, 0));

		//rotatecamera(200, 5000, vector3(0, 0, 0));

		cullingmask(0,5700,"Monster","Player");

		areadamage(0, 0, 0, 0, 50, true) 
		{
			stateimpact("kDefault", 16150101);
		};
		playsound(0, "skill1501", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/zhankuang/WeiYiPuGong", false);
		sceneeffect("Hero_FX/1_JianShi/1_Hero_JianShi_ChaoDa_01",1500,vector3(0,0,0),0);

		oncross(300, 4900, 100)
		{
			stateimpact("kDefault", 16150102);
			message("loop", false, "ExLeft", 100, "ExRight", 100, "ExLeft2", 100, "ExRight2", 100);
		};

		sceneeffect("Hero_FX/1_JianShi/1_Hero_JianShi_ChaoDa_01",1000,vector3(0,2,0),5200);

		areadamage(5200, 0, 4, 0, 20, true) 
		{
			stateimpact("kDefault", 16150103);
		};

		sceneeffect("Hero_FX/1_JianShi/1_Hero_JianShi_ChaoDa_03",10000,vector3(0,14,0),5500);
	};

	onmessage("ExLeft")
	{
		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_ex_01_01", 1500, "Bone_Root", 0, false);
		animation("zhankuang_fengkuanglianzhan_02");	
		//֡1
		setanimspeed(33, "zhankuang_fengkuanglianzhan_02", 3);

		//֡10
		setanimspeed(133, "zhankuang_fengkuanglianzhan_02", 0.1);
		//֡11
		playsound(50, "skill1521", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/zhankuang/zhankuang_pugong_01_new", false);	
		playsound(0, "skill1522", "Sound/zhankuang/zhankuang_sound", 1500, "Sound/zhankuang/ZK_Voice_EX_01", false); 
	};

	onmessage("ExRight")
	{
		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_ex_01_02", 1500, "Bone_Root", 0, false);
		animation("zhankuang_fengkuanglianzhan_03");
		//֡1
		setanimspeed(33, "zhankuang_fengkuanglianzhan_03", 3.5);
		
		//֡8
		setanimspeed(100, "zhankuang_fengkuanglianzhan_03", 0.1);

		//֡9
		playsound(50, "skill1531", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/zhankuang/zhankuang_pugong_02", false);
		playsound(0, "skill1532", "Sound/zhankuang/zhankuang_sound", 1500, "Sound/zhankuang/ZK_Voice_EX_02", false); 
	};

	onmessage("ExLeft2")
	{
		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_ex_01_05", 1500, "Bone_Root", 0, false);
		animation("zhankuang_fengkuanglianzhan_05");
		//֡1
		setanimspeed(33, "zhankuang_fengkuanglianzhan_05", 3);
		
		//֡4
		setanimspeed(66, "zhankuang_fengkuanglianzhan_05", 1);
		
		//֡5
		setanimspeed(100, "zhankuang_fengkuanglianzhan_05", 4);

		//֡9
		setanimspeed(133, "zhankuang_fengkuanglianzhan_05", 0.1);
		//֡10
		playsound(50, "skill1541", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/zhankuang/zhankuang_pugong_03", false);
		playsound(0, "skill1542", "Sound/zhankuang/zhankuang_sound", 1500, "Sound/zhankuang/ZK_Voice_EX_03", false); 
	};

	onmessage("ExRight2")
	{
		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_ex_01_04", 1500, "Bone_Root", 0, false);
		animation("zhankuang_fengkuanglianzhan_06");
		//֡1
		setanimspeed(33, "zhankuang_fengkuanglianzhan_06", 2);
		
		//֡3
		setanimspeed(66, "zhankuang_fengkuanglianzhan_06", 3);

		//֡9
		setanimspeed(133, "zhankuang_fengkuanglianzhan_06", 0.1);
		//֡11
		playsound(50, "skill1551", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/zhankuang/zhankuang_pugong_04", false);
		playsound(0, "skill1552", "Sound/zhankuang/zhankuang_sound", 1500, "Sound/zhankuang/ZK_Voice_EX_04", false); 
	};

	oninterrupt()
	{
        resetcamerafollowspeed(0);
	};

	onstop()
	{
        resetcamerafollowspeed(0);
	};
};
