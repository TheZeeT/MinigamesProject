using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Zenject;
using DG.Tweening;

[RequireComponent(typeof(UI_Button))]
public class UI_ButtonVisuals : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Inspector
    [SerializeField] private Image _image;
    [SerializeField] private TMPro.TMP_Text _text;
    [Header("Image Color")]
    [SerializeField] private ColorBlock _colorsImage;
    [Header("Text Color")]
    [SerializeField] private ColorBlock _colorsText;
    //[SerializeField] private T
    #endregion

    #region Private
    [Inject] private SignalBus _signalBus;
    private bool _isHoveringOver;
    private bool _isPressedDown;

    private Tweener _tweenerImage = null;
    private Tweener _tweenerText = null;
    #endregion

    #region Public
    #endregion

    #region Functions
    private void Awake()
    {
        _signalBus.Subscribe<UI_ButtonPressedSignal>(OnButtonPressed);

        Highlight();
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<UI_ButtonPressedSignal>(OnButtonPressed);
    }

    private void OnButtonPressed(UI_ButtonPressedSignal signal)
    {
        if (signal.button.gameObject == gameObject)
        {
            _isPressedDown = signal.isPressed;
            Highlight();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isHoveringOver = true;
        Highlight();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isHoveringOver = false;
        Highlight();
    }

    private void Highlight()
    {
        Color nextImageColor = GetColor(_colorsImage);
        Color nextTextColor = GetColor(_colorsText);

        if(_image.color != nextImageColor)
        {
            _tweenerImage?.Kill();
            _tweenerImage = _image.DOColor(nextImageColor, _colorsImage.fadeDuration);
        }

        if(_text.color != nextTextColor)
        {
            _tweenerText?.Kill();
            _tweenerText = _text.DOColor(nextTextColor, _colorsText.fadeDuration);
        }
    }


    private Color GetColor(ColorBlock colorBlock)
    {
        if (_isPressedDown)
            return colorBlock.pressedColor;
        else if (_isHoveringOver)
            return colorBlock.highlightedColor;
        else
            return colorBlock.normalColor;
    }
    #endregion

    #region Gizmos
    #endregion

    #region Classes
    #endregion
}
