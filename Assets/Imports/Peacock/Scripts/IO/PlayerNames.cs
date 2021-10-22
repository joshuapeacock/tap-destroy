using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;

namespace Peacock.IO
{
    public class PlayerNames : MonoBehaviour
    {
        TextAsset usernames;
        public string[] names;

        void PopulateNames()
        {
            usernames = Resources.Load("Usernames") as TextAsset;
            MemoryStream fs = new MemoryStream(usernames.bytes);
            string content = "";
            using (StreamReader read = new StreamReader(fs, true))
            {
                content = read.ReadToEnd();
            }
            names = Regex.Split(content, "\r\n?|\n", RegexOptions.Singleline);
        }

        public string GetRandomName()
        {
            if (names.Length == 0) PopulateNames();
            return names[Random.Range(0, names.Length)];
        }
    }
}
