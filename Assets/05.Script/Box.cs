using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public LayerMask whatPlayer;
    public bool bFindPlayer;
    public bool bOpenBox;

    public float lookRange;
    public float openRange;
    public bool ismimic;


    void Update()
    {
        bFindPlayer = Physics2D.OverlapCircle(transform.position, lookRange, whatPlayer);
        bOpenBox = Physics2D.OverlapCircle(transform.position, openRange, whatPlayer);
        if (bFindPlayer&&bOpenBox) ToOpenBox();


    }
    
    public void ToOpenBox()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ismimic)
            {
                //耕考 持失
            }
            else
            {
                //雌切 持失
            }
            Destroy(gameObject);
        }
    }
}
