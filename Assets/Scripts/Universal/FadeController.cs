using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : SingletonComponent<FadeController>
{
    #region Singleton
    public static FadeController Instance
    {
        get { return ((FadeController)_Instance); }
        set { _Instance = value; }
    }
    #endregion

    #region Inspector
    [SerializeField] private CanvasGroup _fader;
    #endregion

    #region Private
    #endregion

    #region Public
    #endregion

    #region Functions
    public void FadeTo(int alpha, float duration = 1f)
    {
        if (_fader.alpha == 0 && alpha == 1)
            SetReycastblocker(true);

        _fader.DOFade(alpha, duration).SetEase(Ease.Linear).OnComplete(() => EndFade(alpha));
    }

    private void EndFade(float endValue)
    {
        if (endValue == 0)
            SetReycastblocker(false);
    }

    private void SetReycastblocker(bool doBlock)
    {
        _fader.interactable = doBlock;
        _fader.blocksRaycasts = doBlock;
    }
    #endregion

    #region Gizmos
    #endregion

    #region Classes
    #endregion
}
