using UnityEngine;
using System;
using Agava.YandexGames;
using Agava.WebUtility;
using UnityEngine.SceneManagement;
using System.Collections;
using Naninovel;

public class GameTest : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
#if !UNITY_WEBGL || UNITY_EDITOR 
        LoadLevel();
        yield break;
#endif
        yield return YandexGamesSdk.Initialize(onSuccessCallback: LoadLevel);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
