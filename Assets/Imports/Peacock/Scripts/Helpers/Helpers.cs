using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock
{
    public static class Helpers
    {
        public static Vector3 RemoveYVector(Vector3 vector)
        {
            return new Vector3(vector.x, 0, vector.z);
        }
    }
}
