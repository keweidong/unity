

/****    ���ȷ���5    ****/

skill(400515)
{
  section(1)//��ʼ��
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //�趨����Ϊʩ���߷���
    settransform(0," ",vector3(0,0,0),eular(0,-30,0),"RelativeOwner",false, false, vector3(0, 0, 0));

    //�趨����ʱ��
    setlifetime(0, 5000);
  };

  section(2000)//��һ��
  {
    //
    //��ɫ�ƶ�
    startcurvemove(0, true, 2, 0, 0, 30, 0, 0, 0);
    //
    //��ײ��
    colliderdamage(0, 2000, true, true, 0, 1)
    {
      stateimpact("kDefault", 40050101);
      sceneboxcollider(vector3(1, 1, 1), vector3(0, 0, 0), eular(0, 0, 0), true, false);
    };
    //
    //��Ч
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Skill06_YingXi_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
  };
};
