using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField][Header("0 �Ϲݹ�, 1 ������, 2 ��й�")]
    private List<GameObject> room = new List<GameObject>();
    private int RDMax;
    [SerializeField]
    [Header("�������� ������ ����")]
    private int BosRoomTime;

    //�� ����
    [SerializeField][Header("�� ���� ����Ʈ�� �ٲ� ����)")]
    private GameObject Enemy;
    private int randomX;
    private int ranomY;
    private int countEnemy;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && GameManager.Instance.clear == true)
        {
            
            RDMax = Random.Range(0, 101);
            if (RDMax >0&& RDMax <5 &&BosRoomTime <=0)
            {
                Debug.Log("������");
                Player.transform.position =room[1].transform.position;
            }
            else if (RDMax > 99)
            {
                Debug.Log("��й�");
                Player.transform.position = room[2].transform.position;
            }
            else
            {
                Debug.Log("�Ϲݹ�");
                Player.transform.position = room[0].transform.position;

                countEnemy = Random.Range(3, 6);

                for (int i = 0; i < countEnemy; i++)
                {
                    randomX = Random.Range(-4, 14);
                    ranomY = Random.Range(-16,1);
                    Instantiate(Enemy, new Vector3(randomX, ranomY, 0), Quaternion.identity);
                }
            }
            Debug.Log(RDMax);
            BosRoomTime--;
            GameManager.Instance.clear = false;
        }
    }
}
