using System;
using System.Collections.Generic;
using DashFire;

namespace DashFire
{
  public class ChallengeEntityInfo
  {
    public ulong Guid;
    public int HeroId;
    public int Level;
    public int FightScore;
    public string NickName;
    public int Rank;
    public int UserDamage;
    public List<DamageInfo> PartnerDamage = new List<DamageInfo>();
  }

  public class DamageInfo
  {
    public int OwnerId;
    public int Damage;
  }

  public class ChallengeInfo
  {
    public ChallengeEntityInfo Challenger;
    public ChallengeEntityInfo Target;
    public bool IsChallengerSuccess;
    public bool IsDone = false;
    public DateTime ChallengeBeginTime;
    public DateTime BeginFightTime;
    public DateTime ChallengeDeadLine;
    public DateTime ChallengeEndTime;
  }
}
