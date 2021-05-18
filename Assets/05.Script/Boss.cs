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
}
