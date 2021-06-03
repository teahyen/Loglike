using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InstenceMap : MonoBehaviour
{
    [Header("여러 맵들")]
    public GameObject[] maps = new GameObject[13];
    private GameObject grid;
    //public BoxCollider2D[] WhereFromGo;
    [Header("위 아래 오른쪽 왼쪽")]
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
    //아래쪽에 맵 생성 코드
    public void OpenDown()
    {
        //아래쪽과 연결되있는 맵을 모두 가지고 오기
        List<GameObject> ConnectDown = new List<GameObject>();
        ConnectDown.Add(maps[0]);
        ConnectDown.Add(maps[4]);
        ConnectDown.Add(maps[6]);
        ConnectDown.Add(maps[8]);
        ConnectDown.Add(maps[9]);
        ConnectDown.Add(maps[10]);
        ConnectDown.Add(maps[11]);
        ConnectDown.Add(maps[14]);
        //맵을 렌덤으로 나오게 하는 코드
        int ran_Map = Random.Range(0, ConnectDown.Count);
        Debug.Log(ran_Map);
        //맵 생성
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

    //위쪽에 맵 생성 코드
    public void OpenUp()
    {
        //아래쪽과 연결되있는 맵을 모두 가지고 오기
        List<GameObject> ConnectUp = new List<GameObject>();
        ConnectUp.Add(maps[0]);
        ConnectUp.Add(maps[1]);
        ConnectUp.Add(maps[2]);
        ConnectUp.Add(maps[7]);
        //맵을 렌덤으로 나오게 하는 코드
        int ran_Map = Random.Range(0, ConnectUp.Count);
        //맵 생성
        Instantiate(ConnectUp[ran_Map], transform.position + new Vector3(0, 28, 0), Quaternion.identity, grid.transform);
        gameObject.transform.SetParent(grid.transform);

    }

    //오른쪽 맵 생성 코드
    public void OpenRight()
    {
        //아래쪽과 연결되있는 맵을 모두 가지고 오기
        List<GameObject> ConnectRight = new List<GameObject>();
        ConnectRight.Add(maps[0]);
        //맵을 렌덤으로 나오게 하는 코드
        int ran_Map = Random.Range(0, ConnectRight.Count);
        //맵 생성
        Instantiate(ConnectRight[ran_Map], transform.position + new Vector3(28, 0, 0), Quaternion.identity, grid.transform);
        gameObject.transform.SetParent(grid.transform);

    }

    //왼쪽 맵 생성 코드
    public void OpenLeft()
    {
        //아래쪽과 연결되있는 맵을 모두 가지고 오기
        List<GameObject> ConnectLeft = new List<GameObject>();
        ConnectLeft.Add(maps[0]);
        //맵을 렌덤으로 나오게 하는 코드
        int ran_Map = Random.Range(0, ConnectLeft.Count);
        //맵 생성
        Instantiate(ConnectLeft[ran_Map], transform.position + new Vector3(-28, 0, 0), Quaternion.identity, grid.transform);
        gameObject.transform.SetParent(grid.transform);

    }
}
