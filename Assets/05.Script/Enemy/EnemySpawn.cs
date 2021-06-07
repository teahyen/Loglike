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
    private int countEnemy = 1;
    public bool clear;
    public bool isStart;

    private void Start()
    {
        etc.SetActive(true);
        //etc = GameObject.FindGameObjectWithTag("Etc");
    }
    public void Update()
    {
        if (GameManager.Instance.lastenemy <= 0)
        {
            etc.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!isStart && col.tag == ("Player"))
        {
            Instantiate(etc, transform.position, Quaternion.identity, gameObject.transform);
            countEnemy = Random.Range(3, 6);
            GameManager.Instance.lastenemy = countEnemy;
            for (int i = 0; i < countEnemy; i++)
            {
                int randomX = Random.Range(minX, maxX + 1);
                int ranomY = Random.Range(minY, maxY + 1);
                Instantiate(enemy, new Vector3(randomX, ranomY, 0), Quaternion.identity);
            }
            isStart = true;
        }
    }
}
