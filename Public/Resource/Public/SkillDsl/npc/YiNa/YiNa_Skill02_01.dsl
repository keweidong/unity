

/****    ���ȴ�ͻ��    ****/

skill(400201)
{
  section(1)//��ʼ��
  {
    movechild(0, "5_IP_YiNa_01_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "5_IP_YiNa_01_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //˲���༼�ܴ��
    addbreaksection(11, 1, 30000);
  };

  section(466)//����
  {
    animation("YiNa_Skill02_01_01")
    {
      speed(1);
    };
    //
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_DaTuCi_XuLi_01", 500, "Bone_Root", 1);
  };
  section(266)//��һ��
  {
    animation("YiNa_Skill02_01_02")
    {
      speed(1);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(1, true, 0.1, 0, 0, 100, 0, 0, -30);
    //
    colliderdamage(0, 266, true, true, 0, 1)
    {
      stateimpact("kDefault", 40020101);
      sceneboxcollider(vector3(2, 2, 2), vector3(0, 1.5, 0), eular(0, 0, 0), true, false);
    };
    //
    //��Ч
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_DaTuCi_02", 1500, "Bone_Root", 1);
    sceneeffect("Monster_FX/YiNa/6_Mon_YiNa_DaTuCi_Huo", 3000, vector3(0, 0, 1), 10, eular(0, 0, 0), vector3(1, 1, 1), true);
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_08", false);
    playsound(20, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_02", true);
    playsound(20, "Hit03", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_Voice_01", false);
  };

  section(333)//����
  {
    animation("YiNa_Skill02_01_99")
    {
      speed(1);
    };
    //
    //���
    addbreaksection(1, 1, 2000);
    addbreaksection(10, 1, 2000);
    addbreaksection(100, 1, 2000);
  };
};
