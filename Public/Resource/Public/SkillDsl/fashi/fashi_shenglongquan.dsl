skill(130201)
{
	section(200)
	{
        addbreaksection(0, 200, 2400)
        {   
            sendmessage("break");
        };
        addbreaksection(1, 2400, 2400);
        addbreaksection(10, 2400, 2400);
        addbreaksection(20, 0, 2400);
        addbreaksection(30, 2400, 2400);
		movecontrol(true);
		animation("fashi_shenglongquan_01_01"); 
        //֡1
        setanimspeed(33, "fashi_shenglongquan_01_01", 4);
        //֡21
        enablechangedir(100, 200);
	};
    section(900)
    {
        animation("fashi_shenglongquan_01_02")
        {
            wrapmode(2);
        }; 
        enablechangedir(0, 900);
    }; 
    section(1200)
    {//攒满
        removebreaksection(0);
		animation("fashi_shenglongquan_01_03"); 
        //֡1
        setanimspeed(33, "fashi_shenglongquan_01_03", 2);
        //֡7
        setanimspeed(133, "fashi_shenglongquan_01_03", 0.25);
        //֡14
        setanimspeed(1066, "fashi_shenglongquan_01_03", 1);
        //֡30
        findmovetarget(0, vector3(0, 0, 0), 6, 30, 0.6, 0.4, 0, 0, true);
        startcurvemove(20, true, 0.05, 0, 0, 0, 0, 0, 560, 0.05, 0, 0, 28, 0, 0, -500); 
        sceneeffect("Hero_FX/6_Fashi/6_hero_fashi_shenglongquan_02",2000,vector3(0,0,0),130);
        areadamage(130, 0, 0, 0, 3, true) 
        {
            stateimpact("kKnockDown", 13030113);
            stateimpact("kLauncher", 13030112);
            stateimpact("kDefault", 13030111);
        };
        colliderdamage(230, 800, true, false, 100, 8)
        {
            stateimpact("kKnockDown", 13030123);
            stateimpact("kLauncher", 13030122);
            stateimpact("kDefault", 13030121);
            scenecollider("Hero/6_fashi/shenglongquancollider1", vector3(0, 0, 0));
        };
        gotosection(1200, 4, 0);
    };
    section(400)
    {//攒未满
        removebreaksection(0);
		animation("fashi_shenglongquan_01_03"); 
        //֡1
        setanimspeed(33, "fashi_shenglongquan_01_03", 2);
        //֡7
        setanimspeed(133, "fashi_shenglongquan_01_03", 1);
        //֡30
        findmovetarget(0, vector3(0, 0, 0), 6, 30, 0.6, 0.4, 0, 0, true);
        startcurvemove(20, true, 0.05, 0, 0, 0, 0, 0, 560, 0.05, 0, 0, 28, 0, 0, -500); 
        sceneeffect("Hero_FX/6_Fashi/6_hero_fashi_shenglongquan_01",2000,vector3(0,0,0),130);
        areadamage(130, 0, 0, 0, 3, true) 
        {
            stateimpact("kKnockDown", 13030103);
            stateimpact("kLauncher", 13030102);
            stateimpact("kDefault", 13030101);
        };
        gotosection(400, 4, 0);
    };
    section(1)
    {
    };
    onmessage("break")
    {
         removebreaksection(0);
         gotosection(0, 3, 0);
    };
	oninterrupt()
	{
		stopeffect(300);
	};
	onstop()
	{
		stopeffect(300);
	};
};

skill(130202)
{
	section(1900)
	{
        addbreaksection(1, 1500, 1900);
        addbreaksection(10, 1500, 1900);
        addbreaksection(20, 0, 1900);
        addbreaksection(30, 1500, 1900);
		movecontrol(true);
		animation("fashi_shenglongquan_02"); 
        startcurvemove(320, true, 0.3, 0, 20, 0, 0, -66.6, 0); 
        startcurvemove(800, true, 0.2, 0, 0, 0, 0, -150, 0);
        areadamage(320, 0, 1, 0, 3, true) 
        {
            stateimpact("kKnockDown", 13030203);
            stateimpact("kLauncher", 13030202);
            stateimpact("kDefault", 13030201);
        };
        areadamage(400, 0, 1.5, 0, 3, true) 
        {
            stateimpact("kLauncher", 13030204);
            stateimpact("kDefault", 13030203);
        };
        areadamage(480, 0, 1.5, 0, 3, true) 
        {
            stateimpact("kLauncher", 13030205);
            stateimpact("kDefault", 13030203);
        };
        areadamage(560, 0, 2, 0, 3, true) 
        {
            stateimpact("kLauncher", 13030206);
            stateimpact("kDefault", 13030203);
        };
        areadamage(640, 0, 2, 0, 3, true) 
        {
            stateimpact("kLauncher", 13030207);
            stateimpact("kDefault", 13030203);
        };
	};
	oninterrupt()
	{
		stopeffect(300);
	};
	
	onstop()
	{
		stopeffect(300);
	};
};
