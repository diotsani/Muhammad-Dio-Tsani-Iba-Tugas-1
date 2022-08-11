using Manager;
using Raycast;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human
{
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
            scoreManager.GameOver();
        }
    }
}

