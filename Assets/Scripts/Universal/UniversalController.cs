using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Universal
{
    public class UniversalController : SingletonComponent<UniversalController>
    {
        #region Singleton
        public static UniversalController Instance
        {
            get { return ((UniversalController)_Instance); }
            set { _Instance = value; }
        }
        #endregion

        #region Inspector
        #endregion

        #region Private
        #endregion

        #region Public
        #endregion

        #region Functions
        private void Awake()
        {

        }
        #endregion

        #region Gizmos
        #endregion

        #region Classes
        #endregion
    }
}