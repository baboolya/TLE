using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Naninovel.UI
{
    public class RewardHandlerPanel : ChoiceHandlerPanel
    {
        public override void RemoveAllChoiceButtonsDelayed()
        {
            base.RemoveAllChoiceButtonsDelayed();
            
            ChoiceHandlerPanel[] choiceHandlerPanel = FindObjectsOfType<ChoiceHandlerPanel>();
            
            foreach (var item in choiceHandlerPanel)
            {
                Debug.Log("RewAllRemoveDel " + item.name);
                if(item != null && item != this)
                    item.RemoveAllChoiceButtons();
            }
        }
        
        public override void RemoveAllChoiceButtons()
        {
            for (int i = 0; i < ChoiceButtons.Count; i++)
            {
                Debug.Log("RewAllREmove " + ChoiceButtons[i].name);
                Destroy(ChoiceButtons[i].gameObject);
            }
         
            ChoiceHandlerPanel[] choiceHandlerPanel = FindObjectsOfType<ChoiceHandlerPanel>();
            
            foreach (var item in choiceHandlerPanel)
            {
                if(item != null && item != this)
                    item.RemoveAllChoiceButtons();
            }

            ChoiceButtons.Clear();
            Debug.Log("CLEAR RRACB");
        }
    }
}
