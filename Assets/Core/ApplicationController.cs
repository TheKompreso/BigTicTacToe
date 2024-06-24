using Game.Core;
using Game.UI;
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

            // Игра
            (int, int) fields = (6, 6);
            (int, int) fieldSize = (6, 6);
            int winLength = 5;
            CurrentGame = new BigTicTacToeLogic(fields, fieldSize, winLength);
            GameSpace.Instance.CreateBigField(fields, fieldSize);
        }
    }
}
