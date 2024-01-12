using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;
using System.Collections;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

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
        yield return YandexGamesSdk.Initialize(onSuccessCallback: LoadSaves);
    }

    private void LoadSaves()
    {
        PlayerPrefs.Load(LoadLevel, LoadLevelWithErrorClouds);
    }
    
    private void LoadLevel()
    {
        Debug.Log("SUCCESS CLOUDS ENCODING PLAYER PREFS!!!!");
        SceneManager.LoadScene(1);
    }

    private void LoadLevelWithErrorClouds(string error)
    {
        Debug.Log($"LOAD WITH ERROR CLOUDS ENCODING PLAYER PREFS!!! {error}");
        SceneManager.LoadScene(1);
    }
}
