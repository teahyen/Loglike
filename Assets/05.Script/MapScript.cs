using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                //SceneManager.LoadScene("BossScenes");
                Debug.Log("보스방");
            }

            else if (RDMax < 5 && RDMax >= 90)
            {
                //SceneManager.LoadScene("Stage");
                Debug.Log("일반방");
            }
            else if (RDMax < 90 && RDMax >= 99)
            {
                //SceneManager.LoadScene("GoldRoomScenes");
                Debug.Log("아이템방");
            }
            else if (RDMax < 99 && RDMax >= 100)
            {
                //SceneManager.LoadScene("SecretScenes");
                Debug.Log("비밀방");
            }
        }
    }
}
