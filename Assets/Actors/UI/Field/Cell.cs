using Game.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        Move move;
        Image image;

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ApplicationController.Instance.CurrentGame.Move(move, SetState);
        }


        public void OnPointerUp(PointerEventData eventData)
        {
        }

        public void Init(Move move)
        {
            image = this.transform.GetChild(0).GetComponent<Image>();
            image.sprite = GameAssets.Instance.Image_None;

            this.move = move;
        }

        public void SetState(CellState state)
        {
            if (state == CellState.cross) image.sprite = GameAssets.Instance.Image_Cross;
            else if (state == CellState.zero) image.sprite = GameAssets.Instance.Image_Zero;
            else image.sprite = GameAssets.Instance.Image_None;
        }
    }
}
