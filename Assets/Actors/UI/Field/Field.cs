using Game.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class Field : MonoBehaviour
    {
        [SerializeField] Transform cellsParant;
        [SerializeField] Image image;
        Cell[] m_Cells;

        public void InitCells(Move moveTemplate, (int column, int row) size)
        {
            m_Cells = new Cell[size.column * size.row];
            for (int i = 0; i < m_Cells.Length; i++)
            {
                m_Cells[i] = Instantiate(GameAssets.Instance.cell);
                m_Cells[i].transform.SetParent(cellsParant, false);
                m_Cells[i].Init(moveTemplate.DeepClone().SetCell((i % size.column, i / size.row)), this);
            }
        }
        public void SetState(CellState state)
        {
            if (state == CellState.cross) image.sprite = GameAssets.Instance.Image_Cross;
            else if (state == CellState.zero) image.sprite = GameAssets.Instance.Image_Zero;
            else image.sprite = GameAssets.Instance.Image_None;
        }
    }
}
