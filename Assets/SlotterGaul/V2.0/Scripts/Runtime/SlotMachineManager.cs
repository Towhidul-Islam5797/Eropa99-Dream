#region Sprint 3
//using UnityEngine;

//namespace SlotterGaul.V2
//{
//    public class SlotMachineManager : MonoBehaviour
//    {
//        public SlotMachineConfig config;
//        public PlayerData playerData;
//        public SlotGrid slotGrid;

//        // index into config.betOptions array
//        private int _betIndex = 0;

//        public long CurrentBet => config.betOptions[_betIndex];

//        [ContextMenu("Spin")]
//        public void Spin()
//        {
//            if (!playerData.TrySpend(CurrentBet))
//            {
//                Debug.Log("Not enough coins to spin.");
//                return;
//            }

//            Debug.Log($"Bet: {CurrentBet} | Coins before win: {playerData.coins}");

//            SpinResult result = slotGrid.GetCurrentResult();

//            long winAmount = WinEvaluator.Evaluate(result, config, CurrentBet);

//            if (winAmount > 0)
//            {
//                playerData.AddCoins(winAmount);
//                Debug.Log($"WIN! +{winAmount} coins | Total coins: {playerData.coins}");
//            }
//            else
//            {
//                Debug.Log($"No win. Total coins: {playerData.coins}");
//            }
//        }

//        public void IncreaseBet()
//        {
//            if (_betIndex < config.betOptions.Length - 1)
//                _betIndex++;
//        }

//        public void DecreaseBet()
//        {
//            if (_betIndex > 0)
//                _betIndex--;
//        }
//    }
//}
#endregion

#region Sprint 4
//using UnityEngine;

//namespace SlotterGaul.V2
//{
//    public class SlotMachineManager : MonoBehaviour
//    {
//        public SlotMachineConfig config;
//        public PlayerData playerData;
//        public SlotGrid slotGrid;
//        public SlotMachineUI UI;

//        private int _betIndex = 0;

//        public long CurrentBet => config.betOptions[_betIndex];

//        [ContextMenu("Spin")]
//        public void Spin()
//        {
//            if (!playerData.TrySpend(CurrentBet))
//            {
//                Debug.Log("Not enough coins to spin.");
//                return;
//            }

//            SpinResult result = slotGrid.GetCurrentResult();

//            long winAmount = WinEvaluator.Evaluate(result, config, CurrentBet);

//            if (winAmount > 0)
//            {
//                playerData.AddCoins(winAmount);
//                Debug.Log($"WIN! +{winAmount} coins | Total coins: {playerData.coins}");
//            }
//            else
//            {
//                Debug.Log($"No win. Total coins: {playerData.coins}");
//            }

//            if (UI != null)
//                UI.ShowWin(winAmount);
//        }

//        public void IncreaseBet()
//        {
//            if (_betIndex < config.betOptions.Length - 1)
//                _betIndex++;
//        }

//        public void DecreaseBet()
//        {
//            if (_betIndex > 0)
//                _betIndex--;
//        }
//    }
//}
#endregion

#region Sprint 6
using UnityEngine;

namespace SlotterGaul.V2
{
    public class SlotMachineManager : MonoBehaviour
    {
        public SlotMachineConfig config;
        public PlayerData playerData;
        public SlotGrid slotGrid;
        public SlotMachineUI ui;

        private int _betIndex = 0;
        private bool _isSpinning = false;

        public long CurrentBet => config.betOptions[_betIndex];

        public void Spin()
        {
            if (_isSpinning) return;

            if (!playerData.TrySpend(CurrentBet))
            {
                Debug.Log("Not enough coins to spin.");
                return;
            }

            _isSpinning = true;
            ui?.SetSpinButtonInteractable(false);

            slotGrid.SpinAllReels(OnSpinComplete);
        }

        private void OnSpinComplete(SpinResult result)
        {
            long winAmount = WinEvaluator.Evaluate(result, config, CurrentBet);

            if (winAmount > 0)
            {
                playerData.AddCoins(winAmount);
                Debug.Log($"WIN! +{winAmount} | Total: {playerData.coins}");
            }
            else
            {
                Debug.Log($"No win. Total: {playerData.coins}");
            }

            _isSpinning = false;
            ui?.SetSpinButtonInteractable(true);
            ui?.ShowWin(winAmount);
        }

        public void IncreaseBet()
        {
            if (_betIndex < config.betOptions.Length - 1)
                _betIndex++;
        }

        public void DecreaseBet()
        {
            if (_betIndex > 0)
                _betIndex--;
        }

        public void SetMaxBet()
        {
            _betIndex = config.betOptions.Length - 1;
        }
    }
}
#endregion
