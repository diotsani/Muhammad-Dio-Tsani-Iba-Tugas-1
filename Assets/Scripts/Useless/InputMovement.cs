using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    public Human _human;
    Queue<BaseCommand> commands = new Queue<BaseCommand>();

    void Update()
    {
        BaseCommand move = InputMoveCommand();
        if (move != null)
        {
            commands.Enqueue(move);
            move.Move();
        }
    }

    BaseCommand InputMoveCommand()
    {
        return gameObject.AddComponent<MovementCommand>();
    }
}
