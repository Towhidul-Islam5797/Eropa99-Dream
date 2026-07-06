#region Summary
/// Auidio manager for the slot game, handling background music and sound effects.
#endregion
#region Milestone 3 Sprint 6 - Slot Audio Manager
using UnityEngine;

namespace SlotterGaul.V2
{
    public class SlotAudioManager : MonoBehaviour
    {
        public static SlotAudioManager Instance { get; private set; }

        [Header("Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        [Header("Clips")]
        public AudioClip backgroundMusic;
        public AudioClip spinSound;
        public AudioClip reelStopSound;
        public AudioClip winSound;
        public AudioClip winChimeSound;
        public AudioClip noWinSound;
        public AudioClip buttonClickSound;

        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(gameObject); 
                return; 
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            if (backgroundMusic != null)
            {
                musicSource.clip = backgroundMusic;
                musicSource.loop = true;
                musicSource.Play();
            }
        }

        public void PlaySpin()
        {
            sfxSource.PlayOneShot(spinSound);
        }

        public void PlayReelStop()
        {
            sfxSource.PlayOneShot(reelStopSound);
        }

        public void PlayWin()
        {
            sfxSource.PlayOneShot(winSound);
            sfxSource.PlayOneShot(winChimeSound);
        }

        public void PlayNoWin()
        {
            sfxSource.PlayOneShot(noWinSound);
        }

        public void PlayButtonClick()
        {
            sfxSource.PlayOneShot(buttonClickSound);
        }
    }
}
#endregion