using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Events;

public class SpriteButton : BaseSpriteButton
{
    [Space]
    public UnityEvent OnClickEvent;

    private void Awake()
    {
        action += OnClickEvent.Invoke;
    }
}
