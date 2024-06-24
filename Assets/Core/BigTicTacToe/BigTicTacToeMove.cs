using System;

namespace Game.Core
{
    [Serializable]
    public class BigTicTacToeMove : Move
    {
        public (int column, int row) field;

        public Move SetField((int, int) value)
        {
            this.field = value;
            return this;
        }
    }
}
