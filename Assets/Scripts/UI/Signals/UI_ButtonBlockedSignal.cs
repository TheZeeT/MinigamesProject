public class UI_ButtonBlockedSignal
{
    #region Public
    public readonly UI_Button button;
    public readonly bool isInteractable;
    #endregion

    #region Functions
    public UI_ButtonBlockedSignal(UI_Button button, bool isInteractable)
    {
        this.button = button;
        this.isInteractable = isInteractable;
    }
    #endregion
}
