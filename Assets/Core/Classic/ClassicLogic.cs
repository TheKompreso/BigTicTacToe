using Game.UI;
using System;
using UnityEngine;

namespace Game.Core
{
    [Serializable]
    public class ClassicLogic : GameLogic
    {
        [SerializeField] GameField gameField;

        public ClassicLogic((int, int) sizeField, int winLength)
        {
            gameField = new GameField(sizeField, winLength);
        }

        public override bool Move(Move move, Action<CellState> callback, Action<CellState> parantCallback)
        {
            if (gameStage.HasFlag(GameStage.Win)) return false;
            CellState state = gameStage == GameStage.CrossPlayer ? CellState.cross : CellState.zero;
            if (gameField.SetCellState(move.cell.column, move.cell.row, state))
            {
                callback(state);

                if (gameField.CheckWin(move.cell.column, move.cell.row))
                {
                    parantCallback(state);
                    gameStage |= GameStage.Win;
                    MoveIsDone?.Invoke();
                    return true;
                }
                gameStage = gameStage == GameStage.CrossPlayer ? GameStage.ZeroPlayer : GameStage.CrossPlayer;
                MoveIsDone?.Invoke();
                return true;
            }
            return false;
        }

        public override void Clear()
        {
            base.Clear();
            gameField.Clear();
        }
    }
}
