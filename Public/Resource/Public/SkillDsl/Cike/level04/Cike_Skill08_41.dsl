

/****    Ӱ��ģ��һ�� �Ľ�    ****/

skill(120841)
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
		//findmovetarget(0, vector3(0, 0, 1), 2.5, 60, 0.1, 0.9, 0, -0.8);
    //
    //Ϊ�Լ����ӱ�����ܵ�impact
		//addimpacttoself(1, 12080101, 5000);
  };

  section(100)//��һ��
  {
    animation("Cike_Skill08_01_01")
    {
      speed(1);
    };
    //
    //��Ч
    sceneeffect("Hero_FX/3_Cike/3_Hero_CiKe_YingZiMoFang_HeiYan_01", 3000, vector3(0, 0, 0), 0, eular(0, 0, 0), vector3(1, 1, 1), true);
    charactereffect("Hero_FX/3_Cike/3_Hero_CiKe_YingZiMoFang_HeiYanFaShe_01", 3000, "Bone_Root", 0);
    //
    //�ٻ�NPC
    summonnpc(0, 102, "Hero/3_Cike/3_Cike_02", 125201, vector3(0, 0, 0));
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);

    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Voice_YingZiMoFang_01", false)
    {
	    audiogroup("None", "None");
    };
    //
    //���
    addbreaksection(1, 300, 2000);
    addbreaksection(10, 10, 2000);
    addbreaksection(21, 10, 2000);
    addbreaksection(100, 100, 2000);
  };

  section(533)//����
  {
    animation("Cike_Skill08_01_99")
    {
      speed(1);
    };
  };
};
