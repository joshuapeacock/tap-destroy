using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.Core
{
    public class RandomYRotation : MonoBehaviour
    {
        private void OnEnable()
        {
            transform.eulerAngles = 
                new Vector3(
                    transform.rotation.x, 
                    Random.Range(0f, 360f), 
                    transform.rotation.z);
        }
    }
}
