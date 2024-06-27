using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class BaseSpriteButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] protected bool _isInteractable = true;
    public bool IsInteractable
    {
        get { return _isInteractable; }
        set
        {
            _isInteractable = value;
            if (value) ImageButton.color = NormalColor;
            else ImageButton.color = NotInteractiveColor;
        }
    }
    protected bool IsHovered { get; set; } = false;

    protected Image _imageButton;
    protected Image ImageButton
    {
        get
        {
            if (_imageButton == null)
            {
                _imageButton = GetComponent<Image>();
            }
            return _imageButton;
        }
    }
    [Header("Color")]
    public Color Highlighted;
    public Color DownHighlighted;
    public Color NotInteractiveColor;
    [SerializeField] protected Color NormalColor;

    public Action action;

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (_isInteractable)
        {
            ImageButton.color = Highlighted;
        }
        IsHovered = true;
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (_isInteractable)
        {
            ImageButton.color = NormalColor;
        }
        IsHovered = false;
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_isInteractable)
            {
                ImageButton.color = DownHighlighted;
            }
        }
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_isInteractable)
            {
                ImageButton.color = NormalColor;
                if (IsHovered)
                {
                    action?.Invoke();
                }
            }
        }
    }
}
