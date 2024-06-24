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

            // Игра 3х3 (пока UI не адаптивный)
            (int, int) fields = (4, 4);
            (int, int) fieldSize = (4, 4);
            int winLength = 3;
            CurrentGame = new BigTicTacToeLogic(fields, fieldSize, winLength);
            GameSpace.Instance.CreateBigField(fields, fieldSize);
        }
    }
}
