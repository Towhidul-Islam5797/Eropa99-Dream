#region Sprint 1
using UnityEngine;

namespace SlotterGaul.V2
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "SlotterGaul/V2.0/Player Data")]
    public class PlayerData : ScriptableObject
    {
        public long coins = 10000;

        public bool TrySpend(long amount)
        {
            if (coins < amount) return false;
            coins -= amount;
            return true;
        }

        public void AddCoins(long amount)
        {
            coins += amount;
        }
    }
}
#endregion