using UnityEngine;
using UnityEngine.Audio;

namespace SlotterGaul.V2
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;

        private const string MainVolumeKey = "MainVolume";
        private const string MusicVolumeKey = "MusicVolume";
        private const string SFXVolumeKey = "SFXVolume";

        private void Start()
        {
            ApplyVolume("MainVolume", PlayerPrefs.GetFloat(MainVolumeKey, 1f));
            ApplyVolume("MusicVolume", PlayerPrefs.GetFloat(MusicVolumeKey, 1f));
            ApplyVolume("SFXVolume", PlayerPrefs.GetFloat(SFXVolumeKey, 1f));
        }

        public void SetMainVolume(float value)
        {
            PlayerPrefs.SetFloat(MainVolumeKey, value);
            ApplyVolume("MainVolume", value);
        }

        public void SetMusicVolume(float value)
        {
            PlayerPrefs.SetFloat(MusicVolumeKey, value);
            ApplyVolume("MusicVolume", value);
        }

        public void SetSFXVolume(float value)
        {
            PlayerPrefs.SetFloat(SFXVolumeKey, value);
            ApplyVolume("SFXVolume", value);
        }

        private void ApplyVolume(string mixerParam, float value)
        {
            if (audioMixer == null) return;
            float db = Mathf.Log10(Mathf.Max(0.0001f, value)) * 30.0f;
            audioMixer.SetFloat(mixerParam, db);
        }
    }
}