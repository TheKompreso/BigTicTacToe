using System;
using UnityEngine;

namespace Game.UI
{
    public class Field : MonoBehaviour
    {
        [SerializeField] int field_column;
        [SerializeField] int field_row;
        [Space]
        [SerializeField] int column_length;
        [SerializeField] int row_length;
        Cell[] m_Cells;

        public void InitCells((int column, int row) field, (int column, int row) size)
        {
            field_column = field.column;
            field_row = field.row;
            column_length = size.column;
            row_length = size.row;

            m_Cells = new Cell[column_length * row_length];
            for (int i = 0; i < m_Cells.Length; i++)
            {
                m_Cells[i] = Instantiate(GameAssets.Instance.cell);
                m_Cells[i].transform.SetParent(this.transform, false);
                m_Cells[i].Init((field_column, field_row), (i % column_length, i / column_length));
            }
        }
    }
}
