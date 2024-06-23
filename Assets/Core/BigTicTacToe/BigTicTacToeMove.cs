using UnityEngine;

namespace Game.Core
{
    public class BigTicTacToeMove : Move
    {
        public BigTicTacToeMove((int column, int row) field, (int column, int row) cell)
        {
            this.cell = cell;
            this.field = field;
        }
        public (int column, int row) field;
        public (int column, int row) cell;
    }
}
