using Game.Sound;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public class TextButton : BaseTextButton
    {
        public UnityEvent OnClickEvent;

        private void Awake()
        {
            action += Click;
        }

        private void Click()
        {
            SoundController.Instance.PlaySound(Sounds.click);
            OnClickEvent?.Invoke();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            SoundController.Instance.PlaySound(Sounds.hover);
        }
    }
}
