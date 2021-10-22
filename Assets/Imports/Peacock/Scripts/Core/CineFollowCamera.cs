using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.Core
{
    public class CineFollowCamera : MonoBehaviour
    {
        public enum State
        {
            Home
        }

        public Transform following;
        public float followStrength = 4;
        public bool lockXPos;
        public Vector3[] offsets;
        public Vector3[] rotations;
        public float[] transitionTimes;
        [Header("Runtime")]
        public State state;
        public Vector3 offset;

        private Vector3 initPosition;
        private Quaternion initRotation;
        private Coroutine transitionRoutine;

        private void OnValidate()
        {
            transform.position = following.position + offset;
        }

        void Awake()
        {
            initPosition = transform.position;
            initRotation = transform.rotation;
            offset = offsets[0];
        }

        void LateUpdate()
        {
            transform.position = 
                Vector3.Lerp(
                    transform.position,
                    following.position + offset, 
                    Time.unscaledDeltaTime * followStrength);

            if (lockXPos)
                transform.position = new Vector3(initPosition.x, transform.position.y, transform.position.z);
        }

        public void Reset()
        {
            transform.rotation = initRotation;
        }

        public void SetState(State newState)
        {
            if (state == newState) return;

            if (transitionRoutine != null)
                StopCoroutine(transitionRoutine);
            transitionRoutine = StartCoroutine(TransitionState(newState));
        }

        private IEnumerator TransitionState(State newState)
        {
            var fromPos = offsets[(int)state];
            var toPos = offsets[(int)newState];
            var fromRot = rotations[(int)state];
            var toRot = rotations[(int)newState];
            var time = transitionTimes[(int)newState];
            state = newState;

            for (float i = 0; i < time; i += Time.deltaTime)
            {
                var delta = i / time;
                offset = Vector3.Lerp(fromPos, toPos, delta);
                transform.rotation = Quaternion.Euler(Vector3.Lerp(fromRot, toRot, delta));
                yield return null;
            }

            offset = toPos;
            transform.rotation = Quaternion.Euler(toRot);
        }
    }
}
