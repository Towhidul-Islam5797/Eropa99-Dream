using UnityEngine;

namespace SlotterGaul.V2
{
    public class SlotMachineManager : MonoBehaviour
    {
        public SlotMachineConfig config;
        public PlayerData playerData;
        public SlotGrid slotGrid;

        // index into config.betOptions array
        private int _betIndex = 0;

        public long CurrentBet => config.betOptions[_betIndex];

        [ContextMenu("Spin")]
        public void Spin()
        {
            if (!playerData.TrySpend(CurrentBet))
            {
                Debug.Log("Not enough coins to spin.");
                return;
            }

            Debug.Log($"Bet: {CurrentBet} | Coins before win: {playerData.coins}");

            SpinResult result = slotGrid.GetCurrentResult();

            long winAmount = WinEvaluator.Evaluate(result, config, CurrentBet);

            if (winAmount > 0)
            {
                playerData.AddCoins(winAmount);
                Debug.Log($"WIN! +{winAmount} coins | Total coins: {playerData.coins}");
            }
            else
            {
                Debug.Log($"No win. Total coins: {playerData.coins}");
            }
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
    }
}