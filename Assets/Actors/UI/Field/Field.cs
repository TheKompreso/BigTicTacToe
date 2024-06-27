using Game.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class Field : MonoBehaviour, IField
    {
        [SerializeField] Transform cellsParant;
        [SerializeField] Image image;
        [SerializeField] GameObject imageBlock;
        Cell[,] m_Cells;

        public GridLayoutGroup Group { get; set; }

        public void InitCells((int column, int row) size, Move moveTemplate)
        {
            this.GetComponent<RectTransform>().sizeDelta =
                new Vector2(
                    size.column * 70 + size.column * 5 + 10,
                    size.row * 70 + size.row * 5 + 10);

            m_Cells = new Cell[size.column, size.row];
            for (int j = 0; j < size.row; j++)
            {
                for (int i = 0; i < size.column; i++)
                {
                    m_Cells[i, j] = Instantiate(GameAssets.Instance.cell);
                    m_Cells[i, j].transform.SetParent(cellsParant, false);
                    m_Cells[i, j].Init(moveTemplate.DeepClone().SetCell((i, j)), this);
                }
            }
        }
        public void SetState(CellState state)
        {
            if (state == CellState.cross) image.sprite = GameAssets.Instance.Image_Cross;
            else if (state == CellState.zero) image.sprite = GameAssets.Instance.Image_Zero;
            else image.sprite = GameAssets.Instance.Image_None;
        }

        public void SetActive(bool active)
        {
            imageBlock.SetActive(!active);
        }
    }
}
