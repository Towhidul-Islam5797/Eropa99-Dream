#region
//using UnityEngine;
//using UnityEngine.SceneManagement;

//namespace SlotterGaul
//{
//    // Attach this to a GameObject in the MainMenu scene.
//    // Call LoadSlot() or LoadGemHunter() from your UI buttons.
//    public class SceneLoader : MonoBehaviour
//    {
//        // Scene names must match exactly what is in File > Build Settings
//        private const string SlotSceneName = "SMV2_Level1";
//        private const string GemHunterSceneName = "Main";
//        private const string MainMenuSceneName = "MainMenu";

//        // Called by the Play Slots button
//        public void LoadSlot()
//        {
//            // Force landscape before loading the slot scene
//            Screen.orientation = ScreenOrientation.LandscapeLeft;
//            SceneManager.LoadScene(SlotSceneName);
//        }

//        // Called by the Play GemHunter button
//        public void LoadGemHunter()
//        {
//            // Force portrait before loading GemHunter
//            Screen.orientation = ScreenOrientation.Portrait;
//            SceneManager.LoadScene(GemHunterSceneName);
//        }

//        // Called by the Back button in any game scene
//        public static void GoToMainMenu()
//        {
//            // Return to portrait for the main menu
//            Screen.orientation = ScreenOrientation.Portrait;
//            SceneManager.LoadScene(MainMenuSceneName);
//        }
//    }
//}
#endregion

using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlotterGaul
{
    // Attach this to a GameObject in the MainMenu scene.
    // Call LoadSlot() or LoadGemHunter() from your UI buttons.
    public class SceneLoader : MonoBehaviour
    {
        // Scene names must match exactly what is in File > Build Settings
        private const string SlotSceneName = "SlotMachine";
        private const string GemHunterSceneName = "LoadingScene";
        private const string MainMenuSceneName = "MainMenu";

        // Called by the Play Slots button
        public void LoadSlot()
        {
            // Force landscape before loading the slot scene
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            SceneManager.LoadScene(SlotSceneName);
        }

        // Called by the Play GemHunter button
        public void LoadGemHunter()
        {
            // Force portrait before loading GemHunter
            Screen.orientation = ScreenOrientation.Portrait;
            SceneManager.LoadScene(GemHunterSceneName);
        }

        // Called by the Back button in any game scene
        public static void GoToMainMenu()
        {
            // Destroy persisting managers/audio components so they don't duplicate/stack when re-entering
            var gameManager = Object.FindFirstObjectByType<Match3.GameManager>();
            if (gameManager != null)
            {
                Object.Destroy(gameManager.gameObject);
            }

            var slotAudioManager = Object.FindFirstObjectByType<SlotterGaul.V2.SlotAudioManager>();
            if (slotAudioManager != null)
            {
                Object.Destroy(slotAudioManager.gameObject);
            }

            // Return to portrait for the main menu
            Screen.orientation = ScreenOrientation.Portrait;
            SceneManager.LoadScene(MainMenuSceneName);
        }

        // Called by the Quit button
        public void QuitGame()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}