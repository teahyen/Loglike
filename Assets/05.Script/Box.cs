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
    public bool isopen = false;

    public Player player;
    public Animator box;
    TextSC TS;

    private void Start()
    {
        TS = GameObject.Find("What?").GetComponent<TextSC>();
        player = GameObject.Find("Player").GetComponent<Player>();
        sword = GameObject.Find("sword").GetComponent<SpriteRenderer>();
        int whatBox = Random.Range(0, 11);
        if (whatBox < 1)
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
        if (Input.GetKeyDown(KeyCode.F)&&!isopen)
        {
            if (ismimic)
            {
                StartCoroutine(player.hit());
                box.Play("MimicAin");
                TS.Text("미믹을 조심해ㅋㅋ");
                //데미지를 무한으로 즐겨요 명륜 진사 미믹
            }
            else
            {
                box.Play("RealBox");
                int wapon = Random.Range(0, GameManager.Instance.swordList.Count);
                
                if (sword.sprite == GameManager.Instance.swordList[wapon])
                    TS.Text($"엥 뭐야 똑같은 무기 잖아?");
                
                else
                    TS.Text($"오 상자에서 {wapon}번째 무기가 나왔습니다! 개꿀");
                
                sword.sprite = GameManager.Instance.swordList[wapon];
                player.nowHp += 10;
            }
            isopen = true;
            Destroy(gameObject,1.4f);
        }
    }
}
