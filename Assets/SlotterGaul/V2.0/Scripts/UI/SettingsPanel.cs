using UnityEngine;
using UnityEngine.Audio;

namespace SlotterGaul.V2
{
    // Attach this to the SettingsPanel GameObject.
    // Wire each method below directly into a Slider's "On Value Changed (Single)" event in the Inspector.
    // Volume is saved locally using PlayerPrefs - no dependency on GemHunter's GameManager.
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;

        private const string MainVolumeKey = "MainVolume";
        private const string MusicVolumeKey = "MusicVolume";
        private const string SFXVolumeKey = "SFXVolume";

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