using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Manager
{
    public class ScoreManager : MonoBehaviour
    {
        public delegate void ScoreDelegate();
        public static event ScoreDelegate OnPlayerEnd;
        public static event ScoreDelegate OnPlayerScore;

        GameManager game;

        public List<GameObject> lifePlayer;
        public List<GameObject> deadPlayer;

        public GameObject panelGameOver;

        public TMP_Text textScore;
        public int getScore;

        public bool isGameOver;

        void Start()
        {
            game = GameManager.Instance;

            deadPlayer = new List<GameObject>();
        }

        private void OnEnable()
        {
            GameManager.OnGameStarted += OnGameStarted;
            GameManager.OnGameOver += OnGameOver;
        }

        void Update()
        {
            textScore.text = "Score : " + getScore.ToString();

            Dead();

            if (lifePlayer.Count == 0)
            {
                GameOver();
            }
        }

        void OnGameStarted()
        {
            Debug.Log("SM Play Game");
        }

        void OnGameOver()
        {
            Debug.Log("SM Game Over");
        }

        public void Life()
        {
            deadPlayer.Add(lifePlayer[0]);
            lifePlayer.Remove(lifePlayer[0]);
        }

        public void Dead()
        {
            foreach (GameObject item in deadPlayer)
            {
                item.SetActive(false);
            }
        }

        public void GameOver()
        {
            OnPlayerEnd();

            //isGameOver = true;
            //panelGameOver.SetActive(true);
            //Time.timeScale = 0;
        }
    }
}
