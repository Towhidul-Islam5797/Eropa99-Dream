using UnityEngine;

namespace SlotterGaul
{
    [CreateAssetMenu(fileName = "SlotMachineDefinition", menuName = "SlotterGaul/SlotMachineDefinition")]
    public class SlotMachineDefinition : ScriptableObject
    {
        public string MachineName;
        public int Rows = 6;
        public int Columns = 5;
        public int BetAmount = 10;
        public SlotSymbol[] Symbols;
    }
}