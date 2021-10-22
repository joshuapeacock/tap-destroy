using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Peacock.IO
{
    public class TimerHud : MonoBehaviour
    {
        [SerializeField] private Text timerText;

        private void Update()
        {
            timerText.text = string.Format("{0:D1}:{1:D2}", Globals.Timer.timeSpan.Minutes, Globals.Timer.timeSpan.Seconds);
        }
    }
}
