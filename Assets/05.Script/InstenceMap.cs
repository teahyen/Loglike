using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InstenceMap : MonoBehaviour
{
    [Header("1입구 2입구 3입구 4입구")]
    public GameObject[] maps;

    public BoxCollider2D[] WhereFromGo;
    
    public GameObject etc;
    public void Start()
    {
        etc.SetActive(false);
    }
    //아래쪽에 맵 생성 코드
    public void OpenDown()
    {
        //아래쪽과 연결되있는 맵을 모두 가지고 오기
        List<GameObject> ConnectDown = new List<GameObject>();
        ConnectDown.Add(maps[1]);
        //맵을 렌덤으로 나오게 하는 코드
        int ran_Map = Random.Range(0, ConnectDown.Count);
        //맵 생성
        Instantiate(ConnectDown[ran_Map], transform.position + new Vector3(0, -28, 0), Quaternion.identity);
    }

    //위쪽에 맵 생성 코드
    public void OpenUp()
    {
        //아래쪽과 연결되있는 맵을 모두 가지고 오기
        List<GameObject> ConnectUp = new List<GameObject>();
        ConnectUp.Add(maps[1]);
        //맵을 렌덤으로 나오게 하는 코드
        int ran_Map = Random.Range(0, ConnectUp.Count);
        //맵 생성
        Instantiate(ConnectUp[ran_Map], transform.position + new Vector3(0, 28, 0), Quaternion.identity);
    }

    //오른쪽 맵 생성 코드
    public void OpenRight()
    {
        //아래쪽과 연결되있는 맵을 모두 가지고 오기
        List<GameObject> ConnectRight = new List<GameObject>();
        ConnectRight.Add(maps[1]);
        //맵을 렌덤으로 나오게 하는 코드
        int ran_Map = Random.Range(0, ConnectRight.Count);
        //맵 생성
        Instantiate(ConnectRight[ran_Map], transform.position + new Vector3(28, 0, 0), Quaternion.identity);
    }

    //왼쪽 맵 생성 코드
    public void OpenLeft()
    {
        //아래쪽과 연결되있는 맵을 모두 가지고 오기
        List<GameObject> ConnectLeft = new List<GameObject>();
        ConnectLeft.Add(maps[1]);
        //맵을 렌덤으로 나오게 하는 코드
        int ran_Map = Random.Range(0, ConnectLeft.Count);
        //맵 생성
        Instantiate(ConnectLeft[ran_Map], transform.position + new Vector3(-28, 0, 0), Quaternion.identity);
    }
}
