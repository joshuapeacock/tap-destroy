using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Peacock.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        public Vector3 fireVelocity;
        [Header("Events")]
        public UnityEvent fireEvent;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Fire()
        {
            rb.isKinematic = false;
            rb.velocity = fireVelocity;
            fireEvent.Invoke();
        }
    }
}
