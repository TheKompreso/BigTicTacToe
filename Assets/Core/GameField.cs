using System;
using UnityEngine;

namespace Game.Core
{
    public enum CellState
    {
        none = 0,
        cross = 1,
        zero = 2,
        close = 3,
    }

    [Serializable]
    public class GameField
    {
        [SerializeField] public CellState FieldState { get; private set; }
        [SerializeField] CellState[,] cells = new CellState[3, 3];

        public CellState[,] GetCells()
        {
            var outArray = new CellState[3, 3];
            Array.Copy(cells, outArray, 9);
            return outArray;
        }

        public bool SetCellState(int column, int row, CellState state)
        {
            if (state == CellState.none) if(cells[column, row] == CellState.none) return false;
            else if (cells[column, row] != CellState.none) return false;
            cells[column, row] = state;
            return true;
        }

        public void Clear()
        {
            FieldState = CellState.none;
            cells = new CellState[3, 3];
        }

        public BigGameField Copy()
        {
            var copy = new BigGameField
            {
                FieldState = FieldState,
                cells = GetCells()
            };
            return copy;
        }
    }
}
