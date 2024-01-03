using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class RewScript : MonoBehaviour
{
    private Action _adOpened;
    private Action _rewardAdClosed;
    private Action _getReward;
    private Action<string> _adErrorMessage;

    protected void OnEnable()
    {
        _adOpened += OnAdOpened;
        _rewardAdClosed += OnRewardAdClose;
    }

    protected void OnDisable()
    {
        _adOpened -= OnAdOpened;
        _rewardAdClosed -= OnRewardAdClose;
    }

    public void PlayAd()
    {
        VideoAd.Show(()=>
        {
            _adOpened?.Invoke();
        },
            _getReward,
            _rewardAdClosed,
            _adErrorMessage);

        // _adOpened?.Invoke();
        // _rewardAdClosed?.Invoke();
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
}
