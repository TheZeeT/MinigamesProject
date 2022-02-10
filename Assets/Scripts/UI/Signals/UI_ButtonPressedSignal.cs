public class UI_ButtonPressedSignal
{
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
}
