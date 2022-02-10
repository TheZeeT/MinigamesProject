using UnityEngine;

namespace Project.Universal
{
    public class SceneStarter : MonoBehaviour
    {
        #region Functions
        private void Awake()
        {
            UniversalLoader.Initialize();
        }
        #endregion
    }
}