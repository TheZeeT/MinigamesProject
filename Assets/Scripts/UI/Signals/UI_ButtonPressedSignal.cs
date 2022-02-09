using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ButtonPressedSignal
{
    #region Inspector
    #endregion

    #region Private
    #endregion

    #region Public
    public readonly UI_Button button;
    public readonly bool isPressed;
    #endregion

    #region Functions
    public UI_ButtonPressedSignal(UI_Button button, bool isPressed)
    {
        this.button = button;
        this.isPressed = isPressed;
    }
    #endregion

    #region Gizmos
    #endregion

    #region Classes
    #endregion
}
