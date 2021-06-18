using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject etc;
    public GameObject enemy;
    public GameObject grid;
    public int maxX, minX;
    public int maxY, minY;
    public int countEnemy = 1;
    public bool isStart;
    int E_count;


    Enemy ey;
    public GameObject mimic;
    public bool isMimic;
    private void Start()
    {
        countEnemy = Random.Range(4, 6);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!isStart && col.tag == ("Player"))
        {
            Instantiate(etc, transform.position, Quaternion.identity, gameObject.transform);
            etc = GameObject.Find("Etc(Clone)");
            for (int i = 0; i < countEnemy; i++)
            {
                E_count++;
                int randomX = Random.Range(minX, maxX + 1);
                int ranomY = Random.Range(minY, maxY + 1);
                GameObject e = Instantiate(enemy, new Vector3(randomX, ranomY, 0)+transform.position, Quaternion.identity);
                Enemy es = e.GetComponent<Enemy>();
                es.es = this;
            }
            isStart = true;
        }
    }
    public void Box()
    {
        float whatBox = Random.Range(0, 11);
        GameObject box = Instantiate(mimic,transform.position, Quaternion.identity);
        Box b = box.GetComponent<Box>();

        if (whatBox > 0 && whatBox < 6)
        {
            b.ismimic = true;
            print("미믹이 나왔습니다!");
        }
        else
        {
            b.ismimic = false;
            print("진짜 상자가 나왔다!");
        }
    }
    public void IsEtc()
    {
        E_count--;
        print(E_count);
        if (E_count <= 0)
        {
            etc = GameObject.Find("Etc(Clone)");
            Box();
            Destroy(etc);
            Destroy(gameObject);
        }
    }
}
