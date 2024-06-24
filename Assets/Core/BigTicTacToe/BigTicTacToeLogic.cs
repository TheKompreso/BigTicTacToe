using System;
using UnityEngine;

namespace Game.Core
{
    public class BigTicTacToeLogic : GameLogic
    {
        BigGameField gameField;
        (int column, int row)? activeField;

        public BigTicTacToeLogic()
        {
            gameField = new BigGameField((3, 3), 3);
            activeField = null;
        }

        public override bool Move(Move move, Action<CellState> action) => Move((move as BigTicTacToeMove).field, (move as BigTicTacToeMove).cell, action);
        public bool Move((int column, int row) field, (int column, int row) cell, Action<CellState> action)
        {
            Debug.Log($"Move: Field({field}), Cell({cell}) | activeField = {activeField}");
            if (activeField != null && activeField != field) return false;
            CellState state = activePlayer == Player.Cross ? CellState.cross : CellState.zero;
            if (gameField.SetCellState((field.column, field.row), (cell.column, cell.row), state))
            {
                activeField = cell;
                if (gameField.CheckWin((field.column, field.row), (cell.column, cell.row)))
                {
                    // Выиграл кто-то!
                }
                else
                {
                    activePlayer = activePlayer == Player.Cross ? Player.Zero : Player.Cross;
                    // Никто не выиграл!
                }
                action(state);
            }
            return false;
        }

        public override void Print()
        {
            gameField.Print();
        }
    }
}
