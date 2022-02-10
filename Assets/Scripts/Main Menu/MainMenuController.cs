using Project.Universal;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    #region Inspector
    [SerializeField] private GameSelection[] _games;
    [SerializeField] private UI_Button _creditsButton;
    [SerializeField] private UI_Button _optionsButton;
    [SerializeField] private UI_Button _exitButton;
    #endregion

    #region Private
    [Inject] private SignalBus _signalBus;
    #endregion

    #region Public
    #endregion

    #region Functions
    private void Awake()
    {
        _signalBus.Subscribe<UI_ButtonPressedSignal>(OnButtonPressed);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<UI_ButtonPressedSignal>(OnButtonPressed);
    }

    private void OnButtonPressed(UI_ButtonPressedSignal signal)
    {
        if (!signal.isPressed)
        {
            for (int i = 0; i < _games.Length; i++)
            {
                if(_games[i].Button == signal.button)
                {
                    SceneLoader.Instance.SwitchScene(_games[i].SceneName);
                    return;
                }
            }

            if (signal.button == _exitButton)
            {
#if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
#endif
                Application.Quit();
            }
        }
    }
    #endregion

    #region Gizmos
    #endregion

    #region Classes
    [System.Serializable]
    private class GameSelection
    {
        #region Inspector
        [SerializeField] private string _sceneName;
        [SerializeField] private UI_Button _button;
        #endregion

        #region Public
        public string SceneName
        {
            get { return _sceneName; }
        }

        public UI_Button Button
        {
            get { return _button; }
        }
        #endregion
    }
    #endregion
}
