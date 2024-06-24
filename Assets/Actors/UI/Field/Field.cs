using Game.Core;
using UnityEngine;

namespace Game.UI
{
    public class Field : MonoBehaviour
    {
        Cell[] m_Cells;

        public void InitCells(Move moveTemplate, (int column, int row) size)
        {
            m_Cells = new Cell[size.column * size.row];
            for (int i = 0; i < m_Cells.Length; i++)
            {
                m_Cells[i] = Instantiate(GameAssets.Instance.cell);
                m_Cells[i].transform.SetParent(this.transform, false);
                m_Cells[i].Init(moveTemplate.DeepClone().SetCell((i % size.column, i / size.row)));
            }
        }
    }
}
