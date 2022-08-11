using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : BaseCommand
{
    
    public override void Move()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));
    }
}
