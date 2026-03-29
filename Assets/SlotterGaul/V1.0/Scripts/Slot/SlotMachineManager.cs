#region v1.0
//using UnityEngine;

//namespace SlotterGaul
//{
//    public class SlotMachineManager : MonoBehaviour
//    {
//        public SlotMachineDefinition Definition;
//        public PlayerData PlayerData;

//        private void Start()
//        {
//            Debug.Log($"Machine: {Definition.MachineName}");
//            Debug.Log($"Grid: {Definition.Columns} x {Definition.Rows}");
//            Debug.Log($"Coins: {PlayerData.Coins}");
//        }
//    }
//}
#endregion
#region V2.0
using UnityEngine;

namespace SlotterGaul
{
    public class SlotMachineManager : MonoBehaviour
    {
        public SlotMachineDefinition Definition;
        public PlayerData PlayerData;
        public GameObject SymbolPrefab;

        private SlotReel[] m_Reels;

        private void Start()
        {
            BuildReels();
        }

        private void BuildReels()
        {
            m_Reels = new SlotReel[Definition.Columns];
            float startX = -(Definition.Columns - 1) * 0.6f;

            for (int col = 0; col < Definition.Columns; col++)
            {
                var reelObject = new GameObject($"Reel_{col}");
                reelObject.transform.parent = transform;
                reelObject.transform.localPosition = new Vector3(startX + col * 1.2f, 0, 0);

                var reel = reelObject.AddComponent<SlotReel>();
                reel.RowCount = Definition.Rows;
                reel.SymbolPrefab = SymbolPrefab;
                reel.AvailableSymbols = Definition.Symbols;
                reel.Init();

                m_Reels[col] = reel;
            }

            Debug.Log($"Built {m_Reels.Length} reels with {Definition.Rows} rows each");
        }
    }
}
#endregion