using Game.Core;
using UnityEngine;

namespace Game
{
    public class ApplicationController : MonoBehaviour
    {
        GameLogic game;
        private void Awake()
        {
            game = new BigTicTacToeLogic();

            game.Move(new BigTicTacToeMove((0, 0), (0, 0)));
            game.Move(new BigTicTacToeMove((0, 0), (1, 0)));
            game.Move(new BigTicTacToeMove((0, 0), (1, 1)));
            game.Move(new BigTicTacToeMove((0, 0), (2, 0)));
            game.Move(new BigTicTacToeMove((0, 0), (2, 2)));

            game.Print();
        }
    }
}
