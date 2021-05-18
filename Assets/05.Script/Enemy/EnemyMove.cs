using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public LayerMask whatIsGround, whatIsPlayer;

    //���� �� ����
    [Header("�þ� ����")]
    public float sightRange;
    public bool bPlayerInSightRange;

    public int speed = 10;
    private GameObject Player;
    private Vector3 playerpos = Vector3.zero;
    public Vector3 PlayerPos
    {
        get
        {
            //private Vector3 Playerpos = Vector3.zero; �� ���⼭ ����
            playerpos.z = transform.position.z;
            //������ private Vector3 Playerpos = Vector3.zero;�� ������
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
        Player = GameObject.Find("Player");
    }
    private void Update()
    {

        //�Ÿ� ����ؼ�(�þ� ���ݰŸ�) -> true false ����
        bPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        //���� ������
        EnemyGoPlay();
    }

    private void EnemyGoPlay()
    {
        PlayerPos = Player.transform.position;
        Vector3 dir = PlayerPos - transform.position;
        dir.z = 0;
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    //�����Ÿ� ǥ�� �ΰ��� X
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
