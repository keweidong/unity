//�չ�
skill(420101)
{
  section(333)//����
  {
    movecontrol(true);
    animation("Skill01_01");
  };

  section(400)//��һ��
  {
    animation("Skill01_02");
    areadamage(10, 0, 1.5, 1.5, 2, true)
    {
        stateimpact("kDefault", 42010101);
        stateimpact("kKnockDown", 40000001);
    };
    areadamage(200, 0, 1.5, 1.5, 2, true)
    {
        stateimpact("kDefault", 42010102);
        stateimpact("kKnockDown", 40000001);
    };
    shakecamera2(1, 200, true, true, vector3(0,0.15,0.2), vector3(0,150,150),vector3(0,0.5,0.5),vector3(0,50,70));
    //��Ч
    //charactereffect("Monster_FX/DaKeNiSi/6_Mon_DaKeNiSi_ZhongJi_02", 500, "Bone_Root", 1);
    //��Ч
    playsound(10, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    playsound(20, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
  };
};

//�ػ�
skill(420102)
{
  section(200)//����
  {
    movecontrol(true);
    animation("Skill02_01")
    {
        speed(1.5);
    };
  };

  section(288)//��һ��
  {
    animation("Skill02_02");
    {
        speed(1.5);
    };
    areadamage(10, 0, 1.5, 1.5, 2, true)
    {
        stateimpact("kDefault", 42010201);
        stateimpact("kKnockDown", 40000001);
    };
    shakecamera2(1, 200, true, true, vector3(0,0.15,0.2), vector3(0,150,150),vector3(0,0.5,0.5),vector3(0,50,70));
    //��Ч
    //charactereffect("Monster_FX/DaKeNiSi/6_Mon_DaKeNiSi_ZhongJi_02", 500, "Bone_Root", 1);
    //��Ч
    playsound(10, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    playsound(20, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
  };
};


//�̻�
skill(420103)
{
  section(300)//����
  {
    movecontrol(true);
    animation("Skill03_01");
  };

  section(566)//��һ��
  {
    animation("Skill03_02");
    areadamage(10, 0, 1.5, 1.5, 2, true)
    {
        stateimpact("kDefault", 42010301);
        stateimpact("kKnockDown", 40000001);
    };
    shakecamera2(1, 200, true, true, vector3(0,0.15,0.2), vector3(0,150,150),vector3(0,0.5,0.5),vector3(0,50,70));
    //��Ч
    //charactereffect("Monster_FX/DaKeNiSi/6_Mon_DaKeNiSi_ZhongJi_02", 500, "Bone_Root", 1);
    //��Ч
    playsound(10, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    playsound(20, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
  };
};


//׷��
skill(420104)
{
  section(500)//��һ��
  {
    movecontrol(true);
    animation("Skill04_01");
    //��ɫ�ƶ�
    startcurvemove(0, true, 0.5, 0, 0, 10, 0, 0, 0);
    areadamage(0, 0, 1.5, 1.5, 2, true)
    {
        stateimpact("kDefault", 42010401);
        stateimpact("kKnockDown", 40000001);
    };
    areadamage(250, 0, 1.5, 1.5, 2, true)
    {
        stateimpact("kDefault", 42010401);
        stateimpact("kKnockDown", 40000001);
    };
    //��Ч
    //charactereffect("Monster_FX/DaKeNiSi/6_Mon_DaKeNiSi_ZhongJi_02", 500, "Bone_Root", 1);
    //��Ч
    playsound(10, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    playsound(20, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
  };
};


