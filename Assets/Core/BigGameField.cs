using System;
using System.Drawing;
using UnityEngine;

namespace Game.Core
{
    [Serializable]
    public class BigGameField : GameField
    {
        [SerializeField] GameField[,] GameField;

        public BigGameField((int column, int row) size, int winLength) : base(size, winLength)
        {
            Clear();
        }

        public bool SetCellState((int column, int row) field, (int column, int row) cell, CellState state)
        {
            return GameField[field.column, field.row].SetCellState(cell.column, cell.row, state);
        }
        public GameField[,] GetFields()
        {
            GameField[,] outArray = new GameField[size.column, size.row];
            for (int i = 0; i < size.column; i++)
            {
                for (int j = 0; j < size.row; j++)
                {
                    outArray[i, j] = GameField[i, j].Copy();
                }
            }
            return outArray;
        }

        public new void Print()
        {
            for(int i = 0; i < size.column; i++)
                for(int j = 0;  j < size.row; j++)
                    GameField[i, j].Print();
        }

        public new void Clear()
        {
            GameField = new GameField[size.column, size.row];
            for (int i = 0; i < size.column; i++)
            {
                for (int j = 0; j < size.row; j++)
                {
                    GameField[i, j] = new GameField((size.column, size.row), winLength);
                }
            }
        }

        public bool CheckWin((int column, int row) field, (int column, int row) cell)
        {
            return GameField[field.column, field.row].CheckWin(cell.column, cell.row);
        }

        public void SetWinner((int column, int row) field, CellState state)
        {
            cells[field.column, field.row] = state | CellState.close;
        }

        public bool CheckClose((int column, int row) field)
        {
            return cells[field.column, field.row].HasFlag(CellState.close);
        }
    }
}
