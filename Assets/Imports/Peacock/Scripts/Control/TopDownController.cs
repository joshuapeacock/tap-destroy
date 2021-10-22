using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.Control
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class TopDownController : MonoBehaviour
    {
        public float moveSpeed = 10;
        public float turnSpeed = 10;

        public bool canMove;
        [HideInInspector] public Vector3 moveDirection;

        private Rigidbody rb;
        private Animator anim;
        private Quaternion targetRotation;

        // Cache
        private Vector3 direction;

        public virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();
            moveDirection = Vector3.forward;
        }

        private void Start()
        {
            canMove = true;
        }

        public virtual void Update()
        {
            targetRotation = Quaternion.LookRotation(moveDirection);
        }

        public virtual void FixedUpdate()
        {
            if (canMove)
                rb.velocity = moveSpeed * moveDirection;
            else
                rb.velocity = Vector3.zero;

            rb.rotation = Quaternion.Lerp(rb.rotation, targetRotation, Time.fixedDeltaTime * turnSpeed);
            rb.angularVelocity = Vector3.zero;
        }
    }
}
