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
    private bool _isInteractable = true;

    private Dictionary<string, GameObject> _blockers = new Dictionary<string, GameObject>();
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

    public bool IsInteractable
    {
        get { return _isInteractable; }
        protected set
        {
            if (_isInteractable != value)
            {
                _isInteractable = value;
                _signalBus.Fire(new UI_ButtonBlockedSignal(this, _isInteractable));
            }
        }
    }
    #endregion

    #region Functions
    public void OnPointerDown(PointerEventData eventData)
    {
        if (IsInteractable)
            IsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressed = false;
    }

    public void AddOrRemoveBlocker(string blocker, bool doBlock)
    {
        if (doBlock)
        {
            if (!_blockers.ContainsKey(blocker))
                _blockers.Add(blocker, gameObject);
        }
        else
        {
            if (_blockers.ContainsKey(blocker))
                _blockers.Remove(blocker);
        }

        IsInteractable = _blockers.Count == 0;
    }
    #endregion

    #region Gizmos
    #endregion

    #region Classes
    #endregion
}
