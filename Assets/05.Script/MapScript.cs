using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private int RDMax;
    [SerializeField]
    [Header("�������� ������ ����")]
    private int BosRoomTime;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            RDMax = Random.Range(0, 101);
            if (RDMax >0&& RDMax <5 &&BosRoomTime <=0)
            {
                Debug.Log("������");
            }
            else if (RDMax > 99)
            {
                Debug.Log("��й�");
            }
            else
            {
                Debug.Log("�Ϲݹ�");
            }
            //else if (RDMax < 90 && RDMax >= 99)
            //{
            //    Debug.Log("�����۹�");
            //}
            //else if (RDMax < 99 && RDMax >= 100)
            //{
            //    Debug.Log("��й�");
            //}
            Debug.Log(RDMax);
            BosRoomTime--;
        }
    }
}
