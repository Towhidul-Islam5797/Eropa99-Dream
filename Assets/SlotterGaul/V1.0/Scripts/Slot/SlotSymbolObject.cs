using UnityEngine;

namespace SlotterGaul
{
    public class SlotSymbolObject : MonoBehaviour
    {
        public SlotSymbol Symbol;
        private SpriteRenderer m_SpriteRenderer;

        private void Awake()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetSymbol(SlotSymbol symbol)
        {
            Symbol = symbol;
            m_SpriteRenderer.sprite = symbol.Icon;
        }
    }
}