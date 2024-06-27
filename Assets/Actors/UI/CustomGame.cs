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
            (int, int) size = (0,0);
            int win = 0;

            if (sizeX.text == "") size.Item1 = 3;
            else size.Item1 = int.Parse(sizeX.text);

            if (sizeY.text == "") size.Item2 = 3;
            else size.Item2 = int.Parse(sizeY.text);

            if (winLength.text == "") win = 3;
            else win = int.Parse(winLength.text);

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
