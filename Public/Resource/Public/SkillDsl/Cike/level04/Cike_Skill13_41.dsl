

/****    �� �Ľ�    ****/

skill(121341)
{
  section(1)//��ʼ��    0
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //���
    addbreaksection(0, 500, 30000);
  };

  section(1)//����    1
  {
/*
    animation("Cike_Skill13_01_01")
    {
      speed(4);
    };
*/
    //
    //�������Ӱ���buff
    addimpacttoself(1, 12990001, 2000);
    addimpacttoself(1, 12990003, 2000);
  };

  section(30000)//��һ��    2
  {
    animation("Cike_Skill13_01_02")
    {
      speed(1);
    };
    //
    //�ܻ����
    parrycheck(0,500,0,"onparry1", "onparry1", true);
    //
    //�ܻ����
    parrycheck(500,30000,0,"onparry2", "onparryFalse", true);
    //
    //��Ч
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_GeDang_01", 30000, "Bone_Root", 1);
    //
    //��Ч
    //playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Call_01", false);
    //
    //��ת
     gotosection(29900, 6, 1);
  };


//////////     ����     ////////////

  section(200)//����    3
  {
    movecontrol(true);
    removebreaksection(0);
    stopeffect(0);
    //
    //Ŀ��ѡ��
    findmovetarget(0, vector3(0, 0, 1), 10, 60, 0.1, 0.9, 0, -3);
    //
    animation("Cike_Skill13_02_01")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.1, 0, 0, 20, 0, 0, 0);
    //
    //�������Ӱ���buff
    addimpacttoself(1, 12990001, 1000);
    addimpacttoself(1, 12990003, 1000);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //ģ����ʧ
    setenable(10, "Visible", false);
    //ģ����ʾ
    setenable(150, "Visible", true);
    //
  };

  section(866)//��һ��    4
  {
    animation("Cike_Skill13_02_02")
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
			stateimpact("kDefault", 12130101);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenZhan_QianZhan_01", 500, "Bone_Root", 1);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenZhan_QianZhan_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenZhan_QianZhan_02", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Skill05_ShunShenZhan_01", false);
    playsound(10, "Hit01", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
    //playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Call_01", false);
    //
    //��֡Ч��
    //lockframe(30, "Cike_Hit_01_02", true, 0.1, 100, 1, 100);
    //
    //����
    //shakecamera2(1, 400, false, true, vector3(0, 0, 1), vector3(0, 0, 400), vector3(0, 0, 0.1), vector3(0, 0, 100));
    //
    //��ת
     gotosection(860, 6, 1);
  };

/////////////////////

  section(1100)//����Ӳֱ    5
  {
    stopeffect(0);
    animation("Cike_Skill13_01_05");
  };

//////////////////////

  section(1)//����    6
  {
    movecontrol(true);
  };

//////////////////////

  onmessage("onparry1")
  {
        gotosection(0, 3, 1);
  };

  onmessage("onparry2")
  {
       facetoattacker(0,2000);
       animation("Cike_Skill13_01_04");
  };

  onmessage("onparryFalse")
  {
       facetoattacker(0,2000);
       gotosection(0, 5, 1);
  };

  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
        setenable(0, "Visible", true);
        setcross2othertime(0, "stand", 200);
        stopeffect(0);
  };

  onstop() //������������ʱ�����иö��߼�
  {
        setenable(0, "Visible", true);
        setcross2othertime(0, "stand", 200);
        stopeffect(0);
  };
};
