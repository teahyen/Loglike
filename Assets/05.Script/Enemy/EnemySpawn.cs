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

    private void Start()
    {
        countEnemy = Random.Range(4, 6);
    }
    public void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy") !=null)
        {
            GameObject[] a = GameObject.FindGameObjectsWithTag("Enemy");
            E_count = a.Length;
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!isStart && col.tag == ("Player"))
        {
            Instantiate(etc, transform.position, Quaternion.identity, gameObject.transform);
            etc = GameObject.Find("Etc(Clone)");
            for (int i = 0; i < countEnemy; i++)
            {
                int randomX = Random.Range(minX, maxX + 1);
                int ranomY = Random.Range(minY, maxY + 1);
                Instantiate(enemy, new Vector3(randomX, ranomY, 0)+transform.position, Quaternion.identity);
            }
            isStart = true;
        }
    }
    public void IsEtc()
    {
        countEnemy--;
        print($"{countEnemy},{E_count}명 남았습니다.");
        if (countEnemy <= 0 || E_count <=0)
        {
            etc = GameObject.Find("Etc(Clone)");
            Destroy(etc);
            Destroy(gameObject);
        }
    }
}
