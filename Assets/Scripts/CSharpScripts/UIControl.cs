using UnityEngine;
using Naninovel;

public class UIControl : MonoBehaviour
{
    private const string AdKEey = "Ad";
    
    [SerializeField] private CanvasGroup _blockPanel;
    [SerializeField] private float _maxPermission;
    [SerializeField] private float _minPermission;

    private float _normalPermission;
    private float _currentWidth;
    private float _currentHeight;
    private IInputManager _inputManager;

    private void Update()
    {
        if (_inputManager == null)
        {
            _inputManager = Engine.GetService<IInputManager>();
            return;
        }

        if (PlayerPrefs.GetInt(AdKEey) == 1)
        {
            Debug.Log("AdKey == 1");
            return;
        }
        
        _currentHeight = Screen.height;
        _currentWidth = Screen.width;

        if ((_currentWidth / _currentHeight) <= _minPermission || (_currentWidth / _currentHeight) >= _maxPermission)
        {
            AudioListener.volume = 0f;
            AudioListener.pause = true;
            Time.timeScale = 0f;
            _inputManager.ProcessInput = false;
            ActivateCanvasGroup();
        }
        else
        {
            AudioListener.volume = 1f;
            AudioListener.pause = false;
            Time.timeScale = 1f;
            _inputManager.ProcessInput = true;
            DeactivateCanvasGroup();
        }
    }

    private void ActivateCanvasGroup()
    {
        _blockPanel.alpha = 1;
        _blockPanel.interactable = true;
        _blockPanel.blocksRaycasts = true;
    }

    private void DeactivateCanvasGroup()
    {
        _blockPanel.alpha = 0;
        _blockPanel.interactable = false;
        _blockPanel.blocksRaycasts = false;
    }
}
