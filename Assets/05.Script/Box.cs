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

    public AudioSource openBox;
    [Header("상자열때 사운드")]
    public AudioSource InputSound;
    public AudioClip mimicSound;
    public AudioClip DmgUpSound;
    public AudioClip SpeedUpSound;
    public AudioClip MaxUpSound;
    public AudioClip HealSound;

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
            openBox.Play();
            if (ismimic&&!player.ishit)
            {
                StartCoroutine(player.hit());
                box.Play("MimicAin");
                TS.Text("아야! 미믹이 나왔다");
                //데미지를 무한으로 즐겨요 명륜 진사 미믹
            }
            else
            {
                box.Play("RealBox");
                int wapon = Random.Range(0, GameManager.Instance.swordList.Count);
                int whatStat = Random.Range(1, 5);
                float addStat = Random.Range(1, 10);
                switch (whatStat)
                {
                    case 1:
                        GameManager.Instance.atkDmg += (int)addStat * 3;
                        TS.Text($"공격력 {addStat*5}만큼 증가!");
                        PlaySound(DmgUpSound);
                        player.WhatParticle(1);
                        break;
                    case 2:
                        if(GameManager.Instance.speed < 15)
                        {
                            GameManager.Instance.speed += addStat / 20;
                            TS.Text($"이동 속도 {(addStat / 10).ToString("0.00")}만큼 빨라졌다!");
                            PlaySound(SpeedUpSound);
                        }
                        else
                        {
                            GameManager.Instance.atkSpeed = 0.1f;
                            TS.Text($"공격 속도 최대로!");
                        }
                        player.WhatParticle(2);
                        break;
                    case 3:
                        GameManager.Instance.maxHp += (int)addStat*10;
                        TS.Text($"최대 체력 {addStat*10}만큼 증가!");
                        PlaySound(MaxUpSound);
                        player.WhatParticle(3);
                        break;
                    case 4:
                        GameManager.Instance.nowHp += GameManager.Instance.maxHp/2;
                        TS.Text($"체력{GameManager.Instance.maxHp/2} 회복");
                        PlaySound(HealSound);
                        player.WhatParticle(4);
                        break;
                }
                //if (sword.sprite == GameManager.Instance.swordList[wapon])
                //    TS.Text($"엥 뭐야 똑같은 무기 잖아?");

                //else
                //    TS.Text($"오 상자에서 {wapon}번째 무기가 나왔습니다! 개꿀");
                sword.sprite = GameManager.Instance.swordList[wapon];
            }
            isopen = true;
            Destroy(gameObject,1.4f);
        }
    }
    public void PlaySound(AudioClip nowSound)
    {
        InputSound.clip = nowSound;
        InputSound.Play();
    }
}
