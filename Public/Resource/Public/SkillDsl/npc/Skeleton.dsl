//���ý�����
skill(310201)
{
  section(2967)
  {
    movecontrol(true);
    animation("Attack_01");
    charactereffect("Monster_FX/Campaign_Dungeon/02_Skeleton/6_Mon_Skeleton_DaoGuang_01_01", 2000, "Bone_Root", 1315);
//    sound("Sound/Swordman/TiaoKong", 620);//�޶�֡ʱ����Ч��ʼʱ��
//    findmovetarget(1425, vector3(0,0,0),3,50,0.5,0.5,0,-2);
    startcurvemove(215, true, 0.36, 0, 0, 2.5, 0, 0, -6, 0.33, 0, 0, 0.8, 0, 0, 6);
    startcurvemove(1130, true, 0.39, 0, 0, 8, 0, 0, -20);
    startcurvemove(1530, true, 0.15, 0, 0, 3, 0, 0, 0);
    startcurvemove(1970, true, 0.2, 0, 0, 2, 0, 0, 0, 0.2, 0, 0, 0.5, 0, 0, 0);
    playsound(1300, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    areadamage(1333, 0, 1, 0.5, 2.5, false) {
      stateimpact("kDefault", 31020101);
    };
    playsound(1340, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
//    createshadow(1330, 200, 1, 250, 250, "shadow", "Transparent/Cutout/Soft Edge Unlit", 0.8);
//    lockframe(720, "Bluelf03_Attack_01", true, 0, 100, 1, 100);
    shakecamera2(1350, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
  };
};

//���ý�����
skill(310202)
{
  section(2733)
  {
    movecontrol(true);
    animation("Skill_01");
    charactereffect("Monster_FX/Campaign_Dungeon/02_Skeleton/6_Mon_Skeleton_DaoGuang_01_02", 2000, "Bone_Root", 1640);
//    sound("Sound/Swordman/TiaoKong", 620);//�޶�֡ʱ����Ч��ʼʱ��
    findmovetarget(1425, vector3(0,0,0),3.5,50,0.5,0.5,0,-2);
    startcurvemove(1612, true, 0.1, 0, 0, 3, 0, 0, 0);
    playsound(1630, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    areadamage(1663, 0, 1, 0.5, 2.5, false) {
      stateimpact("kDefault", 31020201);
    };
    playsound(1666, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
//    lockframe(720, "Bluelf03_Attack_01", true, 0, 100, 1, 100);
    shakecamera2(1670, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
  };
};

//���ùǰ��ջ�
skill(310203)
{
  section(3167)
  {
    movecontrol(true);
    animation("Attack_01");
    charactereffect("Monster_FX/Campaign_Dungeon/02_Skeleton/6_Mon_Skeleton_DaoGuang_02_01", 2000, "Bone_Root", 1875);
//    sound("Sound/Swordman/TiaoKong", 620);//�޶�֡ʱ����Ч��ʼʱ��
    findmovetarget(1775, vector3(0,0,0),3.5,50,0.5,0.5,0,-2);
    startcurvemove(1798, true, 0.1, 0, 0, 3, 0, 0, 0);
    playsound(1855, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    areadamage(1884, 0, 1, 0.5, 2.5, false) {
      stateimpact("kDefault", 31020301);
    };
    playsound(1890, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
//    lockframe(720, "Bluelf03_Attack_01", true, 0, 100, 1, 100);
    shakecamera2(1670, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
  };
};

//���ù�Ͷ��
skill(310204)
{
  section(2967)
  {
    movecontrol(true);
    animation("Skill_01") ;
//    sceneeffect("Monster_FX/Demo_01/01_Bluelf/6_Monster_AttackSign_01", 1000, vector3(0,0,12));
//    charactereffect("Monster_FX/Demo_01/01_Bluelf/6_Mon_Bluelf_SwordS_01", 4000, "ef_body", 10);
    startcurvemove(887, true, 0.37, 0, 0, 1, 0, 0, 1);
    startcurvemove(1270, true, 0.2, 0, 0, 2, 0, 0, -9);
    startcurvemove(1530, true, 0.5, 0, 0, 1, 0, 0, -1);
    setchildvisible(1310,"5_Mon_SkeletonBone_01_w_01",false);
    summonnpc(1323, 101, "Monster/Campaign_Dungeon/02_Skeleton/5_Mon_SkeletonBone_01_w_01", 390007, vector3(0, 0, 0));
    setchildvisible(2560,"5_Mon_SkeletonBone_01_w_01",true);
  };
  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    setchildvisible(2560,"5_Mon_SkeletonBone_01_w_01",true);
  };
  onstop() //������������ʱ�����иö��߼�
  {
    setchildvisible(2560,"5_Mon_SkeletonBone_01_w_01",true);
  };
};

//���ø�����
skill(310205)
{
  section(3000)
  {
    movecontrol(true);
    animation("Attack_01");
    charactereffect("Monster_FX/Campaign_Dungeon/02_Skeleton/6_Mon_Skeleton_DaoGuang_03_02", 2000, "Bone_Root", 1640);
//    sound("Sound/Swordman/TiaoKong", 620);//�޶�֡ʱ����Ч��ʼʱ��
    findmovetarget(1572, vector3(0,0,0),3.5,50,0.5,0.5,0,-2);
    startcurvemove(1582, true, 0.1, 0, 0, 3, 0, 0, 0);
    playsound(1613, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    areadamage(1644, 0, 1, 0.5, 2.5, false) {
      stateimpact("kDefault", 31020501);
    };
    playsound(1650, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
//    lockframe(720, "Bluelf03_Attack_01", true, 0, 100, 1, 100);
    shakecamera2(1670, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
  };
};

//���ø�����
skill(310206)
{
  section(2967)
  {
    movecontrol(true);
    animation("Skill_01");
    charactereffect("Monster_FX/Campaign_Dungeon/02_Skeleton/6_Mon_Skeleton_DaoGuang_03_01", 2000, "Bone_Root", 1315);
//    sound("Sound/Swordman/TiaoKong", 620);//�޶�֡ʱ����Ч��ʼʱ��
//    findmovetarget(1425, vector3(0,0,0),3,50,0.5,0.5,0,-2);
    startcurvemove(215, true, 0.36, 0, 0, 2.5, 0, 0, -6, 0.33, 0, 0, 0.8, 0, 0, 6);
    startcurvemove(1130, true, 0.39, 0, 0, 8, 0, 0, -20);
    startcurvemove(1530, true, 0.15, 0, 0, 3, 0, 0, 0);
    startcurvemove(1970, true, 0.2, 0, 0, 2, 0, 0, 0, 0.2, 0, 0, 0.5, 0, 0, 0);
    playsound(1330, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    areadamage(1333, 0, 1, 0.5, 2.5, false) {
      stateimpact("kDefault", 31020601);
    };
    playsound(1340, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
//    createshadow(1330, 200, 1, 250, 250, "shadow", "Transparent/Cutout/Soft Edge Unlit", 0.8);
//    lockframe(720, "Bluelf03_Attack_01", true, 0, 100, 1, 100);
    shakecamera2(1350, 250, true, true, vector3(0,0,0.2), vector3(0,0,150),vector3(0,0,0.5),vector3(0,0,30));
  };
};


