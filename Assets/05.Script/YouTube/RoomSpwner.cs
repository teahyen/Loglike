using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpwner : MonoBehaviour
{
    public int openinDirection;
    // 1 --> �Ʒ� ����
    // 2 --> ���� ����
    // 3 --> ���� ����
    // 4 --> ������ ����

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
                //�Ʒ��� ����� ���� �ʿ��ؿ�
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation, grid.transform);
            }
            else if (openinDirection == 2)
            {
                //���� ����� ���� �ʿ��ؿ�
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation, grid.transform);
            }
            else if (openinDirection == 3)
            {
                //���ʶ� ����� ���� �ʿ��ؿ�
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation, grid.transform);
            }
            else if (openinDirection == 4)
            {
                //�����ʶ� ����� ���� �ʿ��ؿ�
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
            if(col.GetComponent<RoomSpwner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity,grid.transform);
            }
            Destroy(gameObject);
            spawned = true;
        }    
    }
}
