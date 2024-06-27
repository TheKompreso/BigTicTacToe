using System;
using System.Collections.Generic;
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
        [SerializeField] public CellState FieldState { get; protected set; }
        [SerializeField] protected CellState[,] cells;
        [SerializeField] protected (int column, int row) size;
        [SerializeField] protected int winLength;

        private GameField() { }
        public GameField((int column, int row) size, int winLength)
        {
            this.size = size;
            this.winLength = winLength;
            Clear();
        }

        public CellState[,] GetCells()
        {
            var outArray = new CellState[size.column, size.row];
            Array.Copy(cells, outArray, size.column * size.row);
            return outArray;
        }

        public bool SetCellState(int column, int row, CellState state)
        {
            if (state == CellState.none) { if (cells[column, row] == CellState.none) return false; }
            else if (cells[column, row] != CellState.none) return false;
            cells[column, row] = state;
            return true;
        }

        public void Clear()
        {
            FieldState = CellState.none;
            cells = new CellState[size.column, size.row];
        }

        public GameField Copy()
        {
            var copy = new GameField()
            {
                FieldState = FieldState,
                cells = GetCells(),
                size = size,
                winLength = winLength
            };
            return copy;
        }

        char CP(CellState state)
        {
            if (state.HasFlag(CellState.cross)) return 'x';
            else if (state.HasFlag(CellState.zero)) return 'o';
            else return '_';
        }

        public bool CheckWin(int column, int row)
        {
            int length, i;

            // Первая диагональ
            length = 1; i = 1;
            while (CheckCell(column + i, row + i, cells[column, row])) { if (++i == winLength) break; }
            i = 1;
            while (CheckCell(column - i, row - i, cells[column, row])) { if (++i == winLength) break; }
            if (length >= winLength) return true;

            // Вторая диагональ
            length = 1; i = 1;
            while (CheckCell(column - i, row + i, cells[column, row])) { if (++i == winLength) break; }
            i = 1;
            while (CheckCell(column + i, row - i, cells[column, row])) { if (++i == winLength) break; }
            if (length >= winLength) return true;

            // Вертикаль
            length = 1; i = 1;
            while (CheckCell(column, row + i, cells[column, row])) { if (++i == winLength) break; }
            i = 1;
            while (CheckCell(column, row - i, cells[column, row])) { if (++i == winLength) break; }
            if (length >= winLength) return true;

            // Горизонталь
            length = 1; i = 1;
            while (CheckCell(column + i, row, cells[column, row])) { if (++i == winLength) break; }
            i = 1;
            while (CheckCell(column - i, row, cells[column, row])) { if (++i == winLength) break; }
            if (length >= winLength) return true;
            return false;

            bool CheckCell(int x, int y, CellState state)
            {
                try
                {
                    if (cells[x, y] == state)
                    {
                        length++;
                        return true;
                    }
                    return false;
                }
                catch (Exception) { return false; }
            }
        }
        public bool CheckBlock()
        {
            for (int row = 0; row < size.row; row++)
            {
                for (int column = 0; column < size.column; column++)
                {
                    if (cells[column, row] == CellState.none) return false;
                }
            }
            return true;
        }

        public (int column, int row)[] GetMoves()
        {
            List<(int,int)> moves = new();

            for (int row = 0; row < size.column; row++)
            {
                for (int column = 0; column < size.column; column++)
                {
                    if (cells[column, row] != CellState.none) continue;
                    moves.Add((column, row));
                }
            }
            return moves.ToArray();
        }
    }
}
