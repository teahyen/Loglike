using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distroyer : MonoBehaviour
{
    public int openinDirection;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == ("SpawnPoint"))
        {
            Destroy(col.gameObject);
        }
    }
}
