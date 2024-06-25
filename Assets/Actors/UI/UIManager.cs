using UnityEngine;

namespace Game
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
