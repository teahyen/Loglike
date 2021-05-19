using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //�÷��̾ ������ �ൿ
    public int vertical;
    public float changeTime;
    public Rigidbody2D rigid2D;
    public float timer;
    public int direction = 1;

    public LayerMask whatIsPlayer;

    //���� �� ����
    [Header("�þ� ����")]
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
            //get�� ���� �б� �����̶� ���� �Ұ��� �׷��� set�� ���°�
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
        //�Ÿ� ����ؼ�(�þ� ���ݰŸ�) -> true false ����
        bPlayerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange,whatIsPlayer);
        //���� ������
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

    //�÷��̾ ������� �ൿ
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

    //�����Ÿ� ǥ�� �ΰ��� X
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
