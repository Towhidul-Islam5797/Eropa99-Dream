#region Sprint 4
// This class represents a single reel in a slot machine game. It manages the symbols displayed on the reel and their positions.
//using UnityEngine;

//namespace SlotterGaul.V2
//{
//    public class SlotReel : MonoBehaviour
//    {
//        private SlotSymbolView[] _views;

//        public void Init(int rows, float cellSpacing)
//        {
//            _views = new SlotSymbolView[rows];

//            for (int row = 0; row < rows; row++)
//            {
//                GameObject cell = new GameObject($"Cell_{row}");
//                cell.transform.SetParent(transform, false);
//                cell.transform.localPosition = new Vector3(0, row * cellSpacing, 0);

//                _views[row] = cell.AddComponent<SlotSymbolView>();
//            }
//        }

//        public void SetSymbols(SlotSymbol[] symbols)
//        {
//            for (int row = 0; row < _views.Length; row++)
//            {
//                _views[row].SetSymbol(symbols[row]);
//            }
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
    public class SlotReel : MonoBehaviour
    {
        private SlotSymbolView[] _views;
        private SlotSymbol[] _allSymbols;

        public void Init(int rows, float cellSpacing, SlotSymbol[] allSymbols)
        {
            _allSymbols = allSymbols;
            _views = new SlotSymbolView[rows];

            for (int row = 0; row < rows; row++)
            {
                GameObject cell = new GameObject($"Cell_{row}");
                cell.transform.SetParent(transform, false);
                cell.transform.localPosition = new Vector3(0, row * cellSpacing, 0);

                _views[row] = cell.AddComponent<SlotSymbolView>();
            }
        }

        public void SetSymbols(SlotSymbol[] symbols)
        {
            for (int row = 0; row < _views.Length; row++)
            {
                _views[row].SetSymbol(symbols[row]);
            }
        }

        // Spins rapidly through random symbols then snaps to finalSymbols
        // spinDuration: how long this reel spins before stopping
        // onStopped: called when this reel finishes
        public IEnumerator SpinAndStop(SlotSymbol[] finalSymbols, float spinDuration, Action onStopped)
        {
            float elapsed = 0f;
            float shuffleInterval = 0.07f;
            float nextShuffle = 0f;

            while (elapsed < spinDuration)
            {
                elapsed += Time.deltaTime;

                if (elapsed >= nextShuffle)
                {
                    nextShuffle = elapsed + shuffleInterval;
                    ShowRandomSymbols();
                }

                yield return null;
            }

            // snap to final result
            SetSymbols(finalSymbols);

            onStopped?.Invoke();
        }

        private void ShowRandomSymbols()
        {
            foreach (var view in _views)
            {
                view.SetSymbol(_allSymbols[UnityEngine.Random.Range(0, _allSymbols.Length)]);
            }
        }
    }
}
#endregion
