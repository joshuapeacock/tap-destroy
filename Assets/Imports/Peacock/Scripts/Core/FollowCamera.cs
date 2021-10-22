using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.Core
{
    public class FollowCamera : MonoBehaviour
    {

        public Transform player;
        public float followStrength = 4;
        public float zoomAmount = 25;

        private Quaternion initRotation;
        private float initZoomAmount;

        //cache
        Vector3 startPos;
        Vector3 newPos;
        Vector3 toPos;

        void Awake()
        {
            initZoomAmount = zoomAmount;
            initRotation = transform.rotation;
        }

        void LateUpdate()
        {
            startPos = transform.position;
            newPos = player.position;
            toPos = newPos + transform.forward * -zoomAmount;
            toPos = Vector3.Slerp(startPos, toPos, Time.unscaledDeltaTime * followStrength);
            transform.position = toPos;
        }

        public void Reset()
        {
            zoomAmount = initZoomAmount;
            transform.rotation = initRotation;
        }
    }
}
