using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCommand : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected void Start()
    {
        //Debug.Log("Base Start");
    }

    protected void Update()
    {
        Move();
    }
    public abstract void Move();

}
