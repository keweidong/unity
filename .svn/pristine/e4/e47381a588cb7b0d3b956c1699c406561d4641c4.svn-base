

/****    伊娜防御    ****/

skill(400601)
{
  section(1)//初始化
  {
    movechild(0, "5_IP_YiNa_01_w_01", "ef_righthand");//初始化主武器
    movechild(0, "5_IP_YiNa_01_w_02", "ef_lefthand");//初始化主武器
    movecontrol(true);
    //
    //瞬身类法术打断
    addbreaksection(11, 1, 30000);
    //
    //自身增加无敌霸体buff, 受击可释放
    addimpacttoself(0, 12990004, 2000);
    addimpacttoself(0, 40000003, 2500);
    addimpacttoself(0, 40000002, 2500);
  };

  section(100)//起手
  {
    animation("YiNa_Skill06_01_01")
    {
      speed(1);
    };
  };

  section(2000)//第一段
  {
    animation("YiNa_Skill06_01_02")
    {
      speed(0.4);
    };
    //
    //角色移动
    startcurvemove(10, true, 1, 0, 0, 0, 0, -30, 0);
    //
    //特效
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_FangYu_01", 2000, "Bone_Root", 1);
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_FangYu_01", 2000, "Bone_Root", 700);
    charactereffect("Monster_FX/YiNa/6_Mon_YiNa_FangYu_01", 2000, "Bone_Root", 1400);
    //
    //音效
    playsound(10, "Hit", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/Cike_Hit_01", false);
    playsound(10, "Hit02", "Sound/Cike/CikeSkillSound01", 1000, "Sound/Cike/guaiwu_shouji_01", true);
    //
    //打断
    /*
    addbreaksection(1, 1000, 2200);
    addbreaksection(10, 1000, 2200);
    addbreaksection(11, 1000, 2200);
    addbreaksection(21, 1000, 2200);
    addbreaksection(100, 1000, 2200);
    */
  };

  section(166)//硬直
  {
    animation("YiNa_Skill06_01_99")
    {
      speed(1);
    };
  };
};
