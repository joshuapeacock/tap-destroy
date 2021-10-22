using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Peacock.IO
{
    public class PlayerNameSetter : MonoBehaviour
    {
        [SerializeField] private InputField nameInput;

        private void Awake()
        {
            if (PlayerPrefs.HasKey("Name"))
            {
                nameInput.text = PlayerPrefs.GetString("Name");
            }
        }

        public void SetName()
        {
            if(nameInput.text != "")
            {
                PlayerPrefs.SetString("Name", nameInput.text);
            }
        }
    }
}
