using System.Collections;
using System;
using UnityEngine;
using Agava.YandexGames;
using TMPro;
using Naninovel;

public class InterTimer : MonoBehaviour
{
    private const string AdKEey = "Ad";
    
    [SerializeField] private float _waitTime;
    [SerializeField] private int _adsTimer;
    [SerializeField] private GameObject _adsPannel; 
    [SerializeField] private GameObject _pausePannel; 

    private TMP_Text _textMessage;
    private IInputManager _inputManager;

    private bool _isFirstAd;
    private int _currentTimer;
    private Coroutine _changer;
    private UIControl _uIControl;

    private Action _adOpened;
    private Action<bool> _interstitialAdClose;
    private Action<string> _adErrorMessage;

    private void Start()
    {
        _textMessage = _adsPannel.GetComponentInChildren<TMP_Text>();
        _uIControl = _pausePannel.GetComponent<UIControl>();

        _changer = StartCoroutine(ChangeText());
        _currentTimer = _adsTimer;
        _isFirstAd = true;
        StartCoroutine(Timer());
        PlayerPrefs.SetInt(AdKEey, 0);
    }

    private void OnEnable()
    {
        _inputManager = Engine.GetService<IInputManager>();

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

        while (true)
        {
            if (_isFirstAd == false)
            {
                _uIControl.ActivateCanvasGroup();

                _adsPannel.SetActive(true);

                yield return ChangeText();
            }
            else
            {
               _isFirstAd = false;
            }

            InterstitialAd.Show(onOpenCallback: OnAdOpened, onCloseCallback: OnInterstitialAdClose); 

            Debug.Log("Inter");

            _adsPannel.SetActive(false);

            yield return waitForAnyMinutes;
        }
    }

    private void OnAdOpened()
    {
        Time.timeScale = 0f;
    }
    
    private void OnInterstitialAdClose(bool result)
    {
        _uIControl.DeactivateCanvasGroup();
        Time.timeScale = 1f;
    }
    
    private IEnumerator ChangeText()
    {
        bool isOpen = true;

        while(isOpen)
        {
            Debug.Log("StartChange");

            _textMessage.text = $"До начала рекламы {_currentTimer} сек...";

            yield return new WaitForSeconds(1f);

            _currentTimer--;

            if (_currentTimer == 0)
            {
                _currentTimer = _adsTimer;
                isOpen = false;
            }
        }

        if (_changer != null)
        {
            isOpen = true;
            StopCoroutine(_changer);
        }
    }
}