using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private int RDMax;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            RDMax = Random.Range(0, 101);
            if (RDMax >= 5 && RDMax <= 0)
            {
                Debug.Log("������");
            }
            else if (RDMax < 5 && RDMax >= 90)
            {
                Debug.Log("�Ϲݹ�");
            }
            else if (RDMax < 90 && RDMax >= 99)
            {
                Debug.Log("�����۹�");
            }
            else if (RDMax < 99 && RDMax >= 100)
            {
                Debug.Log("��й�");
            }
            Debug.Log(RDMax);
        }
    }
}
