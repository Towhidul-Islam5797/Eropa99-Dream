using UnityEngine;

namespace SlotterGaul.V2
{
    public class SlotGrid : MonoBehaviour
    {
        public SlotMachineConfig config;
        public float cellSpacing = 1.1f;

        private SlotReel[] _reels;

        private void Start()
        {
            BuildGrid();
            Randomize();
        }

        private void BuildGrid()
        {
            _reels = new SlotReel[config.columns];

            // calculate top-left starting position so the grid is centered
            float startX = -(config.columns - 1) * cellSpacing / 2f;
            float startY = -(config.rows - 1) * cellSpacing / 2f;

            for (int col = 0; col < config.columns; col++)
            {
                GameObject reelObject = new GameObject($"Reel_{col}");
                reelObject.transform.SetParent(transform, false);
                reelObject.transform.localPosition = new Vector3(startX + col * cellSpacing, startY, 0);

                SlotReel reel = reelObject.AddComponent<SlotReel>();
                reel.Init(config.rows, cellSpacing);

                _reels[col] = reel;
            }
        }

        // [ContextMenu] lets you call this from the Inspector by right-clicking the component
        [ContextMenu("Randomize")]
        public void Randomize()
        {
            for (int col = 0; col < config.columns; col++)
            {
                SlotSymbol[] symbols = new SlotSymbol[config.rows];
                for (int row = 0; row < config.rows; row++)
                {
                    symbols[row] = config.symbols[Random.Range(0, config.symbols.Length)];
                }
                _reels[col].SetSymbols(symbols);
            }
        }

        // returns the current grid as a SpinResult so WinEvaluator can read it
        public SpinResult GetCurrentResult()
        {
            // we re-randomize and capture the result at the same time
            SpinResult result = new SpinResult(config.columns, config.rows);

            for (int col = 0; col < config.columns; col++)
            {
                SlotSymbol[] symbols = new SlotSymbol[config.rows];
                for (int row = 0; row < config.rows; row++)
                {
                    symbols[row] = config.symbols[Random.Range(0, config.symbols.Length)];
                }
                _reels[col].SetSymbols(symbols);
                result.grid[col] = symbols;
            }

            return result;
        }
    }
}