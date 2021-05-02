using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject Taget;
    public EnemyMove em;
    public int add_Speed;
    public bool isSpeed = true;
    public void Start()
    {
        
    }
    public void Update()
    {
        transform.position =Taget.transform.position;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Play")&&isSpeed)
        {
            em.speed += add_Speed;
        }
        else
        {
            em.speed -= add_Speed;
        }

    }
}
