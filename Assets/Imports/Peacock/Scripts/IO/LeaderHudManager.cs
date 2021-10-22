using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.IO
{ 
    public class LeaderHudManager : MonoBehaviour
    {
        public LeaderHudSlot[] slots;

        private LeaderBoard leaderboard;

        private void Awake()
        {
            leaderboard = Globals.LeaderBoard;
            slots = GetComponentsInChildren<LeaderHudSlot>();
        }

        private void Update()
        {
            if(leaderboard.GetPlayerIndex() > 2)
            {
                slots[slots.Length - 1].gameObject.SetActive(true);
            }
            else
            {
                slots[slots.Length - 1].gameObject.SetActive(false);
            }
        }
    }
}
