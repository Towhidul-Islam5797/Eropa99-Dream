using UnityEngine;

namespace SlotterGaul
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "SlotterGaul/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public int Coins = 1000;

        public void AddCoins(int amount)
        {
            Coins += amount;
        }

        public bool SpendCoins(int amount)
        {
            if (Coins < amount) return false;
            Coins -= amount;
            return true;
        }
    }
}