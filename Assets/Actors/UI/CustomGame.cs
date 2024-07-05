using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class CustomGame : UIElement
    {
        [SerializeField] TMP_InputField sizeX;
        [SerializeField] TMP_InputField sizeY;
        [SerializeField] TMP_InputField winLength;
        [SerializeField] Toggle classicMod;
        public void StartCustomGame()
        {
            (int, int) size = (3,3);
            int win = 3;

            if (int.TryParse(sizeX.text, out int result))
            {
                size.Item1 = result;
            }

            if(int.TryParse(sizeY.text, out result))
            {
                size.Item2 = result;
            }

            if(int.TryParse(winLength.text, out result))
            {
                win = result;
            }

            if (size.Item1 <= 0 || size.Item2 <= 0 || win == 0)
            {
                return;
            }

            Hide();

            if (classicMod.isOn) ApplicationController.Instance.StartClassic(size, win);
            else ApplicationController.Instance.StartBigClassic(size, win);
        }
    }
}
