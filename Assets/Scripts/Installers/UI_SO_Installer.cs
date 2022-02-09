using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UI_SO_Installer", menuName = "Installers/UI_SO_Installer", order = 1)]
public class UI_SO_Installer : ScriptableObjectInstaller
{
    #region Functions
    public override void InstallBindings()
    {
        Container.DeclareSignal<UI_ButtonPressedSignal>().OptionalSubscriber();
    }
    #endregion
}
