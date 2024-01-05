using UnityEngine;
using Naninovel;

public class UIControl : MonoBehaviour
{
    [SerializeField] private CanvasGroup _blockPanel;

    private IInputManager _inputManager;

    private void Update()
    {
        if (_inputManager == null)
        {
            _inputManager = Engine.GetService<IInputManager>();
            return;
        }
    }

    public void ActivateCanvasGroup()
    {
        AudioListener.volume = 0f;
        AudioListener.pause = true;
        _inputManager.ProcessInput = false;

        _blockPanel.alpha = 1;
        _blockPanel.interactable = true;
        _blockPanel.blocksRaycasts = true;
        Debug.Log("ActivePanel");
    }

    public void DeactivateCanvasGroup()
    {
        AudioListener.volume = 1f;
        AudioListener.pause = false;
        _inputManager.ProcessInput = true;

        _blockPanel.alpha = 0;
        _blockPanel.interactable = false;
        _blockPanel.blocksRaycasts = false;
        Debug.Log("DeactivePanel");
    }
}
