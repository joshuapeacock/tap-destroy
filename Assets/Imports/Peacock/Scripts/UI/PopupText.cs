using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Peacock.UI
{
    public class PopupText : MonoBehaviour
    {
        public float distance = 500f;
        public float popTime = 0.25f;
        public float hangTile = 0.25f;
        public float fadeTime = 0.25f;
        [Header("Dependencies")]
        public RectTransform textRect;
        public TextMeshProUGUI textComp;

        private Vector3 initPos;
        private Vector3 initScale;
        private Color initColor;
        private Color fadeColor;

        private void Awake()
        {
            Debug.Assert(textRect);
            Debug.Assert(textComp);
            initPos = textRect.anchoredPosition;
            initScale = textRect.localScale;
            initColor = textComp.color;
            fadeColor = new Color(initColor.r, initColor.g, initColor.b, 0f);
        }

        private void OnEnable()
        {
            textRect.anchoredPosition = initPos;
            textRect.localScale = initScale;
            textComp.color = initColor;
            StartCoroutine(Animate());
        }

        public void SetText(string text)
        {
            textComp.text = text;
        }

        private IEnumerator Animate()
        {
            // Pop up
            var fromPos = initPos;
            var toPos = initPos + (Vector3.up * distance);
            for (float i = 0; i < popTime; i += Time.deltaTime)
            {
                var delta = i / popTime;
                textRect.anchoredPosition = Vector3.Lerp(fromPos, toPos, delta);
                yield return null;
            }
            textRect.anchoredPosition = toPos;

            // Hang
            yield return new WaitForSeconds(hangTile);

            // Fade
            var fromColor = initColor;
            var toColor = fadeColor;
            for (float i = 0; i < fadeTime; i += Time.deltaTime)
            {
                var delta = i / fadeTime;
                textComp.color = Color.Lerp(fromColor, toColor, delta);
                yield return null;
            }
            textComp.color = toColor;

            gameObject.SetActive(false);
        }
    }
}
