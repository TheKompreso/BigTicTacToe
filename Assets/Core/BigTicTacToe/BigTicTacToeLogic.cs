using System;
using UnityEngine;

namespace Game.Core
{
    public class BigTicTacToeLogic : GameLogic
    {
        BigGameField gameField;
        (int column, int row)? activeField;

        public BigTicTacToeLogic((int, int) fieldsLength, (int, int) sizeField, int winLength)
        {
            gameField = new BigGameField(fieldsLength, sizeField, winLength);
            activeField = null;
        }

        public override bool Move(Move move, Action<CellState> callback, Action<CellState> parantCallback) => 
            Move((move as BigTicTacToeMove).field, (move as BigTicTacToeMove).cell, callback, parantCallback);

        public bool Move((int column, int row) field, (int column, int row) cell, Action<CellState> action, Action<CellState> parantCallback)
        {
            //Debug.Log($"Move: Field({field}), Cell({cell}) | activeField = {activeField}");
            if (gameStage.HasFlag(GameStage.Win)) return false;
            if (activeField != null && activeField != field && gameField.CheckClose(activeField.Value) == false) return false;
            if(gameField.CheckClose(field) == true) return false;
            CellState state = gameStage == GameStage.CrossPlayer ? CellState.cross : CellState.zero;
            if (gameField.SetCellState((field.column, field.row), (cell.column, cell.row), state))
            {
                action(state);
                activeField = cell;
                
                if (gameField.CheckWin((field.column, field.row), (cell.column, cell.row)))
                {
                    gameField.SetWinner((field.column, field.row), state);
                    parantCallback(state);
                    if (gameField.CheckWin(field.column, field.row))
                    {
                        gameStage |= GameStage.Win;
                        Debug.Log($"GameStage = {gameStage}");
                        return true;
                    }
                }

                gameStage = gameStage == GameStage.CrossPlayer ? GameStage.ZeroPlayer : GameStage.CrossPlayer;

            }
            return true;
        }

        public override void Print()
        {
            gameField.Print();
        }
    }
}
