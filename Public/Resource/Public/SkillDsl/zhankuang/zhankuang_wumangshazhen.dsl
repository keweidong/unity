skill(161301)
{
	section(333)
	{
		//ȫ�ֲ���
		
		movechild(0, "1_JianShi_w_01", "ef_rightweapon01");
		movecontrol(true);
		animation("zhankuang_wumangshazhen_01");

		settransform(10, " ", vector3(0, 0, 0), eular(0, -180, 0), "RelativeSelf", true);

		//֡1
		setanimspeed(33, "zhankuang_wumangshazhen_01", 5);
		
		//֡26
		setanimspeed(200, "zhankuang_wumangshazhen_01", 3);
		
		//֡35
		setanimspeed(300, "zhankuang_wumangshazhen_01", 2);
		//֡45

		areadamage(266, 0, 0, -3, 2.5, true) 
		{
			stateimpact("kLauncher", 16000000);
			stateimpact("kDefault", 16130101);
		};

		sceneeffect("Hero_FX/5_zhankuang/5_hero_zhankuang_wumangshazhen_03",1500,vector3(0,0,-3),266);
	};
	section(133)
	{
		animation("zhankuang_wumangshazhen_02");

		settransform(0, " ", vector3(0, 0, 0), eular(0, -144, 0), "RelativeSelf", true);
		
		//֡1
		setanimspeed(33, "zhankuang_wumangshazhen_02", 3);

		//֡10
		setanimspeed(133, "zhankuang_wumangshazhen_02", 2);
		//֡30

		areadamage(100, 0, 0, -3, 2.5, true) 
		{
			stateimpact("kLauncher", 16000000);
			stateimpact("kDefault", 16130102);
		};
		playsound(100, "skill1301", "Sound/zhankuang/zhankuang_sound", 2000, "Sound/zhankuang/zhankuang_wumangshazhen_01", false);
		
		sceneeffect("Hero_FX/5_zhankuang/5_hero_zhankuang_wumangshazhen_03",1000,vector3(0,0,-3),100);
	};
	section(133)
	{
		animation("zhankuang_wumangshazhen_02");

		settransform(0, " ", vector3(0, 0, 0), eular(0, -144, 0), "RelativeSelf", true);
		
		//֡1
		setanimspeed(33, "zhankuang_wumangshazhen_02", 3);

		//֡10
		setanimspeed(133, "zhankuang_wumangshazhen_02", 2);
		//֡30
		
		areadamage(100, 0, 0, -3, 2.5, true) 
		{
			stateimpact("kLauncher", 16000000);
			stateimpact("kDefault", 16130103);
		};

		sceneeffect("Hero_FX/5_zhankuang/5_hero_zhankuang_wumangshazhen_03",1000,vector3(0,0,-3),100);
	};
	section(133)
	{
		animation("zhankuang_wumangshazhen_02");

		settransform(0, " ", vector3(0, 0, 0), eular(0, -144, 0), "RelativeSelf", true);
		
		//֡1
		setanimspeed(33, "zhankuang_wumangshazhen_02", 3);

		//֡10
		setanimspeed(133, "zhankuang_wumangshazhen_02", 2);
		//֡30
		
		areadamage(100, 0, 0, -3, 2.5, true) 
		{
			stateimpact("kLauncher", 16000000);
			stateimpact("kDefault", 16130104);
		};

		sceneeffect("Hero_FX/5_zhankuang/5_hero_zhankuang_wumangshazhen_03",1000,vector3(0,0,-3),100);
	};
	section(166)
	{
		animation("zhankuang_wumangshazhen_02");

		settransform(0, " ", vector3(0, 0, 0), eular(0, -144, 0), "RelativeSelf", true);
		
		//֡1
		setanimspeed(33, "zhankuang_wumangshazhen_02", 3);

		//֡10
		setanimspeed(133, "zhankuang_wumangshazhen_02", 1);
		//֡30
		
		areadamage(100, 0, 0, -3, 2.5, true) 
		{
			stateimpact("kLauncher", 16000000);
			stateimpact("kDefault", 16130105);
		};

		sceneeffect("Hero_FX/5_zhankuang/5_hero_zhankuang_wumangshazhen_03",1000,vector3(0,0,-3),100);
	};
	section(1000)
	{
		animation("zhankuang_fengkuanglianzhan_01");

		settransform(0, " ", vector3(0, 0, 0), eular(0, 36, 0), "RelativeSelf", true);
		
		//֡1
		setanimspeed(33, "zhankuang_fengkuanglianzhan_01", 0.25);

		//֡4
		setanimspeed(433, "zhankuang_fengkuanglianzhan_01", 2);
		
		//֡8
		setanimspeed(500, "zhankuang_fengkuanglianzhan_01", 0.5);

		//֡10
		setanimspeed(666, "zhankuang_fengkuanglianzhan_01", 1);
		//֡22

		areadamage(500, 0, 0, 0, 5, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kDefault", 16130106);
		};

		playsound(500, "skill1302", "Sound/zhankuang/zhankuang_sound", 2000, "Sound/zhankuang/zhankuang_wumangshazhen_02", false);
		
		sceneeffect("Hero_FX/5_zhankuang/5_Hero_zhankuang_wumangshazhen_02_01",1000,vector3(0,0,0),550,eular(0,0,0));
		sceneeffect("Hero_FX/5_zhankuang/5_Hero_zhankuang_wumangshazhen_02_01",1000,vector3(0,0,0),550,eular(0,72,0));
		sceneeffect("Hero_FX/5_zhankuang/5_Hero_zhankuang_wumangshazhen_02_01",1000,vector3(0,0,0),550,eular(0,144,0));
		sceneeffect("Hero_FX/5_zhankuang/5_Hero_zhankuang_wumangshazhen_02_01",1000,vector3(0,0,0),550,eular(0,216,0));
		sceneeffect("Hero_FX/5_zhankuang/5_Hero_zhankuang_wumangshazhen_02_01",1000,vector3(0,0,0),550,eular(0,288,0));

		sceneeffect("Hero_FX/5_zhankuang/5_Hero_zhankuang_wumangshazhen_02_02",1000,vector3(0,0,0),500);
	};

	oninterrupt()
	{
	};

	onstop()
	{
	};
};
