using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Naninovel;

public class UIControl : MonoBehaviour
{
    [SerializeField] private GameObject _blockPanel;

    private float _normalPermission;
    private float _currentWidth;
    private float _currentHeight;

    private void Update()
    {
        _currentHeight = Screen.height;
        _currentWidth = Screen.width;

        if ((_currentWidth / _currentHeight) <= 1.6f || (_currentWidth / _currentHeight) >= 2.5f)
        {
            AudioListener.volume = 0f;
            AudioListener.pause = true;
            Time.timeScale = 0f;
            _blockPanel.SetActive(true);
        }
        else
        {
            AudioListener.volume = 1f;
            AudioListener.pause = false;
            Time.timeScale = 1f;
            _blockPanel.SetActive(false);
        }
    }
}
