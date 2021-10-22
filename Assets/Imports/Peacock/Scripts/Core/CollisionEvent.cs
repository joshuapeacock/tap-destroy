using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Peacock.Core
{
    [System.Serializable]
    public class MyCollisionEvent : UnityEvent<Collision>
    {
    }

    public class CollisionEvent : MonoBehaviour
    {
        public LayerMask layerMask;
        public string[] tags;
        [Header("Events")]
        public MyCollisionEvent onCollisionEvent;

        private void OnCollisionEnter(Collision collision)
        {
            if (IsInLayerMask(collision.gameObject) && HasTag(collision.gameObject, tags))
            {
                onCollisionEvent.Invoke(collision);
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
