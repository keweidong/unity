
/****    Ӱ�в��Ӽ���    ****/

//˫���չ�
skill(320301)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(266)//����
  {
    animation("Attack_01_01")
    {
      speed(1);
    };
  };

  section(133)//��һ��
  {
    animation("Attack_01_02")
    {
      speed(1);
    };
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2, true)
		{
			stateimpact("kDefault", 32020801);
			stateimpact("kKnockDown", 40000001);
      //showtip(200, 0, 1, 0);
		};
	  shakecamera2(1, 200, true, true, vector3(0,0.15,0.2), vector3(0,150,150),vector3(0,0.5,0.5),vector3(0,50,70));
    //
    //��Ч
    charactereffect("Monster_FX/Campaign_Desert/03_Assassin/5_Mon_Assassin_PuGong_01", 500, "Bone_Root", 1);
    //
    //��Ч
	  playsound(10, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    playsound(20, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
  };

  section(400)//����
  {
    animation("Attack_01_99")
    {
      speed(1);
    };
  };
};

//˫��������
skill(320302)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(333)//����
  {
    animation("Skill_01_01")
    {
      speed(1);
    };
    //
    //ģ����ʧ
    setenable(300, "Visible", false);
    //
    //��Ч
    sceneeffect("Monster_FX/Campaign_Desert/03_Assassin/5_Mon_Assassin_ShanShen_01", 3000, vector3(0, 0, 0), 290, eular(0, 0, 0), vector3(1, 1, 1), true);
  };

  section(100)//��һ��
  {
    //��ɫ�ƶ�
    startcurvemove(1, true, 0.1, 0, 0, -30, 0, 0, 0);
  };

  section(233)//����
  {
    animation("Skill_01_99")
    {
      speed(1);
    };
    //
    //ģ����ʾ
    setenable(0, "Visible", true);
  };

  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
  };

  onstop() //������������ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
  };
};

//˫������
skill(320303)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(333)//����
  {
    animation("Skill_01_01")
    {
      speed(1);
    };
    //
    //ģ����ʧ
    setenable(300, "Visible", false);
    //
    //��Ч
    sceneeffect("Monster_FX/Campaign_Desert/03_Assassin/5_Mon_Assassin_ShanShen_01", 3000, vector3(0, 0, 0), 290, eular(0, 0, 0), vector3(1, 1, 1), true);
  };

  section(100)//��һ��
  {
    //
    //�������Ӱ���buff
    addimpacttoself(1, 12990001, 500);
    //
    //Ŀ��ѡ��
		findmovetarget(0, vector3(0, 0, 1), 10, 60, 0.1, 0.9, 0, 2);
    //
    //��ɫ�ƶ�
    startcurvemove(10, true, 0.05, 0, 0, 20, 0, 0, 0);
    //
    //����
    settransform(90, " ", vector3(0, 0, 0), eular(0, 180, 0), "RelativeSelf", true);
  };


  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(266)//����
  {
    animation("Attack_01_01")
    {
      speed(1);
    };
    //
    //ģ����ʾ
    setenable(0, "Visible", true);
  };

  section(133)//��һ��
  {
    animation("Attack_01_02")
    {
      speed(1);
    };
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2, true)
		{
			stateimpact("kDefault", 32020802);
			stateimpact("kKnockDown", 40000001);
      //showtip(200, 0, 1, 0);
		};
	  shakecamera2(1, 200, true, true, vector3(0,0.15,0.2), vector3(0,150,150),vector3(0,0.5,0.5),vector3(0,50,70));
    //
    //��Ч
    charactereffect("Monster_FX/Campaign_Desert/03_Assassin/5_Mon_Assassin_PuGong_01", 500, "Bone_Root", 1);
    //
    //��Ч
	  playsound(10, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    playsound(20, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
  };

  section(400)//����
  {
    animation("Attack_01_99")
    {
      speed(1);
    };
  };

  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
  };

  onstop() //������������ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
  };
};

