using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.Core
{
    public class Tutorial : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
