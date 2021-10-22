using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Peacock.Core
{
    public class SceneReloader : MonoBehaviour
    {
        //public string sceneName = "Scene";

        public void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
