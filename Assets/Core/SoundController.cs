using UnityEngine;

namespace Game.Sound
{
    public enum Sounds
    {
        click,
        hover,
        painting,
    }

    public class SoundController : MonoBehaviour
    {
        private AudioSource m_AudioSource;

        [SerializeField] private AudioClip ClickSound;
        [SerializeField] private AudioClip HoverSound;
        [SerializeField] private AudioClip PaintingSound;

        public static SoundController Instance { get; private set; }
        private void Awake()
        {
            Instance = this;
            m_AudioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(Sounds sound)
        {
            switch (sound)
            {
                case Sounds.click: m_AudioSource.PlayOneShot(ClickSound); break;
                case Sounds.hover: m_AudioSource.PlayOneShot(HoverSound); break;
                case Sounds.painting: m_AudioSource.PlayOneShot(PaintingSound); break;
            }
        }
    }
}
