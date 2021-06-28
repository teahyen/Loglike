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
            if (ismimic)
            {
                StartCoroutine(player.hit());
                box.Play("MimicAin");
                TS.Text("�ƾ�! �̹��� ���Դ�");
                //�������� �������� ��ܿ� ��� ���� �̹�
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
                        GameManager.Instance.atkDmg += (int)addStat * 5;
                        TS.Text($"���ݷ� {addStat*5}��ŭ ����!");
                        break;
                    case 2:
                        if(GameManager.Instance.atkSpeed < 15)
                        {
                            GameManager.Instance.speed += addStat / 20;
                            TS.Text($"�̵� �ӵ� {(addStat / 10).ToString("0.00")}��ŭ ��������!");
                        }
                        else
                        {
                            GameManager.Instance.atkSpeed = 0.1f;
                            TS.Text($"���� �ӵ� �ִ��!");
                        }
                        break;
                    case 3:
                        GameManager.Instance.maxHp += (int)addStat*10;
                        TS.Text($"�ִ� ü�� {addStat*10}��ŭ ����!");
                        break;
                    case 4:
                        GameManager.Instance.nowHp += GameManager.Instance.maxHp/50;
                        TS.Text($"ü��{GameManager.Instance.maxHp/(2/3)} ȸ��");
                        break;
                }
                //if (sword.sprite == GameManager.Instance.swordList[wapon])
                //    TS.Text($"�� ���� �Ȱ��� ���� �ݾ�?");

                //else
                //    TS.Text($"�� ���ڿ��� {wapon}��° ���Ⱑ ���Խ��ϴ�! ����");
                sword.sprite = GameManager.Instance.swordList[wapon];
                GameManager.Instance.nowHp += GameManager.Instance.maxHp/10;
            }
            isopen = true;
            Destroy(gameObject,1.4f);
        }
    }
}
