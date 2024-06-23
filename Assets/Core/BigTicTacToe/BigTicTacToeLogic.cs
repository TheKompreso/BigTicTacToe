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

        public override bool Move(Move move) => Move((move as BigTicTacToeMove).field, (move as BigTicTacToeMove).cell);
        public bool Move((int column, int row) field, (int column, int row) cell)
        {
            if (activeField != null && activeField != field) return false;
            activeField = cell;
            CellState state = activePlayer == Player.Cross ? CellState.cross : CellState.zero;
            if (gameField.SetCellState((field.column, field.row), (cell.column, cell.row), state))
            {
                if (gameField.CheckWin((field.column, field.row), (cell.column, cell.row)))
                {
                    Debug.Log("Выиграл кто-то!");
                }
                else
                {
                    activePlayer = Player.Cross == activePlayer ? Player.Zero : Player.Cross;
                    Debug.Log("Никто не выиграл");
                }
            }
            return false;
        }

        public override void Print()
        {
            gameField.Print();
        }
    }
}
