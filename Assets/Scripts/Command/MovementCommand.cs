using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class MovementCommand : BaseCommand
    {
        float directX;
        float timer;
        float directInterval = 1f;

        public override void MoveDown()
        {
            transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        }

        public override void MoveZigZag()
        {
            ConstraintPos(); // Pembatas

            timer += Time.deltaTime;
            if (timer > directInterval)
            {
                RandomDirection();

                transform.Translate(new Vector3(directX, 0, 0) * (_randomSpeed * Time.deltaTime) * 25);

                timer -= directInterval;
            }
        }

        void RandomDirection()
        {
            int rndDirect = Random.Range(0, 3);
            switch (rndDirect)
            {
                case 0:
                    directX = 0f;
                    break;
                case 1:
                    directX = 2f;
                    break;
                case 2:
                    directX = -2f;
                    break;
            }
        }

        void ConstraintPos()
        {
            Vector3 posDefault = transform.position;

            if (transform.position.x >= 8f)
            {
                transform.position = new Vector3(8f, posDefault.y, posDefault.z);
            }

            if (transform.position.x <= -8f)
            {
                transform.position = new Vector3(-8f, posDefault.y, posDefault.z);
            }
        }
    }
}

