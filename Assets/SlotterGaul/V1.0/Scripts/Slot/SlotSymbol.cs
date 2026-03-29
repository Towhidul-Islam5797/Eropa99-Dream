using UnityEngine;

namespace SlotterGaul
{
    [CreateAssetMenu(fileName = "SlotSymbol", menuName = "SlotterGaul/SlotSymbol")]
    public class SlotSymbol : ScriptableObject
    {
        public string SymbolName;
        public Sprite Icon;
        public int PayoutValue;
    }
}