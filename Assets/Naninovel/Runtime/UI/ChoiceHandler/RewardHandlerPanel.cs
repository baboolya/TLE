using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Naninovel.UI
{
    public class RewardHandlerPanel : ChoiceHandlerPanel
    {
        // public override void RemoveAllChoiceButtonsDelayed()
        // {
        //     base.RemoveAllChoiceButtonsDelayed();
        //
        //     ChoiceHandlerPanel[] choiceHandlerPanel = FindObjectsOfType<ChoiceHandlerPanel>();
        //
        //     foreach (var item in choiceHandlerPanel)
        //     {
        //         if (item != null && item != this)
        //             item.RemoveAllThisChoiceButtonsDelayed();
        //     }
        // }
        //
        // public override void RemoveAllChoiceButtons()
        // {
        //     for (int i = 0; i < ChoiceButtons.Count; i++)
        //     {
        //         Destroy(ChoiceButtons[i].gameObject);
        //     }
        //     
        //     ChoiceButtons.Clear();
        //
        //     ChoiceHandlerPanel[] choiceHandlerPanel = FindObjectsOfType<ChoiceHandlerPanel>();
        //
        //     foreach (var item in choiceHandlerPanel)
        //     {
        //         if (item != null && item != this)
        //             item.RemoveThisTypeOfChoiceButtons();
        //     }
        // }
    }
}   

