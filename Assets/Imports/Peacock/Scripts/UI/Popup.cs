using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.UI
{
    /// <summary>
    /// Animates the pop up when enabled.  Provides a close() function which animates the popup and disables it.
    /// </summary>
    public class Popup : MonoBehaviour
    {
        private const float ANIMATE_TIME = 0.25f;

        public bool autoClose = false;
        public float lifeTime = 2.0f;

        private RectTransform rect;
        private Vector3 startScale;
        private Coroutine animateCoroutine;

        void Awake()
        {
            rect = GetComponent<RectTransform>();
            startScale = rect.localScale;
        }

        void OnEnable()
        {
            if (animateCoroutine != null)
                StopCoroutine(animateCoroutine);
            animateCoroutine = StartCoroutine(AnimateOpen());
            if (autoClose) StartCoroutine(AutoClose());
        }

        public void Close()
        {
            if (animateCoroutine != null)
            {
                StopCoroutine(animateCoroutine);
                rect.localScale = startScale;
            }
            animateCoroutine = StartCoroutine(AnimateClose());
        }

        public bool IsVisible()
        {
            return gameObject.activeInHierarchy;
        }

        IEnumerator AnimateOpen()
        {
            var toScale = startScale * 1.25f;
            var fromScale = startScale * .25f;
            float time = ANIMATE_TIME * .75f;
            for (float i = 0; i < time; i += Time.unscaledDeltaTime)
            {
                float delta = i / time;
                rect.localScale = Vector3.Lerp(fromScale, toScale, delta);
                yield return null;
            }
            rect.localScale = toScale;

            fromScale = toScale;
            toScale = startScale;
            time = ANIMATE_TIME * .25f;
            for (float i = 0; i < time; i += Time.unscaledDeltaTime)
            {
                float delta = i / time;
                rect.localScale = Vector3.Lerp(fromScale, toScale, delta);
                yield return null;
            }
            rect.localScale = toScale;
        }

        IEnumerator AnimateClose()
        {
            var fromScale = startScale;
            var toScale = startScale * 1.25f;
            float time = ANIMATE_TIME * .25f;
            for (float i = 0; i < time; i += Time.unscaledDeltaTime)
            {
                float delta = i / time;
                rect.localScale = Vector3.Lerp(fromScale, toScale, delta);
                yield return null;
            }
            rect.localScale = toScale;

            toScale = startScale * .25f;
            fromScale = rect.localScale;
            time = ANIMATE_TIME * .75f;
            for (float i = 0; i < time; i += Time.unscaledDeltaTime)
            {
                float delta = i / time;
                rect.localScale = Vector3.Lerp(fromScale, toScale, delta);
                yield return null;
            }
            rect.localScale = toScale;

            //Close
            gameObject.SetActive(false);
        }

        IEnumerator AutoClose()
        {
            yield return new WaitForSeconds(lifeTime);
            Close();
        }
    }
}
