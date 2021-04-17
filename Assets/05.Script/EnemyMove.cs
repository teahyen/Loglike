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
    private void Update()
    {
        //���� ������
        PlayerPos = Player.transform.position;
        Vector3 dir = PlayerPos - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
