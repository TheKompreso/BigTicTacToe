using System;

namespace Game.Core
{
    [Serializable]
    public abstract class Move
    {
        public (int column, int row) cell;
        public Move SetCell((int, int) value)
        {
            this.cell = value;
            return this;
        }
    }
}
