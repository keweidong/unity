

/****    �����ҳ�    ****/

skill(400403)
{
  section(1)//��ʼ��
  {
    movechild(0, "5_IP_YiNa_01_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "5_IP_YiNa_01_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //˲���෨�����
    addbreaksection(11, 1, 30000);
  };

  section(333)//��һ��
  {
    animation("YiNa_Skill04_03_01")
    {
      speed(1);
    };
    //
     //��ɫ�ƶ�
    startcurvemove(0, true, 0.25, 30, 0, 0, -100, 0, 0);
    //
    //��Ч
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_ShanShen_03", 500, "Bone_Root", 1);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };

  section(100)//Ӳֱ
  {
    animation("YiNa_Skill04_03_99")
    {
      speed(1);
    };
  };
};
