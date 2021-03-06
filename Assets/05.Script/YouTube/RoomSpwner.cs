using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpwner : MonoBehaviour
{
    public int openinDirection;
    // 1 --> 아래 연결
    // 2 --> 위에 연결
    // 3 --> 왼쪽 연결
    // 4 --> 오른쪽 연결

    private RoomTemp templates;
    private int rand;
    private GameObject grid;
    private bool spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemp>();
        grid = GameObject.Find("Grid");
        Invoke("Spanw", 0.1f);
    }
    private void Spanw()
    {
        if (!spawned)
        {
            if (openinDirection == 1)
            {
                //아래랑 연결될 문이 필요해용
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation, grid.transform);
            }
            else if (openinDirection == 2)
            {
                //위랑 연결될 문이 필요해용
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation, grid.transform);
            }
            else if (openinDirection == 3)
            {
                //왼쪽랑 연결될 문이 필요해용
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation, grid.transform);
            }
            else if (openinDirection == 4)
            {
                //오른쪽랑 연결될 문이 필요해용
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation, grid.transform);
            }
            spawned = true;
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("SpawnPoint"))
        {
            RoomSpwner rs = col.GetComponent<RoomSpwner>();
            if (rs != null && rs.spawned == false && spawned == false)
            {
                //Instantiate(templates.closedRoom, transform.position, transform.rotation, grid.transform);
                Destroy(col.gameObject);
                Destroy(gameObject);
                spawned = true;
            }
        }    
    }
}
