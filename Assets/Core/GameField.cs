using System;
using UnityEngine;

namespace Game.Core
{
    [Flags]
    public enum CellState
    {
        none = 0,
        cross = 1,
        zero = 2,
        close = 4,
    }

    [Serializable]
    public class GameField
    {
        [SerializeField] public CellState FieldState { get; private set; }
        [SerializeField] CellState[,] cells;

        public GameField()
        {
            cells = new CellState[3, 3];
        }

        public CellState[,] GetCells()
        {
            var outArray = new CellState[3, 3];
            Array.Copy(cells, outArray, 9);
            return outArray;
        }

        public bool SetCellState(int column, int row, CellState state)
        {
            if (state == CellState.none) if (cells[column, row] == CellState.none) return false;
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

        internal void Print()
        {
            Debug.Log($"{CP(cells[0, 0])} {CP(cells[1, 0])} {CP(cells[2, 0])}\n" +
                      $"{CP(cells[0, 1])} {CP(cells[1, 1])} {CP(cells[2, 1])}\n" +
                      $"{CP(cells[0, 2])} {CP(cells[1, 2])} {CP(cells[2, 2])}\n");
        }

        char CP(CellState state)
        {
            if (state.HasFlag(CellState.cross)) return 'x';
            else if (state.HasFlag(CellState.zero)) return 'o';
            else return '_';
        }
    }
}
