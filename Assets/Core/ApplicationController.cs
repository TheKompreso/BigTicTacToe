using Game.Core;
using Game.UI;
using System;
using UnityEngine;

namespace Game
{
    public class ApplicationController : MonoBehaviour
    {
        public static ApplicationController Instance { get; private set; }
        public GameLogic CurrentGame { get; private set; }

        [SerializeField] GameSpace gameSpace;
        [SerializeField] UIElement mainMenu;

        // Прикол
        Action restartAction;

        private void Awake()
        {
            Instance = this;
        }

        public void StartClassic()
        {
            StartClassic((3, 3), 3);
        }
        public void StartBigClassic()
        {
            StartBigClassic((3, 3), 3);
        }

        public void StartClassic((int, int) fieldSize, int winLength)
        {
            restartAction = () => StartClassic(fieldSize, winLength);

            CurrentGame = new ClassicLogic(fieldSize, winLength);
            gameSpace.gameObject.SetActive(true);
            gameSpace.CreateClassicField(fieldSize);
        }
        public void StartBigClassic((int, int) fieldSize, int winLength)
        {
            restartAction = () => StartBigClassic(fieldSize, winLength);

            CurrentGame = new BigTicTacToeLogic(fieldSize, fieldSize, winLength);
            gameSpace.gameObject.SetActive(true);
            gameSpace.CreateBigField(fieldSize, fieldSize);
        }
        public void BackToMenuFromGameSpace()
        {
            gameSpace.Clear();
            gameSpace.gameObject.SetActive(false);
            mainMenu.Show();
        }

        public void RestartGame()
        {
            gameSpace.Clear();
            restartAction.Invoke();
        }
    }
}
