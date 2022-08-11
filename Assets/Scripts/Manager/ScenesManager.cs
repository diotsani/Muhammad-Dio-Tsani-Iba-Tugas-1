using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class ScenesManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public void Awake()
        {
            Time.timeScale = 1;
        }

        public void ChangeScene(string scenename)
        {
            SceneManager.LoadScene(scenename);
        }
    }
}


