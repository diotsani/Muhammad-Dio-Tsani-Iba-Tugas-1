using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public float rayRange = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastOnTap();
    }

    void RaycastOnTap()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.Raycast(worldPoint, Vector2.zero);
        //RaycastHit2D hitInfo = new RaycastHit2D();
        //bool hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), out hitInfo, rayRange);

        if (hit2D)
        {
            GameObject hitObject = hit2D.transform.gameObject;
            if(Input.GetMouseButtonDown(0))
            {
                hitObject.GetComponent<IRaycastable>().Interact();
            }
        }
    }
}
