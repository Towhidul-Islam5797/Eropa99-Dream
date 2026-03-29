using UnityEngine;

namespace SlotterGaul
{
    public class SlotReel : MonoBehaviour
    {
        public int RowCount;
        public float CellSize = 1.2f;
        public GameObject SymbolPrefab;
        public SlotSymbol[] AvailableSymbols;

        private SlotSymbolObject[] m_Symbols;

        public void Init()
        {
            m_Symbols = new SlotSymbolObject[RowCount];

            for (int row = 0; row < RowCount; row++)
            {
                var go = Instantiate(SymbolPrefab, transform);
                go.transform.localPosition = new Vector3(0, -row * CellSize, 0);
                m_Symbols[row] = go.GetComponent<SlotSymbolObject>();
                m_Symbols[row].SetSymbol(GetRandomSymbol());
            }
        }

        public SlotSymbol GetRandomSymbol()
        {
            return AvailableSymbols[Random.Range(0, AvailableSymbols.Length)];
        }

        public SlotSymbol[] GetCurrentSymbols()
        {
            var result = new SlotSymbol[RowCount];
            for (int i = 0; i < RowCount; i++)
                result[i] = m_Symbols[i].Symbol;
            return result;
        }
    }
}