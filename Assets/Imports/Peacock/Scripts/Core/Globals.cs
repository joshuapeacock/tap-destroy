using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

namespace Peacock.Core
{
    public class Globals : MonoBehaviour
    {
        public static void Vibrate(HapticTypes type)
        {
            if(MMVibrationManager.HapticsSupported() || MMVibrationManager.Android())
            {
                MMVibrationManager.Haptic(type);
            }
        }

        private static void AndroidPermission()
        {
            Handheld.Vibrate();
        }

        public static SceneReloader SceneReloader
        {
            get
            {
                if (s_SceneReloader == null)
                {
                    s_SceneReloader = FindObjectOfType<SceneReloader>();
                    Debug.Assert(s_SceneReloader, "No SceneReloader component found in scene");
                }
                return s_SceneReloader;
            }
        }
        private static SceneReloader s_SceneReloader;
    }
}
