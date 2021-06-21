using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
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

    public Player player;
    public Animator box;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        sword = GameObject.Find("sword").GetComponent<SpriteRenderer>();
        int whatBox = Random.Range(0, 11);
        if (whatBox < 6)
        {
            ismimic = true;
            print("미믹이 나왔습니다!");
        }
        else
        {
            ismimic = false;
            print("진짜 상자가 나왔다!");
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
                StartCoroutine(player.hit());
                box.Play("MimicAin");
                //미믹 생성
            }
            else
            {
                box.Play("RealBox");
                int wapon = Random.Range(0, GameManager.Instance.swordList.Count);
                Debug.Log(wapon);
                sword.sprite = GameManager.Instance.swordList[wapon];
                player.nowHp += 10;
            }
            Destroy(gameObject,1.4f);
        }
    }
}
