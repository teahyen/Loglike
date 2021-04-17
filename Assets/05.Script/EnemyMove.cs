using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int speed = 10;
    [SerializeField]
    private GameObject Player;
    private Vector3 playerpos = Vector3.zero;
    public Vector3 PlayerPos
    {
        get
        {
            //private Vector3 Playerpos = Vector3.zero; 를 여기서 수정
            playerpos.z = transform.position.z;
            //수정한 private Vector3 Playerpos = Vector3.zero;을 밖으로
            return playerpos;
        }

        private set
        {
            //get만 쓰면 읽기 전용이라 수정 불가능 그래서 set을 쓰는거
            playerpos = value;
        }
    }
    private void Update()
    {
        //가고 싶은곳
        PlayerPos = Player.transform.position;
        Vector3 dir = PlayerPos - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
