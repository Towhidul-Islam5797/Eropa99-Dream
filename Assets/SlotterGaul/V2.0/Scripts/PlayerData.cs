#region Sprint 1
//using UnityEngine;

//namespace SlotterGaul.V2
//{
//    [CreateAssetMenu(fileName = "PlayerData", menuName = "SlotterGaul/V2.0/Player Data")]
//    public class PlayerData : ScriptableObject
//    {
//        public long coins = 10000;

//        public bool TrySpend(long amount)
//        {
//            if (coins < amount) return false;
//            coins -= amount;
//            return true;
//        }

//        public void AddCoins(long amount)
//        {
//            coins += amount;
//        }
//    }
//}
#endregion

#region Milestone 3 Sprint 2
//using UnityEngine;

//namespace SlotterGaul.V2
//{
//    [CreateAssetMenu(fileName = "PlayerData", menuName = "SlotterGaul/V2.0/Player Data")]
//    public class PlayerData : ScriptableObject
//    {
//        private const string CoinsKey = "PlayerData_Coins";
//        private const long DefaultCoins = 10000;

//        public long coins { get; private set; }

//        private void OnEnable()
//        {
//            Load();
//        }

//        public bool TrySpend(long amount)
//        {
//            if (coins < amount) return false;
//            coins -= amount;
//            Save();
//            return true;
//        }

//        public void AddCoins(long amount)
//        {
//            coins += amount;
//            Save();
//        }

//        private void Save()
//        {
//            PlayerPrefs.SetString(CoinsKey, coins.ToString());
//            PlayerPrefs.Save();
//        }

//        private void Load()
//        {
//            bool isFirstLaunch = !PlayerPrefs.HasKey("AppInitialized");

//            if (isFirstLaunch)
//            {
//                PlayerPrefs.DeleteAll();
//                PlayerPrefs.SetInt("AppInitialized", 1);
//                PlayerPrefs.Save();
//                coins = DefaultCoins;
//                return;
//            }

//            string saved = PlayerPrefs.GetString(CoinsKey, "");
//            coins = string.IsNullOrEmpty(saved) ? DefaultCoins : long.Parse(saved);
//        }
//    }
//}
#endregion

#region Milestone 3 Sprint 3
using UnityEngine;
using System.Security.Cryptography;
using System.Text;

namespace SlotterGaul.V2
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "SlotterGaul/V2.0/Player Data")]
    public class PlayerData : ScriptableObject
    {
        private const string CoinsKey = "PlayerData_Coins";
        private const string HashKey = "PlayerData_Hash";
        private const string AppInitKey = "AppInitialized";
        private const string Secret = "eropa99dream_s3cr3t";
        private const long DefaultCoins = 10000;

        public long coins { get; private set; }

        private void OnEnable()
        {
            Load();
        }

        public bool TrySpend(long amount)
        {
            if (coins < amount) return false;
            coins -= amount;
            Save();
            return true;
        }

        public void AddCoins(long amount)
        {
            coins += amount;
            Save();
        }

        private void Save()
        {
            string value = coins.ToString();
            PlayerPrefs.SetString(CoinsKey, value);
            PlayerPrefs.SetString(HashKey, ComputeHash(value));
            PlayerPrefs.Save();
        }

        private void Load()
        {
            bool isFirstLaunch = !PlayerPrefs.HasKey(AppInitKey);

            if (isFirstLaunch)
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetInt(AppInitKey, 1);
                PlayerPrefs.Save();
                coins = DefaultCoins;
                Save();
                return;
            }

            string saved = PlayerPrefs.GetString(CoinsKey, "");
            string savedHash = PlayerPrefs.GetString(HashKey, "");

            if (string.IsNullOrEmpty(saved) || savedHash != ComputeHash(saved))
            {
                Debug.LogWarning("PlayerData: tamper detected or corrupt save. Resetting coins.");
                coins = DefaultCoins;
                Save();
                return;
            }

            coins = long.Parse(saved);
        }

        private string ComputeHash(string value)
        {
            string input = value + Secret;
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
#endregion
