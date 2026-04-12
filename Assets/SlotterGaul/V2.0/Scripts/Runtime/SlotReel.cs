using UnityEngine;

namespace SlotterGaul.V2
{
    public class SlotReel : MonoBehaviour
    {
        private SlotSymbolView[] _views;

        public void Init(int rows, float cellSpacing)
        {
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
    }
}