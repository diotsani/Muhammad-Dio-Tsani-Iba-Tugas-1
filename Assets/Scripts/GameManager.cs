using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyManager enemyManager;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(worldPoint, Vector2.zero);
            if(hit2D.collider != null)
            {
                if (hit2D.collider.tag == "Enemy")
                {
                    enemyManager.RemoveEnemyList(gameObject);
                    Destroy(hit2D.collider.gameObject);
                    Debug.Log("Enemy Destroy");
                }

                if (hit2D.collider.tag == "Human")
                {
                    Debug.Log("Dont Touch Me");
                }
            }
        }
    }
}
