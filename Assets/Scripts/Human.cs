using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public ScoreManager scoreManager;
    
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));

        if(transform.position.y <= -5)
        {
            scoreManager.getScore += 50;
            Destroy(gameObject);
            Debug.Log(transform.position);
        }
    }
}
