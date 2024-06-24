using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Field")]
        [SerializeField] int field_column;
        [SerializeField] int field_row;
        [Header("Cell")]
        [SerializeField] int cell_column;
        [SerializeField] int cell_row;

        Image image;

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }


        public void OnPointerUp(PointerEventData eventData)
        {
        }

        public void Init((int column, int row) field, (int column, int row) cell)
        {
            image = this.transform.GetChild(0).GetComponent<Image>();
            image.sprite = GameAssets.Instance.Image_None;

            field_column = field.column;
            field_row = field.row;
            cell_column = cell.column;
            cell_row = cell.row;
        }
    }
}
