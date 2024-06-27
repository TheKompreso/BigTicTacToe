using System;

namespace Game.Core
{
    [Flags]
    public enum GameStage
    {
        CrossPlayer = 1 << 0,
        ZeroPlayer = 1 << 1,
        Win = 1 << 2,
    }

    public abstract class GameLogic
    {
        protected GameStage gameStage = GameStage.CrossPlayer;

        public bool IsUseAI;

        public bool CanMove => !IsUseAI || gameStage == GameStage.CrossPlayer;

        public abstract bool Move(Move move, Action<CellState> callback, Action<CellState> parantCallback);
        public abstract Move GetAIMove(int deep = 1);
        public Action MoveIsDone { get; set; }
        public Action Win { get; set; }

        public virtual void Clear()
        {
            gameStage = GameStage.CrossPlayer;
        }
    }
}