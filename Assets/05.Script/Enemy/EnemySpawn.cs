using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Etc;
    public GameObject Enemy;
    public int maxX, minX;
    public int maxY, minY;
    public int countEnemy = 999;
    public bool clear;
    public bool isStart;

    private void Start()
    {
        Etc.SetActive(false);
    }
    public void Update()
    {
        if (countEnemy == 0)
        {
            clear = true;
        }
        if (clear)
        {
            Etc.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        countEnemy = Random.Range(3, 6);
        GameManager.Instance.lastenemy = countEnemy;
        if (!isStart && col.tag == ("Player"))
        {
            for (int i = 0; i < countEnemy; i++)
            {
                Etc.SetActive(true);
                int randomX = Random.Range(minX, maxX + 1);
                int ranomY = Random.Range(minY, maxY + 1);
                Instantiate(Enemy, new Vector3(randomX, ranomY, 0), Quaternion.identity);
            }
            isStart = false;
        }
    }
}
