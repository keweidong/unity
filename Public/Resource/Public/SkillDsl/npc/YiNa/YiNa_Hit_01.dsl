

/****    �����չ�һ��    ****/

skill(400001)
{
  section(1)//��ʼ��
  {
    movechild(0, "5_IP_YiNa_01_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "5_IP_YiNa_01_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //˲���෨�����
    addbreaksection(11, 1, 30000);
    //
		//findmovetarget(0, vector3(0, 0, 1), 2.5, 60, 0.1, 0.9, 0, -0.8);
  };

  section(155)//����
  {
    animation("YiNa_Hit_01_01")
    {
      speed(1.5);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 12, 0, 0, 0);
  };

  section(44)//��һ��
  {
    animation("Cike_Hit_01_02")
    {
      speed(1.5);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.15, 0, 0, 20, 0, 0, -100);
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2.4, true)
		{
			stateimpact("kDefault", 40000101);
			stateimpact("kLauncher", 40000102);
			stateimpact("kKnockDown", 40000001);
      //showtip(200, 0, 1, 0);
		};
    //
    //��Ч
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_PuGong_01", 500, "Bone_Root", 1);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

  section(110)//Ӳֱ
  {
    animation("YiNa_Hit_01_03")
    {
      speed(1.5);
    };
  };
};
