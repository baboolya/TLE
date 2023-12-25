using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;
using System;

namespace Naninovel.UI
{
    [RequireComponent(typeof(Button))]
    public class RawardChoiceHandlerButton : ChoiceHandlerButton
    {
        private Action _adOpened;
        private Action _rewardAdClosed;
        private Action _getReward;
        private Action<string> _adErrorMessage;

        protected override void OnEnable()
        {
            _adOpened += OnAdOpened;
            _rewardAdClosed += OnRewardAdClose;
            _getReward += OnRewarded;
            
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            _adOpened -= OnAdOpened;
            _rewardAdClosed -= OnRewardAdClose;
            _getReward -= OnRewarded;
            
            base.OnDisable();
        }

        protected override void InvokeOnButtonClicked()
        {
            VideoAd.Show(_adOpened,
                _getReward,
                ()=>
            {
                _rewardAdClosed?.Invoke();
                base.InvokeOnButtonClicked();
            }, 
                _adErrorMessage);
        }

        private void OnAdOpened()
        {     
            AudioListener.pause = true;
            AudioListener.volume = 0f;

            Time.timeScale = 0f;
        }

        private void OnRewardAdClose()
        {
            AudioListener.pause = false;
            AudioListener.volume = 1f;

            Time.timeScale = 1f;
        }

        private void OnRewarded()
        {
            AudioListener.pause = false;
            AudioListener.volume = 1f;

            Time.timeScale = 1f;
        }
    }
}
