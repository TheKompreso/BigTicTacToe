using Game.UI;
using System;
using System.Drawing;
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
                    Win?.Invoke();
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

        public override Move GetAIMove(int deep = 1)
        {
            //(int column, int row) bestMove;
            //GameField gameField = this.gameField.Copy();
            (int column, int row)[] bestMoves = gameField.GetMoves();
            return new ClassicMove() { cell = bestMoves[UnityEngine.Random.Range(0, bestMoves.Length)] };
            /*
            int CalcMove(GameField field, int deep)
            {
                for(int row = field.size.row; row < field.size.column; row++)
                {
                    for(int column = field.size.column; column < field.size.column; column++)
                    {
                        if (field.cells[column, row] != CellState.none) continue;
                        // А тут продолжим
                    }
                }
            }*/
        }
    }
}
