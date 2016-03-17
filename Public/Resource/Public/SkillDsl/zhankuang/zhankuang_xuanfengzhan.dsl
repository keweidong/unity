skill(160101)
{
	section(1200)
	{
		//ȫ�ֲ���
		addbreaksection(1, 900, 1200);
		addbreaksection(10, 900, 1200);
		addbreaksection(20, 0, 1200);
		addbreaksection(30, 900, 1200);
		movecontrol(true);
		animation("zhankuang_xuanfengzhan_01");
		movechild(0, "1_JianShi_w_01", "ef_rightweapon01");

		startcurvemove(100, true, 0.1, 0, 0, 30, 0, 0, -100, 0.05, 0, 0, 5, 0, 0, 0, 0.05, 0, 0, 30, 0, 0, -100, 0.15, 0, 0, 5, 0, 0, 0, 0.10, 0, 0, 0, 0, 0, 0, 0.05, 0, 0, 40, 0, 0, -100);
		
		//֡3
		setanimspeed(100, "zhankuang_xuanfengzhan_01", 2.5);

		//֡8
		setanimspeed(166, "zhankuang_xuanfengzhan_01", 1);
		
		//֡10
		setanimspeed(233, "zhankuang_xuanfengzhan_01", 2.5);
		
		//֡15
		setanimspeed(300, "zhankuang_xuanfengzhan_01", 1);

		//֡17
		setanimspeed(366, "zhankuang_xuanfengzhan_01", 0.5);

		//֡20
		setanimspeed(566, "zhankuang_xuanfengzhan_01", 3.5);

		//֡27
		setanimspeed(633, "zhankuang_xuanfengzhan_01", 1);

		//֡36
		setanimspeed(933, "zhankuang_xuanfengzhan_01", 0.2);
		//֡38
		
		playsound(250, "skill0101", "Sound/zhankuang/zhankuang_sound", 2000, "Sound/zhankuang/zhankuang_xuanfengzhan_01", false);
		playsound(540, "skill0102", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/zhankuang/ZK_Voice_XuanFengZhan_02", false);
		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_xuanfengzhan_01_01",1000,"Bone_Root",110);
		areadamage(110, 0, 1, 0, 3, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16010102);
			stateimpact("kDefault", 16010101);
		};
		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_xuanfengzhan_01_02",1000,"Bone_Root",300);
		areadamage(300, 0, 1, 0, 3, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16010112);
			stateimpact("kDefault", 16010111);
		};
		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_xuanfengzhan_01_03",1000,"Bone_Root",566);
		areadamage(566, 0, 1, 0, 3, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16010122);
			stateimpact("kDefault", 16010121);
		};
		playsound(120, "skill0103", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/Cike/guaiwu_shouji_01", true)
		{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};
		playsound(310, "skill0104", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/Cike/guaiwu_shouji_01", true)
		{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};
		playsound(580, "skill0105", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/Cike/guaiwu_shouji_01", true)
		{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};
		//shakecamera2(600, 160, false, true, vector3(0.3, 0.4, 0), vector3(40, 40, 0), vector3(12, 14, 0), vector3(80, 60, 0));
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

skill(160102)
{	
	section(133)
	{
		//ȫ�ֲ���
		movechild(0, "1_JianShi_w_01", "ef_rightweapon01");
		movecontrol(true);
		animation("zhankuang_dafengche_01");
		
		//startcurvemove(350, true, 0.1, 0, 0, 0, 0, 0, 900, 0.2, 0, 0, 15, 0, 0, -75);

		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_dafengche_01",5000,"Bone_Root",100);

	};
	section(3990)
	{
		//ȫ�ֲ���
		
		enablechangedir(0, 3990);
		animation("zhankuang_dafengche_02")
		{
			wrapmode(2);
		};
		playsound(0, "skill0111", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/zhankuang/ZK_Voice_XuanFengZhan_03", false);
		playsound(0, "skill0112", "Sound/zhankuang/zhankuang_sound", 5500, "Sound/zhankuang/zhankuang_xuanfengzhan_02", false);
		playsound(3980, "skill0113", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/zhankuang/ZK_Voice_XuanFengZhan_04", false);
		setanimspeed(200, "zhankuang_dafengche_02", 2);
		setanimspeed(3300, "zhankuang_dafengche_02", 1.66);
		setanimspeed(3540, "zhankuang_dafengche_02", 1.33);
		startcurvemove(0, false, 4, 0, 0, 12, 0, 0, 0);
		colliderdamage(0, 3800, true, true, 100, 30)
		{
			stateimpact("kDefault", 16010301);
			bonecollider("hero/5_zhankuang/dafengchecollider","Bone_Root", true);
		};
		playsound(3990, "hit01021", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/Cike/guaiwu_shouji_01", true)
		{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};
		areadamage(3980, 0, 1, 0, 4, true) 
		{
			stateimpact("kKnockDown", 16000000);
			stateimpact("kLauncher", 16010212);
			stateimpact("kDefault", 16010211);
		};
		playsound(3990, "hit01022", "Sound/zhankuang/zhankuang_sound", 1000, "Sound/Cike/guaiwu_shouji_01", true)
		{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		};
		charactereffect("Hero_FX/5_zhankuang/5_hero_zhankuang_dafengche_02",1000,"Bone_Root",3900);
	};
	section(500)
	{
		//֡1
		//setanimspeed(33, "zhankuang_xuanfengzhan_01", 3);
		//֡7
		//setanimspeed(100, "zhankuang_xuanfengzhan_01", 1);
		animation("zhankuang_dafengche_03");
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