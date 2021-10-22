using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Peacock.IO
{
    public class LeaderHudSlot : MonoBehaviour
    {
        public bool playerOnlySlot;
        [Space]
        public Image backgroundImage;
        public Text rankText;
        public Text scoreText;
        public Text nameText;
        [HideInInspector] public int index;
        [HideInInspector] public Color aiColor;
        [HideInInspector] public Color playerColor;

        private LeaderBoard leaderboard;
        private int playerIndex;

        private void Awake()
        {
            leaderboard = Globals.LeaderBoard;
            index = transform.GetSiblingIndex();
        }

        private void Update()
        {
            playerIndex = leaderboard.GetPlayerIndex();

            if (playerOnlySlot == false)
            {
                rankText.text = (index + 1).ToString() + ".";
                scoreText.text = leaderboard.allPlayers[index].GetScore().ToString();
                nameText.text = leaderboard.allPlayers[index].name;

                if (leaderboard.allPlayers[index].isPlayer)
                {
                    backgroundImage.color = playerColor;
                }
                else
                {
                    backgroundImage.color = aiColor;
                }
            }
            else
            {
                rankText.text = (playerIndex + 1).ToString() + ".";
                scoreText.text = leaderboard.allPlayers[playerIndex].GetScore().ToString();
                nameText.text = leaderboard.allPlayers[playerIndex].name;
            }

        }
    }
}
