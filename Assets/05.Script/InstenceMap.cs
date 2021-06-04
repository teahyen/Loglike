using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InstenceMap : MonoBehaviour
{
    //[Header("여러 맵들")]
    //private GameObject grid;
    ////[Header("위 아래 오른쪽 왼쪽")]
    ////public BoxCollider2D[] WhereFromGo;
    //[Header("위 아래 오른쪽 왼쪽")]
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
    ////아래쪽에 맵 생성 코드
    //public void OpenDown()
    //{
    //    //아래쪽과 연결되있는 맵을 모두 가지고 오기
    //    List<GameObject> ConnectDown = new List<GameObject>();
    //    ConnectDown.Add(GameManager.Instance.maps[0]);
    //    ConnectDown.Add(GameManager.Instance.maps[4]);
    //    ConnectDown.Add(GameManager.Instance.maps[6]);
    //    ConnectDown.Add(GameManager.Instance.maps[8]);
    //    ConnectDown.Add(GameManager.Instance.maps[9]);
    //    ConnectDown.Add(GameManager.Instance.maps[10]);
    //    ConnectDown.Add(GameManager.Instance.maps[11]);
    //    ConnectDown.Add(GameManager.Instance.maps[14]);
    //    //맵을 렌덤으로 나오게 하는 코드
    //    int ran_Map = Random.Range(0, ConnectDown.Count);
    //    Debug.Log(ran_Map);
    //    //맵 생성
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

    ////위쪽에 맵 생성 코드
    //public void OpenUp()
    //{
    //    //아래쪽과 연결되있는 맵을 모두 가지고 오기
    //    List<GameObject> ConnectUp = new List<GameObject>();
    //    ConnectUp.Add(GameManager.Instance.maps[0]);
    //    ConnectUp.Add(GameManager.Instance.maps[1]);
    //    ConnectUp.Add(GameManager.Instance.maps[2]);
    //    ConnectUp.Add(GameManager.Instance.maps[7]);
    //    ConnectUp.Add(GameManager.Instance.maps[9]);
    //    ConnectUp.Add(GameManager.Instance.maps[10]);
    //    ConnectUp.Add(GameManager.Instance.maps[11]);
    //    ConnectUp.Add(GameManager.Instance.maps[12]);
    //    //맵을 렌덤으로 나오게 하는 코드
    //    int ran_Map = Random.Range(0, ConnectUp.Count);
    //    //맵 생성
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

    ////오른쪽 맵 생성 코드
    //public void OpenRight()
    //{
    //    //아래쪽과 연결되있는 맵을 모두 가지고 오기
    //    List<GameObject> ConnectRight = new List<GameObject>();
    //    ConnectRight.Add(GameManager.Instance.maps[0]);
    //    ConnectRight.Add(GameManager.Instance.maps[1]);
    //    ConnectRight.Add(GameManager.Instance.maps[2]);
    //    ConnectRight.Add(GameManager.Instance.maps[4]);
    //    ConnectRight.Add(GameManager.Instance.maps[5]);
    //    ConnectRight.Add(GameManager.Instance.maps[8]);
    //    ConnectRight.Add(GameManager.Instance.maps[10]);
    //    ConnectRight.Add(GameManager.Instance.maps[13]);
    //    //맵을 렌덤으로 나오게 하는 코드
    //    int ran_Map = Random.Range(0, ConnectRight.Count);
    //    //맵 생성
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

    ////왼쪽 맵 생성 코드
    //public void OpenLeft()
    //{
    //    //아래쪽과 연결되있는 맵을 모두 가지고 오기
    //    List<GameObject> ConnectLeft = new List<GameObject>();
    //    ConnectLeft.Add(GameManager.Instance.maps[0]);
    //    ConnectLeft.Add(GameManager.Instance.maps[2]);
    //    ConnectLeft.Add(GameManager.Instance.maps[3]);
    //    ConnectLeft.Add(GameManager.Instance.maps[5]);
    //    ConnectLeft.Add(GameManager.Instance.maps[6]);
    //    ConnectLeft.Add(GameManager.Instance.maps[7]);
    //    ConnectLeft.Add(GameManager.Instance.maps[8]);
    //    ConnectLeft.Add(GameManager.Instance.maps[9]);

    //    //맵을 렌덤으로 나오게 하는 코드
    //    int ran_Map = Random.Range(0, ConnectLeft.Count);
    //    //맵 생성
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
