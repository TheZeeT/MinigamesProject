using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Debug_ButtonBlock : MonoBehaviour
{
    #region Inspector
    [SerializeField] private UI_Button _otherButton;
    #endregion

    #region Private
    [Inject] private SignalBus _signalBus;
    #endregion

    #region Public
    #endregion

    #region Functions
    private void Awake()
    {
        _signalBus.Subscribe<UI_ButtonPressedSignal>(OnButtonPressed);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<UI_ButtonPressedSignal>(OnButtonPressed);
    }
    private void OnButtonPressed(UI_ButtonPressedSignal signal)
    {
        if (signal.button.gameObject == gameObject && !signal.isPressed)
        {
            _otherButton.AddOrRemoveBlocker("DebugTestBlocker", _otherButton.IsInteractable);
        }
    }
    #endregion

    #region Gizmos
    #endregion

    #region Classes
    #endregion
}
