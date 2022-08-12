using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public delegate void GameDelegate();
        public static event GameDelegate OnGameStarted;
        public static event GameDelegate OnGameOver;

        public static GameManager Instance;

        bool isGameOver = true;
        public bool GameOver { get { return isGameOver; } }

        [Header("GameObject")]
        public GameObject panelGameOver;

        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            isGameOver = false;
        }

        private void OnEnable()
        {
            ScoreManager.OnPlayerEnd += OnPlayerEnd;
        }

        private void OnDestroy()
        {
            ScoreManager.OnPlayerEnd -= OnPlayerEnd;
        }

        void OnPlayerStart()
        {
            isGameOver = false;
            Debug.Log("GM Play Game");
        }

        void OnPlayerEnd()
        {
            isGameOver = true;

            panelGameOver.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("GM Game Over");
        }
    }
}

