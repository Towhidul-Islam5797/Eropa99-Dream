using UnityEngine;

namespace SlotterGaul.V2
{
    [CreateAssetMenu(fileName = "SlotSymbol", menuName = "SlotterGaul/V2.0/Slot Symbol")]
    public class SlotSymbol : ScriptableObject
    {
        public string symbolName;
        public Sprite sprite;
        public int baseValue;
    }
}