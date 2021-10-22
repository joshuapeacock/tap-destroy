using UnityEngine;

namespace Peacock.Math
{
    [System.Serializable]
    public class Bezier : System.Object
    {
        public Vector3 p0;
        public Vector3 p1;
        public Vector3 p2;

        public Bezier(Vector3 v0, Vector3 v1, Vector3 v2)
        {
            this.p0 = v0;
            this.p1 = v1;
            this.p2 = v2;
        }

        public Vector3 GetPointAtTime(float t)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            Vector3 p = uu * p0;
            p += 2 * u * t * p1;
            p += tt * p2;
            return p;
        }
    }
}