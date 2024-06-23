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
        [Space]
        [SerializeField] Cell[] m_Cells;

        private void Awake()
        {
            InitCells();
        }

        private void InitCells()
        {
            int i = 0;
            while (i < m_Cells.Length)
            {
                m_Cells[i].Init((field_column, field_row), (i % column_length, i / column_length));
                i++;
            }
        }
    }
}
