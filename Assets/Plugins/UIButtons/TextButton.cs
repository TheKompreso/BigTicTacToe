using UnityEngine;
using UnityEngine.Events;

public class TextButton : BaseTextButton
{
    [Space]
    public UnityEvent OnClickEvent;

    private void Awake()
    {
        action += OnClickEvent.Invoke;
    }
}
