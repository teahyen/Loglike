using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InstenceMap : MonoBehaviour
{
    //[Header("���� �ʵ�")]
    //private GameObject grid;
    ////[Header("�� �Ʒ� ������ ����")]
    ////public BoxCollider2D[] WhereFromGo;
    //[Header("�� �Ʒ� ������ ����")]
    //public bool[] isRode = new bool[4];

    //public GameObject etc;
    //public void Awake()
    //{
    //    grid = GameObject.Find("Grid");
    //}
    //public void Start()
    //{
    //    etc.SetActive(false);
    //    if (isRode[0])
    //    {
    //        OpenUp();
    //    }
    //    if (isRode[1])
    //    {
    //        OpenDown();
    //    }

    //    //if (isRode[2])
    //    //{
    //    //    OpenRight();
    //    //}

    //    //OpenLeft();
    //}
    //public void Update()
    //{
    //    if (GameManager.Instance.clear)
    //    {
    //        etc.SetActive(false);
    //    }
    //}
    ////�Ʒ��ʿ� �� ���� �ڵ�
    //public void OpenDown()
    //{
    //    //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
    //    List<GameObject> ConnectDown = new List<GameObject>();
    //    ConnectDown.Add(GameManager.Instance.maps[0]);
    //    ConnectDown.Add(GameManager.Instance.maps[4]);
    //    ConnectDown.Add(GameManager.Instance.maps[6]);
    //    ConnectDown.Add(GameManager.Instance.maps[8]);
    //    ConnectDown.Add(GameManager.Instance.maps[9]);
    //    ConnectDown.Add(GameManager.Instance.maps[10]);
    //    ConnectDown.Add(GameManager.Instance.maps[11]);
    //    ConnectDown.Add(GameManager.Instance.maps[14]);
    //    //���� �������� ������ �ϴ� �ڵ�
    //    int ran_Map = Random.Range(0, ConnectDown.Count);
    //    Debug.Log(ran_Map);
    //    //�� ����
    //    if (GameManager.Instance.listMap <= 0)
    //    {
    //        Instantiate(GameManager.Instance.endMaps[0], transform.position + new Vector3(0, -28, 0), Quaternion.identity, grid.transform);
    //    }
    //    else
    //    {
    //        Instantiate(ConnectDown[ran_Map], transform.position + new Vector3(0, -28, 0), Quaternion.identity, grid.transform);
    //    }
    //    GameManager.Instance.listMap--;
    //}

    ////���ʿ� �� ���� �ڵ�
    //public void OpenUp()
    //{
    //    //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
    //    List<GameObject> ConnectUp = new List<GameObject>();
    //    ConnectUp.Add(GameManager.Instance.maps[0]);
    //    ConnectUp.Add(GameManager.Instance.maps[1]);
    //    ConnectUp.Add(GameManager.Instance.maps[2]);
    //    ConnectUp.Add(GameManager.Instance.maps[7]);
    //    ConnectUp.Add(GameManager.Instance.maps[9]);
    //    ConnectUp.Add(GameManager.Instance.maps[10]);
    //    ConnectUp.Add(GameManager.Instance.maps[11]);
    //    ConnectUp.Add(GameManager.Instance.maps[12]);
    //    //���� �������� ������ �ϴ� �ڵ�
    //    int ran_Map = Random.Range(0, ConnectUp.Count);
    //    //�� ����
    //    if (GameManager.Instance.listMap <= 0)
    //    {
    //        Instantiate(GameManager.Instance.endMaps[0], transform.position + new Vector3(0, 28, 0), Quaternion.identity, grid.transform);
    //    }
    //    else
    //    {
    //        Instantiate(ConnectUp[ran_Map], transform.position + new Vector3(0, 28, 0), Quaternion.identity, grid.transform);
    //    }
    //    gameObject.transform.SetParent(grid.transform);

    //}

    ////������ �� ���� �ڵ�
    //public void OpenRight()
    //{
    //    //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
    //    List<GameObject> ConnectRight = new List<GameObject>();
    //    ConnectRight.Add(GameManager.Instance.maps[0]);
    //    ConnectRight.Add(GameManager.Instance.maps[1]);
    //    ConnectRight.Add(GameManager.Instance.maps[2]);
    //    ConnectRight.Add(GameManager.Instance.maps[4]);
    //    ConnectRight.Add(GameManager.Instance.maps[5]);
    //    ConnectRight.Add(GameManager.Instance.maps[8]);
    //    ConnectRight.Add(GameManager.Instance.maps[10]);
    //    ConnectRight.Add(GameManager.Instance.maps[13]);
    //    //���� �������� ������ �ϴ� �ڵ�
    //    int ran_Map = Random.Range(0, ConnectRight.Count);
    //    //�� ����
    //    if (GameManager.Instance.listMap <= 0)
    //    {
    //        Instantiate(GameManager.Instance.endMaps[3], transform.position + new Vector3(28, 0, 0), Quaternion.identity, grid.transform);
    //    }
    //    else
    //    {
    //        Instantiate(ConnectRight[ran_Map], transform.position + new Vector3(28, 0, 0), Quaternion.identity, grid.transform);
    //    }
    //    gameObject.transform.SetParent(grid.transform);

    //}

    ////���� �� ���� �ڵ�
    //public void OpenLeft()
    //{
    //    //�Ʒ��ʰ� ������ִ� ���� ��� ������ ����
    //    List<GameObject> ConnectLeft = new List<GameObject>();
    //    ConnectLeft.Add(GameManager.Instance.maps[0]);
    //    ConnectLeft.Add(GameManager.Instance.maps[2]);
    //    ConnectLeft.Add(GameManager.Instance.maps[3]);
    //    ConnectLeft.Add(GameManager.Instance.maps[5]);
    //    ConnectLeft.Add(GameManager.Instance.maps[6]);
    //    ConnectLeft.Add(GameManager.Instance.maps[7]);
    //    ConnectLeft.Add(GameManager.Instance.maps[8]);
    //    ConnectLeft.Add(GameManager.Instance.maps[9]);

    //    //���� �������� ������ �ϴ� �ڵ�
    //    int ran_Map = Random.Range(0, ConnectLeft.Count);
    //    //�� ����
    //    if (GameManager.Instance.listMap <= 0)
    //    {
    //        Instantiate(GameManager.Instance.endMaps[2], transform.position + new Vector3(-28, 0, 0), Quaternion.identity, grid.transform);
    //    }
    //    else
    //    {
    //        Instantiate(ConnectLeft[ran_Map], transform.position + new Vector3(-28, 0, 0), Quaternion.identity, grid.transform);
    //    }

    //    gameObject.transform.SetParent(grid.transform);

    //}
}
