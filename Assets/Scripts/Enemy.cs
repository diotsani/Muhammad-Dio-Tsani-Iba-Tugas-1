using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            enemyManager.enemyDestroyed.Add(enemyManager.enemyList[0]);
            Debug.Log("Goal");
            Destroy(gameObject);
        }
    }
}
