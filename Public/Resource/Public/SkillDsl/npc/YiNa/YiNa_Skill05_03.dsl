

/****    ���ȷ���    ****/

skill(400503)
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

  section(133)//����
  {
    animation("YiNa_Skill05_01_01")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(100, true, 0.06, 0, 0, 12, 0, 0, 0);
  };

  section(166)//��һ��
  {
    animation("YiNa_Skill05_01_02")
    {
      speed(1);
    };
    //
    //�ٻ�����
    summonnpc(0, 101, "Monster_FX/YiNa/6_Mon_YiNa_FeiBiao_01", 400511, vector3(0, 0, 0));
    summonnpc(0, 101, "Monster_FX/YiNa/6_Mon_YiNa_FeiBiao_01", 400512, vector3(30, 0, 0));
    summonnpc(0, 101, "Monster_FX/YiNa/6_Mon_YiNa_FeiBiao_01", 400513, vector3(30, 0, 0));
    summonnpc(0, 101, "Monster_FX/YiNa/6_Mon_YiNa_FeiBiao_01", 400514, vector3(0, 0, 0));
    summonnpc(0, 101, "Monster_FX/YiNa/6_Mon_YiNa_FeiBiao_01", 400515, vector3(0, 0, 0));
    //
    summonnpc(60, 101, "Monster_FX/YiNa/6_Mon_YiNa_FeiBiao_01", 400516, vector3(0, 0, 0));
    summonnpc(60, 101, "Monster_FX/YiNa/6_Mon_YiNa_FeiBiao_01", 400517, vector3(0, 0, 0));
    //
    summonnpc(90, 101, "Monster_FX/YiNa/6_Mon_YiNa_FeiBiao_01", 400518, vector3(0, 0, 0));
    summonnpc(90, 101, "Monster_FX/YiNa/6_Mon_YiNa_FeiBiao_01", 400519, vector3(0, 0, 0));
    //��Ч
    //charactereffect("Monster_FX/YiNa/6_Mon_YiNa_PuGong_01", 500, "Bone_Root", 1);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

  section(100)//Ӳֱ
  {
    animation("YiNa_Skill05_01_99")
    {
      speed(1);
    };
  };
};
