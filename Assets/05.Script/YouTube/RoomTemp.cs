using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemp : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnBoss;
    public GameObject Boss;
    private void Update()
    {
        if(waitTime <= 0&&spawnBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(Boss, rooms[i].transform.position, Quaternion.identity);
                    spawnBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
