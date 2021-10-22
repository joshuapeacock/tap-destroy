using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.IO
{
    public class Namer : MonoBehaviour
    {
        [SerializeField] private bool isPlayer;

        private void Awake()
        {
            UpdateName();
        }

        public void UpdateName()
        {
            if (isPlayer)
            {
                if (PlayerPrefs.HasKey("Name"))
                {
                    gameObject.name = PlayerPrefs.GetString("Name");
                }
                else
                {
                    gameObject.name = "My Name";
                }
            }
            else
            {
                gameObject.name = Globals.PlayerNames.GetRandomName();
            }
        }
    }
}
