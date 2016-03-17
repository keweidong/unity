story(1)
{  
  local
  {
    @targetPt(vector3(0,0,0));
    @dist(0);
  };
	onmessage("start")
	{
	  sendgfxmessage("Main Camera","StopSound",1);
	  wait(10);
	  sendgfxmessage("Main Camera","PlaySound",0);
	  wait(10);
	  lockframe(1.0);
	  wait(10);
	  camerayaw(0,10);
	  camerafollow();
	  showwall("BtoC",false);
	  showwall("AtoB",false);
	  showwall("BDoor",true);
	  wait(10);
	  sendgfxmessage("UIPortal_Activity","PlayParticle");
	  sendgfxmessage("UIPortal_PVE","PlayParticle");
	  sendgfxmessage("UIPortal_PVP","PlayParticle");
	  sendgfxmessage("UIPortal_Gateway","PlayParticle");
	  wait(10);
	  loop(7)
	  {
	    createnpc(1001+$$);
	  };
	  //wait(1000);
	  //setblockedshader(0x0000ff90,0.5,0,0xff000090,0.5,0);
	};
	//虚拟玩家移动
	onmessage("cityusermove")
	{
	  log("cityusermove:{0} {1} {2}",$0,$1,$2);
	  objmove($0,vector3($1,0,$2));
	};
	onmessage("objarrived")
	{
	  log("objarrived, adjust face {0}", $0);
	  objface($0,-1);
	};
	//0——单人PVE，1——多人活动，2——PVP
	onmessage("cityplayermove")
	{
	  if($0==0)
	  {	
	    @targetPt = vector3(62.20567,150.0892,78.41065);
	    @dist = vector3dist(getposition(playerselfid()),@targetPt);
	    if(@dist<=1)
	    {
	      sendgfxmessage("GfxGameRoot","ShowWindow","SceneSelect");
	    }
	    else
	    {
  	    playerselfmove(@targetPt);
  	  };
	  };
	  if($0==1)
	  {
	    @targetPt = vector3(68.09088,150.0892,83.6263);
	    @dist = vector3dist(getposition(playerselfid()),@targetPt);
	    if(@dist<=1)
	    {
	      sendgfxmessage("GfxGameRoot","ShowWindow","Trial");
	    }
	    else
	    {
  	    playerselfmove(@targetPt);
  	  };
	  };
	  if($0==2)
	  {
	    @targetPt = vector3(67.7371,150.0892,63.11042);
	    @dist = vector3dist(getposition(playerselfid()),@targetPt);
	    if(@dist<=1)
	    {
	      sendgfxmessage("GfxGameRoot","ShowWindow","Mars");
	    }
	    else
	    {
  	    playerselfmove(@targetPt);
  	  };
	  };
	};
};
story(2)
{  
};
story(3)
{  
};