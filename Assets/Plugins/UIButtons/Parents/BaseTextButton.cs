using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseTextButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Settings")]
    [SerializeField] bool _isInteractable = true;
    public bool IsInteractable
    {
        get { return _isInteractable; }
        set
        {
            _isInteractable = value;
            if (value) textButton.color = normalColor;
            else textButton.color = notInteractiveColor;
        }
    }
    [Space]
    private TMP_Text _textButton;
    private TMP_Text textButton
    {
        get
        {
            if (_textButton == null)
            {
                _textButton = GetComponent<TMP_Text>();
                normalColor = textButton.color;
            }
            return _textButton;
        }
    }
    [Header("Color")]
    public Color notInteractiveColor;
    public Color highlightedColor;
    public Color downHighlightedColor;
    private Color normalColor;

    public Action action;

    bool _isPointed = false;

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (_isInteractable)
        {
            textButton.color = highlightedColor;
        }
        _isPointed = true;
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (_isInteractable)
        {
            textButton.color = normalColor;
        }
        _isPointed = false;
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_isInteractable)
            {
                textButton.color = downHighlightedColor;
            }
        }
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_isInteractable)
            {
                textButton.color = normalColor;
                if (_isPointed)
                {
                    action?.Invoke();
                }
            }
        }
    }
}
