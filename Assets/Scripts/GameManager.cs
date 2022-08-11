using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    bool gameOver = true;
    public bool GameOver { get { return gameOver; } }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
