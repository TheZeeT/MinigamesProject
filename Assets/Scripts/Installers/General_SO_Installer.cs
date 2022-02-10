using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "General_SO_Installer", menuName = "Installers/General_SO_Installer", order = 0)]
public class General_SO_Installer : ScriptableObjectInstaller
{
    #region Functions
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
    }
    #endregion
}
