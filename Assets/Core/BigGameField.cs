using System;
using UnityEngine;

namespace Game.Core
{
    [Serializable]
    public class BigGameField : GameField
    {
        [SerializeField] GameField[,] GameField;
        public (int column, int row) sizeField { get; private set; }
        public BigGameField((int column, int row) fieldsLength, (int column, int row) sizeField, int winLength) : base(fieldsLength, winLength)
        {
            this.sizeField = sizeField;
            Clear();
        }

        public bool SetCellState((int column, int row) field, (int column, int row) cell, CellState state)
        {
            return GameField[field.column, field.row].SetCellState(cell.column, cell.row, state);
        }
        public GameField[,] GetFields()
        {
            GameField[,] outArray = new GameField[size.column, size.row];
            for (int j = 0; j < size.row; j++)
            {
                for (int i = 0; i < size.column; i++)
                {
                    outArray[i, j] = GameField[i, j].Copy();
                }
            }
            return outArray;
        }

        public new void Clear()
        {
            GameField = new GameField[size.column, size.row];
            for (int j = 0; j < size.row; j++)
            {
                for (int i = 0; i < size.column; i++)
                {
                    GameField[i, j] = new GameField((sizeField.column, sizeField.row), winLength);
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
        public CellState GetCellPlayer((int column, int row) field)
        {
            return (cells[field.column, field.row] & (CellState.cross | CellState.zero));
        }
    }
}
