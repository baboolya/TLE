using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Naninovel;

public class UIControl : MonoBehaviour
{
    [SerializeField] private GameObject _blockPanel;
    [SerializeField] private float _maxPermission;
    [SerializeField] private float _minPermission;

    private float _normalPermission;
    private float _currentWidth;
    private float _currentHeight;
    private Keyboard _keyboard;

    private void Start()
    {
        _keyboard = InputSystem.GetDevice<Keyboard>();
    }

    private void Update()
    {
        _currentHeight = Screen.height;
        _currentWidth = Screen.width;

        if ((_currentWidth / _currentHeight) <= _minPermission || (_currentWidth / _currentHeight) >= _maxPermission)
        {
            InputSystem.DisableDevice(_keyboard);
            AudioListener.volume = 0f;
            AudioListener.pause = true;
            Time.timeScale = 0f;
            _blockPanel.SetActive(true);
        }
        else
        {
            InputSystem.EnableDevice(_keyboard);
            AudioListener.volume = 1f;
            AudioListener.pause = false;
            Time.timeScale = 1f;
            _blockPanel.SetActive(false);
        }
    }
}
