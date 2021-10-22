using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.IO
{
    public class LeaderSlotColorSetter : MonoBehaviour
    {
        public Color aiColor;
        public Color playerColor;

        public LeaderHudSlot[] slots;

        private void Awake()
        {
            slots = GetComponentsInChildren<LeaderHudSlot>();

            foreach (LeaderHudSlot s in slots)
            {
                s.aiColor = aiColor;
                s.playerColor = playerColor;
            }
        }
    }
}
