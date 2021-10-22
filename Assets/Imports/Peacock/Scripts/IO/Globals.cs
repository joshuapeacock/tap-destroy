using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.IO
{
    public class Globals : MonoBehaviour
    {
        public static LeaderBoard LeaderBoard
        {
            get
            {
                if (s_LeaderBoard == null)
                {
                    s_LeaderBoard = FindObjectOfType<LeaderBoard>();
                    Debug.Assert(s_LeaderBoard, "No Leaderboard component found in scene");
                }
                return s_LeaderBoard;
            }
        }
        private static LeaderBoard s_LeaderBoard;

        public static Timer Timer
        {
            get
            {
                if (s_Timer == null)
                {
                    s_Timer = FindObjectOfType<Timer>();
                    Debug.Assert(s_Timer, "No Timer component found in scene");
                }
                return s_Timer;
            }
        }
        private static Timer s_Timer;

        public static PlayerNames PlayerNames
        {
            get
            {
                if (s_PlayerNames == null)
                {
                    s_PlayerNames = FindObjectOfType<PlayerNames>();
                    Debug.Assert(s_PlayerNames, "No PlayerNames component found in scene");
                }
                return s_PlayerNames;
            }
        }
        private static PlayerNames s_PlayerNames;
    }
}
