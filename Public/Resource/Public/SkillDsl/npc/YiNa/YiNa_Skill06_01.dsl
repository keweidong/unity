

/****    ���ȷ���    ****/

skill(400601)
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
    //���������޵а���buff, �ܻ����ͷ�
    addimpacttoself(0, 12990004, 2000);
    addimpacttoself(0, 40000003, 2500);
    addimpacttoself(0, 40000002, 2500);
  };

  section(100)//����
  {
    animation("YiNa_Skill06_01_01")
    {
      speed(1);
    };
  };

  section(2000)//��һ��
  {
    animation("YiNa_Skill06_01_02")
    {
      speed(0.4);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 1, 0, 0, 0, 0, -30, 0);
    //
    //��Ч
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_FangYu_01", 2000, "Bone_Root", 1);
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_FangYu_01", 2000, "Bone_Root", 700);
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_FangYu_01", 2000, "Bone_Root", 1400);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
    //
    //���
    /*
    addbreaksection(1, 1000, 2200);
    addbreaksection(10, 1000, 2200);
    addbreaksection(11, 1000, 2200);
    addbreaksection(21, 1000, 2200);
    addbreaksection(100, 1000, 2200);
    */
  };

  section(166)//Ӳֱ
  {
    animation("YiNa_Skill06_01_99")
    {
      speed(1);
    };
  };
};
