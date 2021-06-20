using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public LayerMask whatPlayer;
    public bool bFindPlayer;
    public bool bOpenBox;
    public SpriteRenderer sword;

    public float lookRange;
    public float openRange;
    public bool ismimic;

    private void Start()
    {
        sword = GameObject.Find("sword").GetComponent<SpriteRenderer>();
        int whatBox = Random.Range(0, 11);
        if (whatBox < 6)
        {
            ismimic = true;
            print("�̹��� ���Խ��ϴ�!");
        }
        else
        {
            ismimic = false;
            print("��¥ ���ڰ� ���Դ�!");
        }
    }
    void Update()
    {
        bFindPlayer = Physics2D.OverlapCircle(transform.position, lookRange, whatPlayer);
        bOpenBox = Physics2D.OverlapCircle(transform.position, openRange, whatPlayer);
        if (bFindPlayer&&bOpenBox) ToOpenBox();
    }
    
    public void ToOpenBox()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ismimic)
            {
                //�̹� ����
            }
            else
            {
                int wapon = Random.Range(0, GameManager.Instance.swordList.Count);
                Debug.Log(wapon);
                sword.sprite = GameManager.Instance.swordList[wapon];
            }
            Destroy(gameObject);
        }
    }
}