//�����չ�
skill(320304)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(266)//����
  {
    animation("Attack_01_01")
    {
      speed(1);
    };
  };

  section(133)//��һ��
  {
    animation("Attack_01_02")
    {
      speed(1);
    };
    //
    //�˺��ж�
    areadamage(10, 0, 1.5, 1.5, 2, true)
		{
			stateimpact("kDefault", 32020803);
			stateimpact("kKnockDown", 40000001);
      //showtip(200, 0, 1, 0);
		};
	  shakecamera2(1, 200, true, true, vector3(0,0.15,0.2), vector3(0,150,150),vector3(0,0.5,0.5),vector3(0,50,70));
    //
    //��Ч
    charactereffect("Monster_FX/Campaign_Desert/03_Assassin/5_Mon_Assassin_PuGong_01", 500, "Bone_Root", 1);
    //
    //��Ч
	  playsound(10, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    playsound(20, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
  };

  section(400)//����
  {
    animation("Attack_01_99")
    {
      speed(1);
    };
  };
};

//����������
skill(320305)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(333)//����
  {
    animation("Skill_01_01")
    {
      speed(1);
    };
    //
    //ģ����ʧ
    setenable(300, "Visible", false);
    //
    //��Ч
    sceneeffect("Monster_FX/Campaign_Desert/03_Assassin/5_Mon_Assassin_ShanShen_01", 3000, vector3(0, 0, 0), 290, eular(0, 0, 0), vector3(1, 1, 1), true);
  };

  section(100)//��һ��
  {
    //��ɫ�ƶ�
    startcurvemove(1, true, 0.1, 0, 0, -30, 0, 0, 0);
  };

  section(233)//����
  {
    animation("Skill_01_99")
    {
      speed(1);
    };
    //
    //ģ����ʾ
    setenable(0, "Visible", true);
  };

  oninterrupt() //�����ڱ����ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
  };

  onstop() //������������ʱ�����иö��߼�
  {
    //ģ����ʾ
    setenable(0, "Visible", true);
  };
};

//��������
skill(320306)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(333)//����
  {
    animation("Skill_01_01")
    {
      speed(1);
    };
  };

  section(266)//��һ��
  {
    animation("Skill_01_02")
    {
      speed(1);
    };
    //
    //�ٻ�����
    summonnpc(0, 101, "Monster_FX/Campaign_Desert/03_Assassin/5_Mon_Assassin_FeiBiao_01", 320307, vector3(0, 0, 0));
    //
    //��Ч
	  playsound(10, "huiwu", "Sound/Npc/Mon", 1000, "Sound/Npc/guaiwu_huiwuzhong_01", false);
    playsound(20, "hit", "", 1000, "Sound/Npc/guaiwu_jizhong_tongyong_01", true);
  };

  section(233)//����
  {
    animation("Skill_01_99")
    {
      speed(1);
    };
  };
};

//����
skill(320307)
{
  section(1)//��ʼ��
  {
    movechild(0, "3_Cike_w_01", "ef_righthand");//��ʼ��������
    movechild(0, "3_Cike_w_02", "ef_lefthand");//��ʼ��������
    movecontrol(true);
    //
    //�趨����Ϊʩ���߷���
    settransform(0," ",vector3(0,0,0),eular(0,0,0),"RelativeOwner",false);
  };

  section(2000)//��һ��
  {
    //
    //��ɫ�ƶ�
    startcurvemove(0, true, 2, 0, 0, 20, 0, 0, 0);
    //
    //��ײ��
    colliderdamage(0, 2000, true, true, 0, 1)
    {
      stateimpact("kDefault", 32020804);
      sceneboxcollider(vector3(1, 1, 1), vector3(0, 0, 0), eular(0, 0, 0), true, false);
    };
  };
};

//���ǻ�
skill(320308)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(2000)//����
  {
    animation("Walk")
    {
      speed(0.5);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(1, true, 2, 0.5, 0, 0.3, 0, 0, 0);
  };
};

//���ǻ�
skill(320309)
{
  section(1)//��ʼ��
  {
    movecontrol(true);
  };

  section(2000)//����
  {
    animation("Walk")
    {
      speed(0.5);
    };
    //
    //��ɫ�ƶ�
    startcurvemove(1, true, 2, -0.5, 0, 0.3, 0, 0, 0);
  };
};


