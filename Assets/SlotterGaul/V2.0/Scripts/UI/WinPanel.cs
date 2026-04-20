#region Description
// This code defines a WinPanel class that manages the display of a win panel in a slot game.
// It includes methods to show the panel with an animated count-up of the win amount and shine effects.
// The panel fades out after a set duration.

// The Show method takes a long amount as input and starts a coroutine to display the win panel.
// The ShowSequence coroutine handles the animation sequence, including scaling the win label, counting up the win amount, animating shine images, and fading out the panel after a delay.
// The code uses the DOTween library for animations, such as scaling, fading, and rotating the shine images.
// The code is organized within the SlotterGaul.V2 namespace and is designed to be attached to a Unity GameObject that represents the win panel in the game's UI.
// The code also includes safety checks to ensure that the win amount is greater than zero before displaying the panel and that shine images are not null before applying animations to them.
// The code is structured to allow for easy customization of animation durations and the ability to reuse the win panel for multiple wins by resetting the state each time it is shown.
#endregion
#region Milestone 2 Sprint 7 - Win Panel
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace SlotterGaul.V2
{
    public class WinPanel : MonoBehaviour
    {
        public GameObject panel;
        public TextMeshProUGUI winLabel;
        public TextMeshProUGUI winAmountText;
        public Image[] shineImages;

        public float countUpDuration = 1.5f;
        public float displayDuration = 2.5f;

        public void Show(long amount)
        {
            if (amount <= 0) return;
            StartCoroutine(ShowSequence(amount));
        }

        private IEnumerator ShowSequence(long amount)
        {
            panel.SetActive(true);

            // reset
            winLabel.transform.localScale = Vector3.zero;
            winAmountText.text = "0";

            foreach (var shine in shineImages)
            {
                if (shine != null)
                {
                    shine.transform.localScale = Vector3.zero;
                    shine.color = new Color(1, 1, 1, 0);
                }
            }

            // punch in the WIN label
            winLabel.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBack);

            // count up the amount
            float elapsed = 0f;
            while (elapsed < countUpDuration)
            {
                elapsed += Time.deltaTime;
                long displayed = (long)(amount * Mathf.Clamp01(elapsed / countUpDuration));
                winAmountText.text = $"+{displayed}";
                yield return null;
            }
            winAmountText.text = $"+{amount}";

            // animate shine images
            foreach (var shine in shineImages)
            {
                if (shine == null) continue;
                shine.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
                shine.DOFade(1f, 0.3f);
                shine.transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)
                    .SetLoops(-1, LoopType.Restart);
            }

            // wait then hide
            yield return new WaitForSeconds(displayDuration);

            // fade out
            CanvasGroup cg = panel.GetComponent<CanvasGroup>();
            if (cg == null) cg = panel.AddComponent<CanvasGroup>();

            cg.DOFade(0f, 0.4f).OnComplete(() =>
            {
                panel.SetActive(false);
                cg.alpha = 1f;

                // stop shine rotations
                foreach (var shine in shineImages)
                {
                    if (shine != null)
                        shine.transform.DOKill();
                }
            });
        }
    }
}
#endregion