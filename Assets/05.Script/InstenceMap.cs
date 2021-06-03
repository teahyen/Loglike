using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InstenceMap : MonoBehaviour
{
    [Header("1�Ա� 2�Ա� 3�Ա� 4�Ա�")]
    public GameObject[] maps;

    public BoxCollider2D[] WhereFromGo;
    
    public GameObject etc;
    public void Start()
    {
        etc.SetActive(false);
    }
    //�Ʒ��ʿ� �� ���� �ڵ�
    public void OpenDown()
    {
        //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
        List<GameObject> ConnectDown = new List<GameObject>();
        ConnectDown.Add(maps[1]);
        //���� �������� ������ �ϴ� �ڵ�
        int ran_Map = Random.Range(0, ConnectDown.Count);
        //�� ����
        Instantiate(ConnectDown[ran_Map], transform.position + new Vector3(0, -28, 0), Quaternion.identity);
    }

    //���ʿ� �� ���� �ڵ�
    public void OpenUp()
    {
        //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
        List<GameObject> ConnectUp = new List<GameObject>();
        ConnectUp.Add(maps[1]);
        //���� �������� ������ �ϴ� �ڵ�
        int ran_Map = Random.Range(0, ConnectUp.Count);
        //�� ����
        Instantiate(ConnectUp[ran_Map], transform.position + new Vector3(0, 28, 0), Quaternion.identity);
    }

    //������ �� ���� �ڵ�
    public void OpenRight()
    {
        //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
        List<GameObject> ConnectRight = new List<GameObject>();
        ConnectRight.Add(maps[1]);
        //���� �������� ������ �ϴ� �ڵ�
        int ran_Map = Random.Range(0, ConnectRight.Count);
        //�� ����
        Instantiate(ConnectRight[ran_Map], transform.position + new Vector3(28, 0, 0), Quaternion.identity);
    }

    //���� �� ���� �ڵ�
    public void OpenLeft()
    {
        //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
        List<GameObject> ConnectLeft = new List<GameObject>();
        ConnectLeft.Add(maps[1]);
        //���� �������� ������ �ϴ� �ڵ�
        int ran_Map = Random.Range(0, ConnectLeft.Count);
        //�� ����
        Instantiate(ConnectLeft[ran_Map], transform.position + new Vector3(-28, 0, 0), Quaternion.identity);
    }
}
