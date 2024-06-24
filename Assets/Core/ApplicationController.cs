using Game.Core;
using UnityEngine;

namespace Game
{
    public class ApplicationController : MonoBehaviour
    {
        public static ApplicationController Instance {  get; private set; }
        public GameLogic CurrentGame { get; private set; }
        private void Awake()
        {
            Instance = this;
            CurrentGame = new BigTicTacToeLogic();
        }
    }
}
