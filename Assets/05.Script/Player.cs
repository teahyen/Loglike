using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movePover = 1;
    
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        transform.position += moveVelocity * movePover * Time.deltaTime;


        if (Input.GetAxisRaw("Vartical") < 0)
        {
            moveVelocity = Vector3.up;
        }

        else if (Input.GetAxisRaw("Vartical") > 0)
        {
            moveVelocity = Vector3.down;
        }
    }
}
