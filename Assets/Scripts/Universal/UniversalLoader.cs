using UnityEngine;

namespace Project.Universal
{
    public static class UniversalLoader
    {
        #region Public
        public static UniversalController Controller { get; private set; }
        #endregion

        #region Private
        private const string path = "UniversalController";
        #endregion

        #region Functions
        public static void Initialize()
        {
            if (Controller != null)
                return;

            GameObject UC = Resources.Load(path) as GameObject;
            Controller = GameObject.Instantiate(UC).GetComponent<UniversalController>();
            Object.DontDestroyOnLoad(Controller);
        }
        #endregion
    }
}