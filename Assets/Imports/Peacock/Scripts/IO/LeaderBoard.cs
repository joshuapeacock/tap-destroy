using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.IO
{
    public class LeaderBoard : MonoBehaviour
    {
        private const float TICK_RATE = 0.3f;

        public List<Player> allPlayers;

        private void OnValidate()
        {
            if (allPlayers == null)
            {
                allPlayers = GetPlayerList();
            }
        }

        private void Start()
        {
            StartCoroutine(Tick());
        }

        private IEnumerator Tick()
        {
            while (enabled)
            {
                allPlayers.Sort();
                yield return new WaitForSeconds(TICK_RATE);
            }
        }

        public int GetPlayerIndex()
        {
            int index = 0;
            for (int i = 0; i < allPlayers.Count; i++)
            {
                if (allPlayers[i].isPlayer)
                    index = i;
            }
            return index;
        }

        private List<Player> GetPlayerList()
        {
            var allPlayersArray = FindObjectsOfType<Player>();
            allPlayers = new List<Player>(allPlayersArray.Length);
            for (int i = 0; i < allPlayersArray.Length; i++)
            {
                allPlayers.Add(allPlayersArray[i]);
            }
            return allPlayers;
        }
    }
}
