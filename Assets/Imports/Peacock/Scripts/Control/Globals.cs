using UnityEngine;

namespace Peacock.Control
{
    public class Globals : MonoBehaviour
    {
        public static Joystick Joystick
        {
            get
            {
                if (s_Joystick == null)
                    s_Joystick = FindObjectOfType<Joystick>();
                return s_Joystick;
            }
        }
        private static Joystick s_Joystick;
    }
}
