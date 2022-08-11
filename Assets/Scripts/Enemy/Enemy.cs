using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IRaycastable
{
    //public float speed;
    public ScoreManager scoreManager;
    public EnemyManager enemyManager;

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
    }

    public void Interact()
    {
        scoreManager.getScore += 10;

        Destroy(gameObject);
        enemyManager.enemyDestroyed.Add(enemyManager.enemyList[0]);
        gameObject.SetActive(false);
        Debug.Log("Enemy Destroy");
    }
}
