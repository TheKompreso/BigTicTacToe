using System;

namespace Game.Core
{
    [Flags]
    public enum GameStage
    {
        CrossPlayer = 1<<0,
        ZeroPlayer = 1<<1,
        Win = 1<<2,
    }

    public abstract class GameLogic
    {
        protected GameStage gameStage = GameStage.CrossPlayer;

        public abstract bool Move(Move move, Action<CellState> callback, Action<CellState> parantCallback);

        #region Debug
        public abstract void Print();
        #endregion
    }
}