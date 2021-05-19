using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //플래이어가 없을때 행동
    public int vertical;
    public float changeTime;
    public Rigidbody2D rigid2D;
    public float timer;
    public int direction = 1;

    public LayerMask whatIsPlayer;

    //현재 내 상태
    [Header("시아 범위")]
    public float sightRange;
    public bool bPlayerInSightRange;
    Vector2 pos;

    public int speed = 10;
    private GameObject Player;
    private Vector3 playerpos = Vector3.zero;
    public Vector3 PlayerPos
    {
        get
        {
            playerpos.z = transform.position.z;
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
        vertical = Random.Range(0, 2);
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        //거리 계산해서(시아 공격거리) -> true false 리턴
        bPlayerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange,whatIsPlayer);
        //가고 싶은곳
        if(bPlayerInSightRange)EnemyGoPlay();
        else FindPlayer();
    }

    private void EnemyGoPlay()
    {
        PlayerPos = Player.transform.position;
        Vector3 dir = PlayerPos - transform.position;
        dir.z = 0;
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    //플래이어가 없을경우 행동
    private void FindPlayer()
    {
        pos = rigid2D.position;
        timer -= Time.deltaTime;

        if (timer < 0f)
        {
            direction = -direction;
            timer = changeTime;
        }
        if (vertical == 1)
        {
            pos.y = pos.y + speed * Time.deltaTime * direction;
        }
        else
        {
            pos.x = pos.x + speed * Time.deltaTime * direction;
        }
        rigid2D.MovePosition(pos);
    }

    //사정거리 표시 인게임 X
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
