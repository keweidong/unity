

/****    ӰϮӰ�ӹ�������    ****/

skill(125102)
{
  section(1)//��ʼ��
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //�趨����Ϊʩ���߷���
    settransform(0," ",vector3(0,0,0),eular(0,0,0),"RelativeOwner",false);
		//findmovetarget(0, vector3(0, 0, 1), 2.5, 60, 0.1, 0.9, 0, -0.8);
  };

  section(200)//����
  {
    animation("Cike_Skill06_shadow02_01")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.18, 0, 0, 37, 0, 0, -20);
    //
    //��Ч
    //charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_ShadowXian_02", 2000, "Bone_Root", 0);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_ShadowXian_02", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
  };

  section(250)//��һ��
  {
    animation("Cike_Skill06_shadow02_02")
    {
      speed(1);
    };
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 12060201);
			stateimpact("kLauncher", 12060203);
			stateimpact("kKnockDown", 12060203);
      //showtip(200, 0, 0, 1);
		};
    //
    //��Ч
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_shadow01_02", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_CiJiShouJi_HeiYing_01_002", 3000, vector3(0, 0, 0), 240, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Skill06_YingXi_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true)
    {
			audiogroup("Sound/Cike/guaiwu_shouji_02", "Sound/Cike/guaiwu_shouji_03", "Sound/Cike/guaiwu_shouji_04","Sound/Npc/guaiwu_shouji_05", "Sound/Npc/guaiwu_shouji_06", "Sound/Npc/guaiwu_shouji_07", "Sound/Npc/guaiwu_shouji_08", "Sound/Npc/guaiwu_shouji_09", "Sound/Npc/guaiwu_shouji_10", "Sound/Npc/guaiwu_shouji_11", "Sound/Npc/guaiwu_shouji_12", "Sound/Npc/guaiwu_shouji_13");
    };
  };

  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    //ģ����ʧ
    setenable(0, "Visible", true);
    destroyself(1);
  };

  onstop() //������������ʱ�����иö��߼�
  {
    //ģ����ʧ
    setenable(0, "Visible", true);
    destroyself(1);
  };
};
