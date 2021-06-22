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
    TextSC TS;

    private void Start()
    {
        TS = GameObject.Find("What?").GetComponent<TextSC>();
        player = GameObject.Find("Player").GetComponent<Player>();
        sword = GameObject.Find("sword").GetComponent<SpriteRenderer>();
        int whatBox = Random.Range(0, 11);
        if (whatBox < 6)
        {
            ismimic = true;
        }
        else
        {
            ismimic = false;
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
                TS.Text("미믹을 조심해ㅋㅋ");
            }
            else
            {
                box.Play("RealBox");
                int wapon = Random.Range(0, GameManager.Instance.swordList.Count);
                TS.Text($"오 상자에서 {wapon}번째 무기가 나왔습니다!");
                sword.sprite = GameManager.Instance.swordList[wapon];
                player.nowHp += 10;
            }
            Destroy(gameObject,1.4f);
        }
    }
}
