using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Peacock.IO
{ 
    public class Timer : MonoBehaviour
    {
        public int numSeconds = 120;
        public bool countdown;
        public UnityEvent timeOutEvent;

        public TimeSpan timeSpan;

        private void Awake()
        {
            timeSpan = TimeSpan.FromSeconds(numSeconds);
        }

        private void Update()
        {
            if (countdown)
            {
                timeSpan = timeSpan.Subtract(TimeSpan.FromSeconds(Time.deltaTime));
                if(timeSpan.TotalSeconds < 0)
                {
                    countdown = false;
                    timeOutEvent.Invoke();
                }
            }
        }

        public void StartCountdown()
        {
            countdown = true;
        }

        public void StopCountdown()
        {
            countdown = false;
        }
    }
}
