using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raycast
{
    public class RaycastManager : MonoBehaviour
    {
        public ScoreManager scoreManager;

        void Update()
        {
            RaycastOnTap();
        }

        void RaycastOnTap()
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit2D && scoreManager.isGameOver == false)
            {
                GameObject hitObject = hit2D.transform.gameObject;
                if (Input.GetMouseButtonDown(0))
                {
                    hitObject.GetComponent<IRaycastable>().Interact();
                }
            }
        }
    }

}
