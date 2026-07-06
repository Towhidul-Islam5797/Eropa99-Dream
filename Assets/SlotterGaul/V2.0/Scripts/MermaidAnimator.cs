using System.Collections;
using UnityEngine;

namespace SlotterGaul.V2
{
    public class MermaidAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float returnToIdleDelay = 3f;

        public void PlayWin()
        {
            StopAllCoroutines();
            animator.SetTrigger("Win");
            StartCoroutine(ReturnToIdle());
        }

        public void PlayLose()
        {
            StopAllCoroutines();
            animator.SetTrigger("Lose");
            StartCoroutine(ReturnToIdle());
        }

        private IEnumerator ReturnToIdle()
        {
            yield return new WaitForSeconds(returnToIdleDelay);
            animator.SetTrigger("Idle");
        }
    }
}