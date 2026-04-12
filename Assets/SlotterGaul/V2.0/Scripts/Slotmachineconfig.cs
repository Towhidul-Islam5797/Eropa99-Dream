using UnityEngine;

namespace SlotterGaul.V2
{
    [CreateAssetMenu(fileName = "SlotMachineConfig", menuName = "SlotterGaul/V2.0/Slot Machine Config")]
    public class SlotMachineConfig : ScriptableObject
    {
        public int columns = 6;
        public int rows = 5;

        public SlotSymbol[] symbols;

        public int[] betOptions = { 100, 500, 1000, 5000 };

        // how many of the same symbol must appear on the grid to count as a win
        public int minSymbolCountToWin = 8;
    }
}