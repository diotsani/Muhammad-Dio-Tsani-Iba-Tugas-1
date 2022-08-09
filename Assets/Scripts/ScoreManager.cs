using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public List<GameObject> lifePlayer;
    public List<GameObject> deadPlayer;

    public GameObject panelGameOver;

    public TMP_Text textScore;
    public int getScore;

    public bool isGameOver;

    void Start()
    {
        deadPlayer = new List<GameObject>();
    }

    void Update()
    {
        textScore.text = "Score : " + getScore.ToString();

        Dead();

        if(lifePlayer.Count == 0)
        {
            GameOver();
        }
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
        isGameOver = true;
        panelGameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
