using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.UI
{
    using UnityEngine.UI;

    public class NameHud : MonoBehaviour
    {
        [SerializeField] private Text nameText;

        private string name;

        private void OnValidate()
        {
            if (nameText == null) nameText = GetComponentInChildren<Text>();
        }

        private void Start()
        {
            UpdateName();
        }

        private void Update()
        {
            if(name != transform.root.gameObject.name)
            {
                UpdateName();
            }
        }

        private void UpdateName()
        {
            name = transform.root.gameObject.name;
            nameText.text = name.ToString();
        }
    }
}

