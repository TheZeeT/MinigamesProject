using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Universal
{
    public class SceneLoader : SingletonComponent<SceneLoader>
    {
        #region Singleton
        public static SceneLoader Instance
        {
            get { return ((SceneLoader)_Instance); }
            set { _Instance = value; }
        }
        #endregion

        #region Inspector
        #endregion

        #region Private
        private const float _fadeDuration = 1f;
        #endregion

        #region Public
        #endregion

        #region Functions
        public void SwitchScene(string newSceneName)
        {
            StartCoroutine(DelaySwitchScene(newSceneName));
        }

        private IEnumerator DelaySwitchScene(string newSceneName)
        {
            FadeController.Instance.FadeTo(1, _fadeDuration); // fade out
            yield return new WaitForSeconds(_fadeDuration);

            yield return SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Single);

            FadeController.Instance.FadeTo(0, _fadeDuration); // faid in
            yield return new WaitForSeconds(_fadeDuration);
        }
        #endregion

        #region Gizmos
        #endregion

        #region Classes
        #endregion
    }
}
