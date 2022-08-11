using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecial : Enemy

{
    public float direction;
    float directInterval = 0.3f;
    float timer;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y <= -5)
        {
            scoreManager.Life();

            enemyManager.enemyDestroyed.Add(enemyManager.enemyList[0]);
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
        if(timer > directInterval)
        {
            RandomDirection();
            timer -= directInterval;
        }
    }

    void RandomDirection()
    {
        int rndDirect = Random.Range(0, 3);
        switch(rndDirect)
        {
            case 0: direction= 0f;
                break;
            case 1: direction= 1f;
                break;
            case 2: direction= -1f;
                break;
        }
    }
}
