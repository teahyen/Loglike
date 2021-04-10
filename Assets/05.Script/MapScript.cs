using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private int RDMax;
    [SerializeField]
    [Header("보스방이 나오는 시점")]
    private int BosRoomTime;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            RDMax = Random.Range(0, 101);
            if (RDMax >0&& RDMax <5 &&BosRoomTime <=0)
            {
                Debug.Log("보스방");
            }
            else if (RDMax > 99)
            {
                Debug.Log("비밀방");
            }
            else
            {
                Debug.Log("일반방");
            }
            //else if (RDMax < 90 && RDMax >= 99)
            //{
            //    Debug.Log("아이템방");
            //}
            //else if (RDMax < 99 && RDMax >= 100)
            //{
            //    Debug.Log("비밀방");
            //}
            Debug.Log(RDMax);
            BosRoomTime--;
        }
    }
}
