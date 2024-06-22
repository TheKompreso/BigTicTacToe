using System;

namespace Game.Core
{
    public class BigGameField : GameField
    {
        GameField[,] GameField = new GameField[3, 3];
        public GameField[,] GetFields()
        {
            var outArray = new GameField[3, 3];
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    outArray[i, j] = GameField[i, j].Copy();
                }
            }
            return outArray;
        }

        public new void Clear()
        {
            base.Clear();
            GameField = new GameField[3, 3];
        }
    }
}
