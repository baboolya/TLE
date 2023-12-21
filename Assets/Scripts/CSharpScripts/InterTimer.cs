using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agava.YandexGames;
using Agava.YandexMetrica;
using Agava.WebUtility;

public class InterTimer : MonoBehaviour
{
    [SerializeField] private float _waitTime;

    private Action _adOpened;
    private Action<bool> _interstitialAdClose;
    private Action<string> _adErrorMessage;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void OnEnable()
    {
        _adOpened += OnAdOpened;
        _interstitialAdClose += OnInterstitialAdClose;
    }

    private void OnDisable()
    {
        _adOpened -= OnAdOpened;
        _interstitialAdClose -= OnInterstitialAdClose;
    }

    private IEnumerator Timer()
    {
        var WaitForAnyMinutes = new WaitForSeconds(_waitTime);

        while (true)
        {
            InterstitialAd.Show(_adOpened, _interstitialAdClose, _adErrorMessage);

            yield return WaitForAnyMinutes;
        }
    }

    private void OnAdOpened()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0f;
        Time.timeScale = 0f;
    }
    
    private void OnInterstitialAdClose(bool result)
    {
        AudioListener.pause = false;
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
    }
}