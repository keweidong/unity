

/****    ˲��Ӱɱ��һ��    ****/

skill(120741)
{
  section(1)//��ʼ��
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);

    destroysummonnpc(0);

    setuivisible(0, "SkillBar", true);

    //�������Ӱ���buff
    addimpacttoself(0, 12990003, 10000);
    addimpacttoself(0, 12990005, 10000);

		setuivisible(200, "SkillBar", false);
  };

  section(3500)//��һ��
  {

    ////////////     ��һ�� �ͷŽ׶�     //////////////


    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_EX_01", false);

    //���ֶ���
    animation("Cike_Skill07_01_01");
    //
    //��Ӷ���Ч��
    //timescale(0, 0.1, 10000);

    areadamage(50, 0, 0, 0, 40, true)
		{
			stateimpact("kDefault", 12070101);
      //showtip(200, 0, 1, 0);
		};

    //�ͷŶ�����Ч
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_baoqihuan", 3000, vector3(0, 0, 0), 50, eular(0, 0, 0), vector3(1, 1, 1), true);


    //��ͷ�ƶ� һ
    movecamera(0, true, 0.5, 0, 15, 0, 0, 0, 0);
    setenable(0,  "CameraFollow", false);
    //blackscene(0, "Hero/3_Cike/BlackScene", 0.5, 1000, 4500, 0, "Player", "Character", "Monster");
    //
    //��������ʱ��
    oninput(200, 3000, 200, 7, 7, "ontouch", "onrequire_touch");



    ////////////     �ڶ��� ���߽׶�     //////////////
    //
    //�ٻ�Ӱ�ӽ��д���
    //summonnpc(3200, 101, "Hero/3_Cike/3_Cike_02", 125402, vector3(0, 0, 0));



    //setenable(6000,  "CameraFollow", true);



    //movecamera(5000, true, 0.5, 0, -15, 0, 0, 0, 0);
    //setenable(5000,  "CameraFollow", false);
    //movecamera(15000, true, 0.5, 0, 15, 0, 0, 0, 0);
  };

  section(7000)
  {
    //blackscene(0, "Hero/3_Cike/BlackScene", 1, 500, 8000, 0, "Player", "Character", "Monster");
    cullingmask(0,8000,"Monster","Player","Character");
    skyboxmaterial(0, 7000, "");
    //
    //������
   animation("Cike_Skill07_02_01", 0);
   animation("Cike_Skill07_02_02", 1300);
    //
    //���浱ǰ���λ��
    storepos(0);
    //
    //ģ����ʧ
    setenable(800, "Visible", false);
    //ģ����ʾ
    setenable(1300, "Visible", true);
    //
    //��Ч
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_ShunShen_01", 3000, vector3(0, 0, 0), 750, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��ײ��
    colliderdamage(100, 3100, true, true, 0, 1)
    {
      stateimpact("kDefault", 12070201);
      sceneboxcollider(vector3(2, 2, 2), vector3(0, 0, 0), eular(0, 0, 0), true, false);
    };
    //���д��󹥻�
    // ����1 //
    crosssummonmove(1400, false, -1, 0, 50);
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_Xian_02", 3000, "Bone_Root", 1450);
    //����
    playsound(1400, "Hit01", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_EX_08", false);
    //ģ����ʧ
    setenable(1500, "Visible", false);
    //ģ����ʾ
    setenable(1600, "Visible", true);

    // ����2 //
    crosssummonmove(1700, false, 0, 1, 50);
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_Xian_02", 3000, "Bone_Root", 1750);
    //����
    playsound(1700, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_EX_09", false);
    //ģ����ʧ
    setenable(1800, "Visible", false);
    //ģ����ʾ
    setenable(1900, "Visible", true);

    // ����3 //
    crosssummonmove(2100, false, 1, 2, 50);
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_Xian_02", 3000, "Bone_Root", 2150);
    //����
    playsound(2100, "Hit03", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_EX_10", false);
    //ģ����ʧ
    setenable(2200, "Visible", false);
    //ģ����ʾ
    setenable(2300, "Visible", true);

    // ����4 //
    crosssummonmove(2400, false, 2, 3, 50);
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_Xian_02", 3000, "Bone_Root", 2450);
    //����
    playsound(2400, "Hit04", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_EX_08", false);
    //ģ����ʧ
    setenable(2500, "Visible", false);
    //ģ����ʾ
    setenable(2600, "Visible", true);

    // ����5 //
    crosssummonmove(2600, false, 3, 4, 50);
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_Xian_02", 3000, "Bone_Root", 2650);
    //����
    playsound(2600, "Hit05", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_EX_09", false);
    //ģ����ʧ
    setenable(2700, "Visible", false);
    //ģ����ʾ
    setenable(2800, "Visible", true);

    // ����6 //
    crosssummonmove(2800, false, 4, 5, 50);
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_Xian_02", 3000, "Bone_Root", 2850);
    //����
    playsound(2800, "Hit06", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_EX_10", false);
    //ģ����ʧ
    setenable(2900, "Visible", false);
    //ģ����ʾ
    setenable(3000, "Visible", true);

    // ����7 //
    crosssummonmove(3000, false, 5, 6, 50);
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_Xian_02", 3000, "Bone_Root", 3050);
    //����
    playsound(3000, "Hit07", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_EX_08", false);


    //������Ч
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_ShunShen_01", 3000, vector3(0, 0, 0), 3130, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_ShunShen_01", 3000, vector3(0, 0, 0), 4010, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //���͵���ǰλ��
    restorepos(3150);

   //ģ����ʧ
    setenable(3150, "Visible", false);
    //ģ����ʾ
    setenable(3800, "Visible", true);

    animation("Cike_Skill07_03_01", 3800);

    //�������Ч
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_FaZhen_02", 3000, vector3(0, 0, 0), 4750, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_EX_baoqihuan_02", 3000, vector3(0, 0, 0), 6280, eular(0, 0, 0), vector3(1, 1, 1), true);
    //����
    playsound(4750, "Hit08", "Sound/Cike/CikeSkillSound01", 5000, "Sound/Cike/Cike_EX_12", false);

    ///////////////////////////
    //
    //�����ܻ�
    areadamage(4800, 0, 0, 0, 20, true)
		{
			stateimpact("kLauncher", 12070301);
      //showtip(200, 0, 1, 0);
		};
    areadamage(4900, 0, 0, 0, 20, true)
		{
			stateimpact("kLauncher", 12070301);
      //showtip(200, 0, 1, 0);
		};
    areadamage(5000, 0, 0, 0, 20, true)
		{
			stateimpact("kLauncher", 12070301);
      //showtip(200, 0, 1, 0);
		};
    areadamage(5100, 0, 0, 0, 20, true)
		{
			stateimpact("kLauncher", 12070301);
      //showtip(200, 0, 1, 0);
		};
    areadamage(5200, 0, 0, 0, 20, true)
		{
			stateimpact("kLauncher", 12070301);
      //showtip(200, 0, 1, 0);
		};
    areadamage(5300, 0, 0, 0, 20, true)
		{
			stateimpact("kLauncher", 12070301);
      //showtip(200, 0, 1, 0);
		};
    areadamage(5400, 0, 0, 0, 20, true)
		{
			stateimpact("kLauncher", 12070301);
      //showtip(200, 0, 1, 0);
		};
    areadamage(5600, 0, 0, 0, 20, true)
		{
			stateimpact("kLauncher", 12070301);
      //showtip(200, 0, 1, 0);
		};
    areadamage(5700, 0, 0, 0, 20, true)
		{
			stateimpact("kLauncher", 12070301);
      //showtip(200, 0, 1, 0);
		};
    areadamage(6300, 0, 0, 0, 20, true)
    {
			stateimpact("kDefault", 12070302);
      //showtip(200, 0, 1, 0);
    };

    //�����ٻ���
    destroysummonnpc(6400);
    //
    animation("Cike_Skill07_03_02", 5700);
    movecamera(6300, true, 0.5, 0, -15, 0, 0, 0, 0);

		setuivisible(6900, "SkillBar", true);
  };

  onmessage("ontouch")
  {
    summonnpc(0, 102, "Hero/3_Cike/3_Cike_02", 125401, vector3(0, 0, 0));
  };

  onmessage("onrequire_touch")
  {
    summonnpc(0, 102, "Hero/3_Cike/3_Cike_02", 125403, vector3(0, 0, 0));
  };

  oninterrupt()
	{
    setenable(0,  "CameraFollow", true);
    setuivisible(0, "SkillBar", true);
    setenable(0, "Visible", true);
		setuivisible(0, "SkillBar", true);
	};

	onstop()
	{
    setenable(0,  "CameraFollow", true);
    setuivisible(0, "SkillBar", true);
    setenable(0, "Visible", true);
		setuivisible(0, "SkillBar", true);
	};
};
