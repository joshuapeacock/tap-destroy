using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.Core
{
    public class LookAtCamera : MonoBehaviour
    {
        private Transform cam;

        void Awake()
        {
            cam = Camera.main.transform;
            Debug.Assert(cam, "No object with tag MainCamera found", this);
        }

        void Update()
        {
            transform.LookAt(cam.transform);
            transform.Rotate(0, 180, 0);
        }
    }
}
