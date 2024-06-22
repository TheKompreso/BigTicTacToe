using System;
using UnityEngine;

namespace Game.Core
{
    [Serializable]
    public class BigGameField : GameField
    {
        [SerializeField] GameField[,] GameField;
        public BigGameField()
        {
            GameField = new GameField[3, 3];
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameField[i, j] = new GameField();
                }
            }
        }
        public bool SetCellState(int field_column, int field_row, int column, int row, CellState state)
        {
            return GameField[field_column, field_row].SetCellState(column, row, state);
        }
        public GameField[,] GetFields()
        {
            var outArray = new GameField[3, 3];
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    outArray[i, j] = GameField[i, j].Copy();
                }
            }
            return outArray;
        }

        public new void Print()
        {
            for(int i = 0; i < 3; i++)
                for(int j = 0;  j < 3; j++)
                    GameField[i, j].Print();
        }

        public new void Clear()
        {
            base.Clear();
            GameField = new GameField[3, 3];
        }
    }
}
