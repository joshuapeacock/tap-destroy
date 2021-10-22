using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.Core
{
    public class Lifetime : MonoBehaviour
    {
        public float lifeTime = 1f;

        private Coroutine routine;

        private void OnEnable()
        {
            if (routine != null) StopCoroutine(routine);
            routine = StartCoroutine(DisableDelay());
        }

        private IEnumerator DisableDelay()
        {
            yield return new WaitForSeconds(lifeTime);
            gameObject.SetActive(false);
        }
    }
}
