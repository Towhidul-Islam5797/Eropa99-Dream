#region Sprint 1
//using UnityEngine;

//namespace SlotterGaul.V2
//{
//    [CreateAssetMenu(fileName = "SlotSymbol", menuName = "SlotterGaul/V2.0/Slot Symbol")]
//    public class SlotSymbol : ScriptableObject
//    {
//        public string symbolName;
//        public Sprite sprite;
//        public int baseValue;
//    }
//}
#endregion
#region Sprint 2
using UnityEngine;

namespace SlotterGaul.V2
{
    [CreateAssetMenu(fileName = "SlotSymbol", menuName = "SlotterGaul/V2.0/Slot Symbol")]
    public class SlotSymbol : ScriptableObject
    {
        public string symbolName;
        public Sprite sprite;
        public Color color = Color.white;
        public int baseValue;
    }
}
#endregion