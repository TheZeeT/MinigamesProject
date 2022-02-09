using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class UI_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region Inspector
    [SerializeField] private bool _isToggle;
    #endregion

    #region Private 
    [Inject] private SignalBus _signalBus;
    private bool _isPressed;
    #endregion

    #region Public
    public bool IsPressed
    {
        get { return _isPressed; }
        set
        {
            bool newValue = value;

            if (_isToggle)
            {
                if (value)
                    newValue = !_isPressed;
            }

            if (_isPressed != newValue)
            {
                _isPressed = newValue;
                _signalBus.Fire(new UI_ButtonPressedSignal(this, _isPressed));
            }
        }
    }
    #endregion

    #region Functions
    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressed = false;
    }
    #endregion

    #region Gizmos
    #endregion

    #region Classes
    #endregion
}
