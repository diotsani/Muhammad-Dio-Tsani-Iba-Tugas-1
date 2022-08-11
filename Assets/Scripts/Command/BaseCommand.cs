using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public abstract class BaseCommand : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        [SerializeField] protected float _randomSpeed;

        protected void Start()
        {
            //Debug.Log("Base Start");
        }

        protected void FixedUpdate()
        {
            MoveZigZag();
        }

        protected void Update()
        {
            MoveDown();

        }
        public abstract void MoveDown();
        public abstract void MoveZigZag();
    }
}

