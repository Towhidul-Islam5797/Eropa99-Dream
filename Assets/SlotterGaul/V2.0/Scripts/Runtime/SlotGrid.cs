#region Sprint 4
//using UnityEngine;

//namespace SlotterGaul.V2
//{
//    public class SlotGrid : MonoBehaviour
//    {
//        public SlotMachineConfig config;
//        public float cellSpacing = 1.1f;

//        private SlotReel[] _reels;

//        private void Start()
//        {
//            BuildGrid();
//            Randomize();
//        }

//        private void BuildGrid()
//        {
//            _reels = new SlotReel[config.columns];

//            // calculate top-left starting position so the grid is centered
//            float startX = -(config.columns - 1) * cellSpacing / 2f;
//            float startY = -(config.rows - 1) * cellSpacing / 2f;

//            for (int col = 0; col < config.columns; col++)
//            {
//                GameObject reelObject = new GameObject($"Reel_{col}");
//                reelObject.transform.SetParent(transform, false);
//                reelObject.transform.localPosition = new Vector3(startX + col * cellSpacing, startY, 0);

//                SlotReel reel = reelObject.AddComponent<SlotReel>();
//                reel.Init(config.rows, cellSpacing);

//                _reels[col] = reel;
//            }
//        }

//        // [ContextMenu] lets you call this from the Inspector by right-clicking the component
//        [ContextMenu("Randomize")]
//        public void Randomize()
//        {
//            for (int col = 0; col < config.columns; col++)
//            {
//                SlotSymbol[] symbols = new SlotSymbol[config.rows];
//                for (int row = 0; row < config.rows; row++)
//                {
//                    symbols[row] = config.symbols[Random.Range(0, config.symbols.Length)];
//                }
//                _reels[col].SetSymbols(symbols);
//            }
//        }

//        // returns the current grid as a SpinResult so WinEvaluator can read it
//        public SpinResult GetCurrentResult()
//        {
//            // we re-randomize and capture the result at the same time
//            SpinResult result = new SpinResult(config.columns, config.rows);

//            for (int col = 0; col < config.columns; col++)
//            {
//                SlotSymbol[] symbols = new SlotSymbol[config.rows];
//                for (int row = 0; row < config.rows; row++)
//                {
//                    symbols[row] = config.symbols[Random.Range(0, config.symbols.Length)];
//                }
//                _reels[col].SetSymbols(symbols);
//                result.grid[col] = symbols;
//            }

//            return result;
//        }
//    }
//}
#endregion
#region Sprint 6
using System;
using System.Collections;
using UnityEngine;

namespace SlotterGaul.V2
{
    public class SlotGrid : MonoBehaviour
    {
        public SlotMachineConfig config;
        public float cellSpacing = 1f;

        // how long each reel spins, and delay between reels stopping
        public float baseSpinDuration = 1f;
        public float reelStopDelay = 0.2f;

        private SlotReel[] _reels;

        private void Start()
        {
            BuildGrid();
            Randomize();
        }

        private void BuildGrid()
        {
            _reels = new SlotReel[config.columns];

            float startX = -(config.columns - 1) * cellSpacing / 2f;
            float startY = -(config.rows - 1) * cellSpacing / 2f;

            for (int col = 0; col < config.columns; col++)
            {
                GameObject reelObject = new GameObject($"Reel_{col}");
                reelObject.transform.SetParent(transform, false);
                reelObject.transform.localPosition = new Vector3(startX + col * cellSpacing, startY, 0);

                SlotReel reel = reelObject.AddComponent<SlotReel>();
                reel.Init(config.rows, cellSpacing, config.symbols);

                _reels[col] = reel;
            }
        }

        [ContextMenu("Randomize")]
        public void Randomize()
        {
            for (int col = 0; col < config.columns; col++)
            {
                _reels[col].SetSymbols(GetRandomSymbols());
            }
        }

        // Spins all reels and calls onComplete with the final SpinResult when done
        public void SpinAllReels(Action<SpinResult> onComplete)
        {
            SpinResult result = GenerateResult();
            StartCoroutine(SpinSequence(result, onComplete));
        }

        private IEnumerator SpinSequence(SpinResult result, Action<SpinResult> onComplete)
        {
            int reelsStopped = 0;

            for (int col = 0; col < config.columns; col++)
            {
                int capturedCol = col;
                float spinDuration = baseSpinDuration + col * reelStopDelay;

                StartCoroutine(_reels[capturedCol].SpinAndStop(
                    result.grid[capturedCol],
                    spinDuration,
                    () => reelsStopped++
                ));
            }

            // wait until all reels have stopped
            yield return new WaitUntil(() => reelsStopped == config.columns);

            onComplete?.Invoke(result);
        }

        private SpinResult GenerateResult()
        {
            SpinResult result = new SpinResult(config.columns, config.rows);
            for (int col = 0; col < config.columns; col++)
            {
                result.grid[col] = GetRandomSymbols();
            }
            return result;
        }

        private SlotSymbol[] GetRandomSymbols()
        {
            SlotSymbol[] symbols = new SlotSymbol[config.rows];
            for (int row = 0; row < config.rows; row++)
            {
                symbols[row] = config.symbols[UnityEngine.Random.Range(0, config.symbols.Length)];
            }
            return symbols;
        }
    }
}
#endregion