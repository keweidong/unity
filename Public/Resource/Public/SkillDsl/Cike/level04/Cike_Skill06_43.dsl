

/****    ӰϮ���� �Ľ�    ****/

skill(120643)
{
  section(1)//��ʼ��
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //˲���෨�����
    addbreaksection(11, 1, 30000);
    //
    //findmovetarget(0, vector3(0, 0, 1), 10, 60, 0.1, 0.9, 0, 1);
  };

  section(200)//����
  {
    movecontrol(true);
    //
    //Ŀ��ѡ��
    findmovetarget(0, vector3(0, 0, 1), 10, 10, 0.1, 0.9, 0, -2.5);
    //
    animation("Cike_Skill13_02_01")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.1, 0, 0, 50, 0, 0, 0);
    //
    //�������Ӱ���buff
    addimpacttoself(1, 12990001, 500);
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

  section(866)//��һ��
  {
    animation("Cike_Skill13_02_02")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 25, 0, 0, -100);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12060301);
                                          stateimpact("kLauncher", 12060302);
			stateimpact("kKnockDown", 12060302);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenZhan_QianZhan_01", 500, "Bone_Root", 1);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenZhan_QianZhan_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenZhan_QianZhan_02", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Skill06_YingXi_02", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true)
    {
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
    };

    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Voice_YingXi_02", false);
    //
    //��֡Ч��
    //lockframe(30, "Cike_Hit_01_02", true, 0.1, 100, 1, 100);
    //
    //����
    //shakecamera2(1, 400, false, true, vector3(0, 0, 1), vector3(0, 0, 400), vector3(0, 0, 0.1), vector3(0, 0, 100));

    //���
    addbreaksection(1, 300, 2000);
    addbreaksection(10, 300, 2000);
    addbreaksection(21, 300, 2000);
    addbreaksection(100, 300, 2000);
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

