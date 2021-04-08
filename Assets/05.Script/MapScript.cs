using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MapScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private int RDMax;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == Player)
        {
            RDMax = Random.Range(0, 101);
            if (RDMax >= 5 && RDMax <= 0)
            {
                //EditorSceneManager.OpenScene("BossScenes");
                Debug.Log("������");
            }

            else if (RDMax < 5 && RDMax >= 90)
            {
                //EditorSceneManager.OpenScene("Stage");
                Debug.Log("�Ϲݹ�");
            }
            else if (RDMax < 90 && RDMax >= 99)
            {
                //EditorSceneManager.OpenScene("GoldRoomScenes");
                Debug.Log("�����۹�");
            }
            else if (RDMax < 99 && RDMax >= 100)
            {
                //EditorSceneManager.OpenScene("SecretScenes");
                Debug.Log("��й�");
            }
        }
    }
}
