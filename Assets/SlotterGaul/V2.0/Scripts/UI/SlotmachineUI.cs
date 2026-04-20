#region Sprint 6
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//namespace SlotterGaul.V2
//{
//    public class SlotMachineUI : MonoBehaviour
//    {
//        public SlotMachineManager manager;
//        public PlayerData playerData;

//        public TextMeshProUGUI coinText;
//        public TextMeshProUGUI betText;
//        public TextMeshProUGUI winText;

//        public Button spinButton;
//        public Button increaseBetButton;
//        public Button decreaseBetButton;
//        public Button maxBetButton;

//        private void Start()
//        {
//            spinButton.onClick.AddListener(OnSpinPressed);
//            increaseBetButton.onClick.AddListener(OnIncreaseBet);
//            decreaseBetButton.onClick.AddListener(OnDecreaseBet);

//            if (maxBetButton != null)
//                maxBetButton.onClick.AddListener(OnMaxBet);

//            UpdateUI();
//        }

//        private void OnSpinPressed()
//        {
//            manager.Spin();
//            UpdateUI();
//        }

//        private void OnIncreaseBet()
//        {
//            manager.IncreaseBet();
//            UpdateUI();
//        }

//        private void OnDecreaseBet()
//        {
//            manager.DecreaseBet();
//            UpdateUI();
//        }

//        private void OnMaxBet()
//        {
//            manager.SetMaxBet();
//            UpdateUI();
//        }

//        public void SetSpinButtonInteractable(bool interactable)
//        {
//            spinButton.interactable = interactable;
//            UpdateUI();
//        }

//        public void ShowWin(long amount)
//        {
//            if (winText != null)
//                winText.text = amount > 0 ? $"WIN! +{amount}" : "";
//        }

//        private void UpdateUI()
//        {
//            coinText.text = $"Coins: {playerData.coins}";
//            betText.text = $"{manager.CurrentBet}";
//        }
//    }
//}
#endregion
#region Sprint 7 - Win Panel
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

        public Button spinButton;
        public Button increaseBetButton;
        public Button decreaseBetButton;
        public Button maxBetButton;

        public WinPanel winPanel;

        private void Start()
        {
            spinButton.onClick.AddListener(OnSpinPressed);
            increaseBetButton.onClick.AddListener(OnIncreaseBet);
            decreaseBetButton.onClick.AddListener(OnDecreaseBet);

            if (maxBetButton != null)
                maxBetButton.onClick.AddListener(OnMaxBet);

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

        private void OnMaxBet()
        {
            manager.SetMaxBet();
            UpdateUI();
        }

        public void SetSpinButtonInteractable(bool interactable)
        {
            spinButton.interactable = interactable;
            UpdateUI();
        }

        public void ShowWin(long amount)
        {
            if (winPanel != null)
                winPanel.Show(amount);
        }

        private void UpdateUI()
        {
            coinText.text = $"Coins: {playerData.coins}";
            betText.text = $"{manager.CurrentBet}";
        }
    }
}
#endregion