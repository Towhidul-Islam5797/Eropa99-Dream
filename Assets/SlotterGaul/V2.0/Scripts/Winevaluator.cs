using System.Collections.Generic;

namespace SlotterGaul.V2
{
    public static class WinEvaluator
    {
        // Returns total coins won. Returns 0 if no win.
        public static long Evaluate(SpinResult result, SlotMachineConfig config, long betAmount)
        {
            var counts = CountSymbols(result, config);
            long totalWin = 0;

            foreach (var symbol in config.symbols)
            {
                if (!counts.TryGetValue(symbol, out int count)) continue;
                if (count < config.minSymbolCountToWin) continue;

                totalWin += symbol.baseValue * count * betAmount;
            }

            return totalWin;
        }

        private static Dictionary<SlotSymbol, int> CountSymbols(SpinResult result, SlotMachineConfig config)
        {
            var counts = new Dictionary<SlotSymbol, int>();

            for (int col = 0; col < config.columns; col++)
            {
                for (int row = 0; row < config.rows; row++)
                {
                    SlotSymbol symbol = result.grid[col][row];
                    if (symbol == null) continue;

                    if (!counts.ContainsKey(symbol))
                        counts[symbol] = 0;

                    counts[symbol]++;
                }
            }

            return counts;
        }
    }
}
