using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InstenceMap : MonoBehaviour
{
    [Header("���� �ʵ�")]
    public GameObject[] maps = new GameObject[13];
    private GameObject grid;
    //public BoxCollider2D[] WhereFromGo;
    [Header("�� �Ʒ� ������ ����")]
    public bool[] isRode = new bool[4];

    public GameObject etc;
    public void Awake()
    {
        grid = GameObject.Find("Grid");
    }
    public void Start()
    {
        //etc.SetActive(false);
        if (isRode[0])
        {
            OpenUp();
        }
        if (isRode[1])
        {
            OpenDown();
        }
    }
    //�Ʒ��ʿ� �� ���� �ڵ�
    public void OpenDown()
    {
        //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
        List<GameObject> ConnectDown = new List<GameObject>();
        ConnectDown.Add(maps[0]);
        ConnectDown.Add(maps[4]);
        ConnectDown.Add(maps[6]);
        ConnectDown.Add(maps[8]);
        ConnectDown.Add(maps[9]);
        ConnectDown.Add(maps[10]);
        ConnectDown.Add(maps[11]);
        ConnectDown.Add(maps[14]);
        //���� �������� ������ �ϴ� �ڵ�
        int ran_Map = Random.Range(0, ConnectDown.Count);
        Debug.Log(ran_Map);
        //�� ����
        if(GameManager.Instance.listMap <= 0)
        {
            Instantiate(maps[14], transform.position + new Vector3(0, -28, 0), Quaternion.identity, grid.transform);
            return;
        }
        else
        {
            Instantiate(ConnectDown[ran_Map], transform.position + new Vector3(0, -28, 0), Quaternion.identity, grid.transform);
        }
        GameManager.Instance.listMap--;
    }

    //���ʿ� �� ���� �ڵ�
    public void OpenUp()
    {
        //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
        List<GameObject> ConnectUp = new List<GameObject>();
        ConnectUp.Add(maps[0]);
        ConnectUp.Add(maps[1]);
        ConnectUp.Add(maps[2]);
        ConnectUp.Add(maps[7]);
        //���� �������� ������ �ϴ� �ڵ�
        int ran_Map = Random.Range(0, ConnectUp.Count);
        //�� ����
        Instantiate(ConnectUp[ran_Map], transform.position + new Vector3(0, 28, 0), Quaternion.identity, grid.transform);
        gameObject.transform.SetParent(grid.transform);

    }

    //������ �� ���� �ڵ�
    public void OpenRight()
    {
        //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
        List<GameObject> ConnectRight = new List<GameObject>();
        ConnectRight.Add(maps[0]);
        //���� �������� ������ �ϴ� �ڵ�
        int ran_Map = Random.Range(0, ConnectRight.Count);
        //�� ����
        Instantiate(ConnectRight[ran_Map], transform.position + new Vector3(28, 0, 0), Quaternion.identity, grid.transform);
        gameObject.transform.SetParent(grid.transform);

    }

    //���� �� ���� �ڵ�
    public void OpenLeft()
    {
        //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
        List<GameObject> ConnectLeft = new List<GameObject>();
        ConnectLeft.Add(maps[0]);
        //���� �������� ������ �ϴ� �ڵ�
        int ran_Map = Random.Range(0, ConnectLeft.Count);
        //�� ����
        Instantiate(ConnectLeft[ran_Map], transform.position + new Vector3(-28, 0, 0), Quaternion.identity, grid.transform);
        gameObject.transform.SetParent(grid.transform);

    }
}
