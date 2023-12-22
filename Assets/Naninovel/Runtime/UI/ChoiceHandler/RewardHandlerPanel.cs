namespace Naninovel.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class RewardHandlerPanel : ChoiceHandlerPanel
    {
        public override void RemoveAllChoiceButtons()
        {
            ChoiceHandlerPanel choiceHandlerPanel = FindObjectOfType<ChoiceHandlerPanel>();

            choiceHandlerPanel.RemoveAllChoiceButtons();
        }
    }
}
