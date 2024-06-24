using System;

namespace Game.Core
{
    public enum Player
    {
        Cross,
        Zero,
    }

    public abstract class GameLogic
    {
        protected Player activePlayer = Player.Cross;

        public abstract bool Move(Move move, Action<CellState> callback);

        #region Debug
        public abstract void Print();
        #endregion
    }
}