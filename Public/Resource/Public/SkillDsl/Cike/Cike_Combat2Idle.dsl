skill(120000)
{
	section(600)
	{
    movechild(500, "3_Cike_w_01", "ef_other01");//��ʼ��������
    movechild(500, "3_Cike_w_02", "ef_other02");//��ʼ��������
		addbreaksection(1, 0, 500);
		addbreaksection(10, 0, 500);
		addbreaksection(11, 0, 500);
		animation("Cike_Combat2Idle");
		//movechild(866, "1_JianShi_w_01", "ef_backweapon01");

    //
    //���
    //playpartanimation(10, "CiBang_01", "Fight2Relax");
  };
  oninterrupt()
  {
		//movechild(0, "1_JianShi_w_01", "ef_rightweapon01");
    //���
    playpartanimation(0, "CiBang_02", "Idle", 2);
  };

  onstop()
  {
		//movechild(0, "1_JianShi_w_01", "ef_rightweapon01");
    //���
    playpartanimation(0, "CiBang_02", "Idle", 2);
  };

};