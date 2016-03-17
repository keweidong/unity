using System;
using System.Collections.Generic;

namespace DashFire
{
  public class ActionLogic_0001 : AbstractActionLogic
  {
    public delegate void ActionLogicEventHandler(CharacterInfo entity, ActionInfo actionInfo, int sectionNum);
    public static ActionLogicEventHandler EventActionSectionStart;

    public ActionLogic_0001()
    {
      m_ActionLogicId = ActionLogicId.ACTION_LOGIC_ID_NORMAL;
    }

    protected override void OnSectionStart(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      StartSection(entity, actionInfo, sectionNum);

      if (null != EventActionSectionStart) {
        EventActionSectionStart(entity, actionInfo, sectionNum);
      }
    }

    protected override void OnSectionOver(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      EndSection(entity, actionInfo, sectionNum);
    }
  }
}
