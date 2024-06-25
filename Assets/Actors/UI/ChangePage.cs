using UnityEngine;

namespace Game.UI
{
    public class ChangePage : MonoBehaviour
    {
        [SerializeField] private GameObject oldPage;
        [SerializeField] private GameObject newPage;

        public void Click()
        {
            oldPage?.SetActive(false);
            newPage?.SetActive(true);
        }
    }
}
