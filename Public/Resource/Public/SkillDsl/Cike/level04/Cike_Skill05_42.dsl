

/****    ˲��ն ��ն �Ľ�    ****/

skill(120542)
{
  section(1)//��ʼ��
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
  };

  section(156)//����
  {
    animation("Cike_Skill05_02_01")
    {
      speed(1.5);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.156, 0, 0, 20, 0, 0, 0);
    //
    //�������Ӱ���buff
    addimpacttoself(1, 12990001, 500);
    //
    //��Ч
    //sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //ģ����ʧ
    setenable(90, "Visible", false);
    //ģ����ʾ
    //setenable(140, "Visible", true);
    //
  };

   section(90)//���ֶ���
  {
    animation("Cike_Skill05_02_02")
    {
      speed(1.5);
    };
    //
    //��Ч
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiXian_01", 3000, vector3(0, 0, 0), 60, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.15, 0, 0, -20, 0, 0, 0);
    //
    //����
    settransform(0, " ", vector3(0, 0, 0), eular(0, 180, 0), "RelativeSelf", true);
    //
    //ģ����ʧ
    //setenable(60, "Visible", false);
    //ģ����ʾ
    setenable(80, "Visible", true);
    //
  };

  section(133)//��һ��
  {
    animation("Cike_Skill05_02_03")
    {
      speed(1);
    };
    //
    //����
    //settransform(0, " ", vector3(0, 0, 0), eular(0, 180, 0), "RelativeSelf", true);
    //
     //��ɫ�ƶ�
    //startcurvemove(0, true, 0.15, 0, 0, 20, 0, 0, -100);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12050201);
			stateimpact("kLauncher", 12050202);
			stateimpact("kKnockDown", 12990000);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenZhan_HouZhan_01", 500, "Bone_Root", 1);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenZhan_HouZhan_01", 3000, vector3(0, 0, 0), 30, eular(0, 0, 0), vector3(1, 1, 1), true);
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenZhan_HouZhan_02", 500, "Bone_Root", 1);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShunShenZhan_HouZhan_02", 3000, vector3(0, 0, 0), 30, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Skill05_ShunShenZhan_02", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true)
{
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
		}; 
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Voice_ShunShenZhan_04", false);
    //
    //��֡Ч��
    //lockframe(30, "Cike_Hit_01_02", true, 0.1, 100, 1, 100);
    //
    //����
    //shakecamera2(1, 400, false, true, vector3(0, 0, 1), vector3(0, 0, 400), vector3(0, 0, 0.1), vector3(0, 0, 100));
    //
    //���
    //addbreaksection(10, 900, 933);
  };

  section(333)//Ӳֱ
  {
    animation("Cike_Skill05_02_04")
    {
      speed(1);
    };
    //
    //���
    addbreaksection(1, 333, 2000);
    addbreaksection(10, 100, 2000);
    addbreaksection(11, 10, 2000);
    addbreaksection(21, 100, 2000);
    addbreaksection(100, 120, 2000);
  };

  section(366)//����
  {
    animation("Cike_Skill05_02_99")
    {
      speed(1);
    };
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
