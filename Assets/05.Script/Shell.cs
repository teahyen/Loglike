using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    /*
    1�� �Ʒ�
    2�� ��
    3�� ����
    4�� ������
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
    //�� ���� �Լ�
    public void isspawn()
    {

        switch (pos)
        {
            //�Ʒ�
            case 1:
                Instantiate(shellObj, pointObj.transform.position + new Vector3(0, -11, 0),
                    Quaternion.identity, grid.transform);
                break;
            //��
            case 2:
                Instantiate(shellObj, pointObj.transform.position + new Vector3(0, 11, 0),
                    Quaternion.identity, grid.transform);
                break;
            //����
            case 3:
                Instantiate(shellObj, pointObj.transform.position + new Vector3(-11, 0, 0),
                    Quaternion.identity, grid.transform);
                break;
            //������
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
