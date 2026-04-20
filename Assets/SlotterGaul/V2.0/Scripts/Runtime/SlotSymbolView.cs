#region Milestone 2 Sprint 7 - Slot Symbol View
using UnityEngine;

namespace SlotterGaul.V2
{
    public class SlotSymbolView : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = gameObject.AddComponent<SpriteRenderer>();
        }

        public void SetSymbol(SlotSymbol symbol)
        {
            if (symbol == null) return;

            if (symbol.sprite != null)
            {
                _renderer.sprite = symbol.sprite;
                _renderer.color = Color.white;
            }
            else
            {
                _renderer.sprite = CreateSquareSprite();
                _renderer.color = symbol.color;
            }
        }

        private Sprite CreateSquareSprite()
        {
            Texture2D tex = new Texture2D(32, 32);
            Color[] pixels = new Color[32 * 32];
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = Color.white;
            tex.SetPixels(pixels);
            tex.Apply();

            return Sprite.Create(tex, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f), 32);
        }
    }
}
#endregion