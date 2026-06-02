using UnityEngine;
using UnityEngine.UI;

namespace SlotterGaul
{
    // Attach this to a GameObject that has a Button component.
    // It wires itself up automatically in Start() so you don't need to set anything in the Inspector.
    [RequireComponent(typeof(Button))]
    public class BackButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(SceneLoader.GoToMainMenu);
        }
    }
}