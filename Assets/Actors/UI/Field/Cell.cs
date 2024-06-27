using Game.Core;
using Game.Sound;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        Move move;
        Image image;
        Field field;

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (ApplicationController.Instance.CurrentGame.CanMove == true) MakeMove();
        }


        public void OnPointerUp(PointerEventData eventData)
        {
        }

        public void MakeMove()
        {
            if(ApplicationController.Instance.CurrentGame.Move(move, SetState, SetParantState))
            {
                SoundController.Instance.PlaySound(Sounds.painting);
                if (ApplicationController.Instance.CurrentGame.IsUseAI == true)
                {
                    if (ApplicationController.Instance.CurrentGame.CanMove == false) ApplicationController.Instance.AIMove();
                }
            }
        }

        public void Init(Move move, Field field)
        {
            image = this.transform.GetChild(0).GetComponent<Image>();
            image.sprite = GameAssets.Instance.Image_None;

            this.move = move;
            this.field = field;
        }

        void SetState(CellState state)
        {
            if (state == CellState.cross) image.sprite = GameAssets.Instance.Image_Cross;
            else if (state == CellState.zero) image.sprite = GameAssets.Instance.Image_Zero;
            else image.sprite = GameAssets.Instance.Image_None;
        }

        void SetParantState(CellState state) => field.SetState(state);

    }
}
