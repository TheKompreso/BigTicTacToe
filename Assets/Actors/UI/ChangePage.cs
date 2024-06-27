using UnityEngine;

namespace Game.UI
{
    public class ChangePage : MonoBehaviour
    {
        [SerializeField] private UIElement oldPage;
        [SerializeField] private UIElement newPage;

        public void Click()
        {
            oldPage?.Hide();
            newPage?.Show();
        }
    }
}
