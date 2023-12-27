using System.Collections;
using System;
using UnityEngine;
using Agava.YandexGames;
using TMPro;

public class InterTimer : MonoBehaviour
{
    [SerializeField] private float _waitTime;
    [SerializeField] private int _adsTimer;
    [SerializeField] private GameObject _adsPannel;

    private Action _adOpened;
    private Action<bool> _interstitialAdClose;
    private Action<string> _adErrorMessage;
    private bool _isFirstAd;
    private TMP_Text _textMessage;
    private int _currentTimer;

    private void Start()
    {
        _currentTimer = _adsTimer;
        _isFirstAd = true;
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
        float adsTime = _waitTime - _adsTimer;
        
        var waitForAnyMinutes = new WaitForSeconds(adsTime);
        var waitForAnySeconds = new WaitForSeconds(_adsTimer);

        while (true)
        {
            if (_isFirstAd == false)
               yield return ChangeText();
            else
                _isFirstAd = false;

            InterstitialAd.Show(_adOpened, _interstitialAdClose, _adErrorMessage);           
            _adsPannel.gameObject.SetActive(false);

            yield return waitForAnyMinutes;
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
    
    private IEnumerator ChangeText()
    {
        _textMessage.text = $"До начала рекламы {_currentTimer} сек.";

        yield return new WaitForSeconds(1f);

        _currentTimer--;

        if (_currentTimer == 0)
            StopCoroutine(ChangeText());
    }
}