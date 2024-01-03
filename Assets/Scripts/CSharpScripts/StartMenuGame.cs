using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
using YG;

public class StartMenuGame : MonoBehaviour
{
    private void OnEnabled()
    {
        YandexGame.GetDataEvent += GetData;
    }
    
    private void OnDisabled()
    {
        YandexGame.GetDataEvent -= GetData;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
            GetData();
    }

    private void GetData()
    {
        RuntimeInitializer.InitializeAsync();
    }
}
