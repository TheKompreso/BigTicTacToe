using Game.UI;
using UnityEngine;

namespace Game
{
    [DefaultExecutionOrder(-1)]
    public class GameAssets : MonoBehaviour
    {
        public Sprite Image_None;
        public Sprite Image_Cross;
        public Sprite Image_Zero;

        public Cell cell;

        public static GameAssets Instance;
        private void Awake()
        {
            Instance = this;
        }
    }
}
