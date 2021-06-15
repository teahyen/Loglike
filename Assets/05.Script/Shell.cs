using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    /*
    1은 아래
    2는 위
    3은 왼쪽
    4는 오른쪽
     */
    public int pos;
    public GameObject shellObj;
    public GameObject pointObj;
    private GameObject grid;

    private float sightRange = 0.4f;
    public LayerMask whatIswall;
    public bool bWallInSingRange;
    public bool isSpawnWall = false;

    private void Start()
    {
        grid = GameObject.Find("Grid");
        StartCoroutine(Mapcheck());
    }
    private void Update()
    {
        bWallInSingRange = Physics2D.OverlapCircle(transform.position, sightRange, whatIswall);
    }
    public IEnumerator Mapcheck()
    {
        yield return new WaitForSeconds(1);
        if (!bWallInSingRange && !isSpawnWall)
        {
            isspawn();
        }
    }
    //벽 스폰 함수
    public void isspawn()
    {

        switch (pos)
        {
            //아래
            case 1:
                Instantiate(shellObj, pointObj.transform.position + new Vector3(0, -11, 0),
                    Quaternion.identity, grid.transform);
                break;
            //위
            case 2:
                Instantiate(shellObj, pointObj.transform.position + new Vector3(0, 11, 0),
                    Quaternion.identity, grid.transform);
                break;
            //왼쪽
            case 3:
                Instantiate(shellObj, pointObj.transform.position + new Vector3(-11, 0, 0),
                    Quaternion.identity, grid.transform);
                break;
            //오른쪽
            case 4:
                Instantiate(shellObj, pointObj.transform.position + new Vector3(11, 0, 0),
                    Quaternion.identity, grid.transform);
                break;
            default:
                print(pos);
                break;
        }
        isSpawnWall = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
