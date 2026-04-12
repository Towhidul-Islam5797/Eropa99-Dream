using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlotterGaul.V2
{
    public class SlotMachineUI : MonoBehaviour
    {
        public SlotMachineManager manager;
        public PlayerData playerData;

        public TextMeshProUGUI coinText;
        public TextMeshProUGUI betText;
        public TextMeshProUGUI winText;

        public Button spinButton;
        public Button increaseBetButton;
        public Button decreaseBetButton;

        private void Start()
        {
            spinButton.onClick.AddListener(OnSpinPressed);
            increaseBetButton.onClick.AddListener(OnIncreaseBet);
            decreaseBetButton.onClick.AddListener(OnDecreaseBet);

            UpdateUI();
        }

        private void OnSpinPressed()
        {
            manager.Spin();
            UpdateUI();
        }

        private void OnIncreaseBet()
        {
            manager.IncreaseBet();
            UpdateUI();
        }

        private void OnDecreaseBet()
        {
            manager.DecreaseBet();
            UpdateUI();
        }

        private void UpdateUI()
        {
            coinText.text = $"Coins: {playerData.coins}";
            betText.text = $"{manager.CurrentBet}";

            if (winText != null)
                winText.text = "";
        }

        public void ShowWin(long amount)
        {
            if (winText != null)
                winText.text = amount > 0 ? $"WIN! +{amount}" : "";
        }
    }
}