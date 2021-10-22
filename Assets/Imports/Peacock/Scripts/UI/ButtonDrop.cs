using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Peacock.UI
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Shadow))]
    [RequireComponent(typeof(EventTrigger))]
    public class ButtonDrop : MonoBehaviour
    {
        public Shadow shadow;
        public EventTrigger eventTrigger;
        private RectTransform rect;
        private Vector2 dropAmmount;

        private void OnValidate()
        {
            shadow = GetComponent<Shadow>();
            eventTrigger = GetComponent<EventTrigger>();
        }

        private void Awake()
        {
            if (!shadow) shadow = GetComponent<Shadow>();
            rect = GetComponent<RectTransform>();
            dropAmmount = new Vector3(0, shadow.effectDistance.y, 0);
        }

        public void OnPressed()
        {
            rect.anchoredPosition += dropAmmount;
            shadow.enabled = false;
        }

        public void OnReleased()
        {
            rect.anchoredPosition -= dropAmmount;
            shadow.enabled = true;
        }
    }
}
