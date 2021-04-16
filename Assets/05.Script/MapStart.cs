using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStart : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject StartTaget;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag==("Player"))
        {
            Player.transform.position = StartTaget.transform.position;
        }
    }
}
