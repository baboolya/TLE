using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexMetrica;
using Naninovel;

public class RewScript : MonoBehaviour
{
    private const string AdKEey = "Ad";
    
    private Action _adOpened;
    private Action _rewardAdClosed;
    private Action _getReward;
    private Action<string> _adErrorMessage;

    private IInputManager _inputManager;
    
    protected void OnEnable()
    {
        YandexMetrica.Send("RewardShowed");

        _inputManager = Engine.GetService<IInputManager>();
        _adOpened += OnAdOpened;
        _rewardAdClosed += OnRewardAdClose;
        PlayerPrefs.SetInt(AdKEey, 0);
    }

    protected void OnDisable()
    {
        _adOpened -= OnAdOpened;
        _rewardAdClosed -= OnRewardAdClose;
    }

    public void PlayAd()
    {
        Debug.Log("AD");

        YandexMetrica.Send("RewardPlayed");

        VideoAd.Show(onOpenCallback: OnAdOpened, onCloseCallback: OnRewardAdClose);

        ///_adOpened?.Invoke();
        ///_rewardAdClosed?.Invoke();
    }

    private void OnAdOpened()
    {
        PlayerPrefs.SetInt(AdKEey, 1);
        Debug.Log("Open");
        AudioListener.pause = true;
        AudioListener.volume = 0f;
        Time.timeScale = 0f;

        _inputManager.ProcessInput = false;
        Debug.Log("Paused");

    }

    private void OnRewardAdClose()
    {
        Debug.Log("Close");
        AudioListener.pause = false;
        AudioListener.volume = 1f;
        _inputManager.ProcessInput = true;

        Time.timeScale = 1f;
        Debug.Log("UnPaused");
        PlayerPrefs.SetInt(AdKEey, 0);
    }
}
