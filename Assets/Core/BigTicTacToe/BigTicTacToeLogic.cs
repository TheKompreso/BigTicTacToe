using System;
using System.Collections.Generic;
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
            if (gameStage.HasFlag(GameStage.Win)) return false;
            if (activeField != null && activeField != field && gameField.CheckClose(activeField.Value) == false) return false;
            if (gameField.CheckClose(field) == true) return false;
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
                        MoveIsDone?.Invoke();
                        return true;
                    }
                }
                gameStage = gameStage == GameStage.CrossPlayer ? GameStage.ZeroPlayer : GameStage.CrossPlayer;
                MoveIsDone?.Invoke();
                return true;
            }
            return false;
        }

        public ((int column, int row)[] fields, bool active) GetActiveFields()
        {
            List<(int column, int row)> fieldsList = new();
            if (gameStage.HasFlag(GameStage.Win))
            {
                CellState cellPlayer = gameStage.HasFlag(GameStage.ZeroPlayer) ? CellState.zero : CellState.cross;
                for (int j = 0; j < gameField.sizeField.row; j++)
                {
                    for (int i = 0; i < gameField.sizeField.column; i++)
                    {
                        if (gameField.GetCellPlayer((i, j)) == cellPlayer)
                        {
                            fieldsList.Add((i, j));
                        }
                    }
                }
                return (fieldsList.ToArray(), true);
            }
            else
            {
                if (activeField == null || gameField.CheckClose(activeField.Value))
                {
                    for (int j = 0; j < gameField.sizeField.row; j++)
                    {
                        for (int i = 0; i < gameField.sizeField.column; i++)
                        {
                            if (gameField.CheckClose((i, j)))
                            {
                                fieldsList.Add((i, j));
                            }
                        }
                    }
                    return (fieldsList.ToArray(), false);
                }
                else
                {
                    fieldsList.Add(activeField.Value);
                    return (fieldsList.ToArray(), true);
                }
            }
            //return (new []{ (0, 0) }, false);
        }
    }
}
