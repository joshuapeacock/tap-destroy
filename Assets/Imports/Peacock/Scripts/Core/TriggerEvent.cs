using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Peacock.Core
{
    [System.Serializable]
    public class MyTriggerEvent : UnityEvent<Collider>
    {
    }

    public class TriggerEvent : MonoBehaviour
    {
        public LayerMask layerMask;
        public string[] tags;
        [Header("Events")]
        public MyTriggerEvent onTriggerEnterEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (IsInLayerMask(other.gameObject) && HasTag(other.gameObject, tags))
            {
                onTriggerEnterEvent.Invoke(other);
            }
        }

        private bool IsInLayerMask(GameObject gObject)
        {
            return (layerMask.value & 1 << gObject.layer) != 0;
        }

        private bool HasTag(GameObject gObject, string[] tags)
        {
            if (tags == null || tags.Length == 0)
                return true;

            foreach (string tag in tags)
            {
                if (gObject.CompareTag(tag))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
