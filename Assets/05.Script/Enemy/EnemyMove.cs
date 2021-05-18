using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public LayerMask whatIsGround, whatIsPlayer;

    //현재 내 상태
    [Header("시아 범위")]
    public float sightRange;
    public bool bPlayerInSightRange;

    public int speed = 10;
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
    private void Start()
    {
        Player = GameObject.Find("Player");
    }
    private void Update()
    {

        //거리 계산해서(시아 공격거리) -> true false 리턴
        bPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        //가고 싶은곳
        EnemyGoPlay();
    }

    private void EnemyGoPlay()
    {
        PlayerPos = Player.transform.position;
        Vector3 dir = PlayerPos - transform.position;
        dir.z = 0;
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    //사정거리 표시 인게임 X
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
