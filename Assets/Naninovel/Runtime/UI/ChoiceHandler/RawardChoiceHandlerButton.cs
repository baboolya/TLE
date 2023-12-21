using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;

namespace Naninovel.UI
{
    [RequireComponent(typeof(Button))]
    public class RawardChoiceHandlerButton : ChoiceHandlerButton
    {
        protected override void OnButtonClick()
        {
            VideoAd.Show();
        }
    }
}
