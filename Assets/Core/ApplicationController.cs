using Game.Core;
using UnityEngine;

namespace Game
{
    public class ApplicationController : MonoBehaviour
    {
        BigGameField gameField;
        private void Awake()
        {
            gameField = new BigGameField();
            gameField.SetCellState(0, 0, 0, 0,CellState.cross);
            gameField.Print();
        }
    }
}
