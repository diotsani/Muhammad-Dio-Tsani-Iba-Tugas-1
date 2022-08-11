using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpecial : Enemy

    {
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
    }

}
