using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour, IRaycastable
{
    public ScoreManager scoreManager;

    void Update()
    {
        if (transform.position.y <= -5)
        {
            scoreManager.getScore += 50;
            Destroy(gameObject);
            Debug.Log(transform.position);
        }
    }
    public void Interact()
    {
        Debug.Log("Interact");
    }
}
