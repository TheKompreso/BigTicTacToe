using Game.Core;
using Game.UI;
using UnityEngine;

namespace Game
{
    public class ApplicationController : MonoBehaviour
    {
        public static ApplicationController Instance {  get; private set; }
        public GameLogic CurrentGame { get; private set; }

        [SerializeField] GameSpace gameSpace;


        private void Awake()
        {
            Instance = this;
        }

        public void StartClassic()
        {
            (int, int) fieldSize = (3, 3);
            int winLength = 3;
            CurrentGame = new ClassicLogic(fieldSize, winLength);
            gameSpace.gameObject.SetActive(true);
            gameSpace.CreateClassicField(fieldSize);
        }

        public void StartBigClassic()
        {
            (int, int) fields = (3, 3);
            (int, int) fieldSize = (3, 3);
            int winLength = 3;
            CurrentGame = new BigTicTacToeLogic(fields, fieldSize, winLength);
            gameSpace.gameObject.SetActive(true);
            gameSpace.CreateBigField(fields, fieldSize);
        }
    }
}
