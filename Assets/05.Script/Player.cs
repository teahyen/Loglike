using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Player : MonoBehaviour
{


    [SerializeField]
    private GameObject player;

    TextSC TS;
    public GameOver GM;

    public Image nowKpbar;

    [SerializeField]
    private GameObject Sword;
    public float x, y, z;

    //피격 시 일어나는 함수들
    [SerializeField]
    public int hitTime =3;
    public bool ishit =false;
    public CanvasGroup hitRed;
    [Header("붉은 색인 시간")]
    public float changTime;

    public SpriteRenderer myImg;

    public Rigidbody2D mycol;

    Vector2 movement;
    public Animator anim;

    Enemy en;

    public GameObject overCanvas;
    [Header("게임 소리 끄기")]
    public AudioSource backGround;

    [Header("상자열때 파티클")]
    //whatParticle -> 1
    public ParticleSystem DmgUp;

    //whatParticle -> 2
    public ParticleSystem SpeedUp;
    
    //whatParticle -> 3
    public ParticleSystem MaxHpUp;
    
    //whatParticle -> 4
    public ParticleSystem Heal;

    private void Start()
    {
        TS = GameObject.Find("What?").GetComponent<TextSC>();
    }
    private void Update()
    {
        nowKpbar.fillAmount = (float)GameManager.Instance.nowHp / (float)GameManager.Instance.maxHp;
        if(!Setting.isActive && !GameManager.Instance.isDie)
        {
            PlayerMove();
            SwordMove();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            TS.Text("저주에 걸렸습니다 당신은 체력이 0이 됨니다.");
            GameManager.Instance.nowHp = 0;
        }
        //근접 공격
    }
    //파티클 참고
    public void WhatParticle(int num)
    {
        switch (num)
        {
            case 1:
                DmgUp.Play();
                break;
            case 2:
                SpeedUp.Play();
                break;
            case 3:
                MaxHpUp.Play();
                break;
            case 4:
                Heal.Play();
                break;
        }
    }
    private void SwordMove()
    {
        Sword.transform.position = transform.position + new Vector3(x,y,z);

    }
    private void PlayerMove()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (movement.x > 0 || movement.x < 0)
        {
            player.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * GameManager.Instance.speed * Time.deltaTime, 0f, 0f));
        }
        if (movement.y > 0 || movement.y < 0)
        {
            player.transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * GameManager.Instance.speed * Time.deltaTime, 0f));
        }
        if (movement.y > 0) z = 0f;
        else z = -0.9f;
        if (movement.x > 0) x = 0.1f;
        else x = -0.08f;
        anim.SetFloat("MoveX", movement.x);
        anim.SetFloat("MoveY", movement.y);

    }
    //무언가와 닿았다!
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy")&&!ishit)
        {
            en = col.gameObject.GetComponent<Enemy>();
            StartCoroutine(hit());
        }
    }

    //적에게 맞았을 경우
    public IEnumerator hit()
    {
        ishit = true;
        Color myColor = myImg.color;
        if(en == null)
        {
            GameManager.Instance.whokill = 2;
            GameManager.Instance.nowHp -= (GameManager.Instance.satge * 30);
        }
        else
        {
            GameManager.Instance.whokill = 1;
            GameManager.Instance.nowHp -= en.atkDmg;
        }
        hitRed.alpha = 1;
        if (GameManager.Instance.nowHp <= 0)
        {
            GameManager.Instance.isDie = true;
            backGround.Stop();
            Image myImage = overCanvas.GetComponent<Image>();
            Time.timeScale = 0.2f;
            myImage.DOFade(1, 1);
            mycol.mass = 100;
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("GameOver");

        }
        Camera.main.DOShakePosition(3);
        yield return new WaitForSeconds(0.2f);
        hitRed.alpha = 0;
        for (int i = 0; i < 5; i++)
        {
            myColor.a = 0;
            myImg.color = myColor;
            yield return new WaitForSeconds(0.2f);
            myColor.a = 1;
            myImg.color = myColor;
            yield return new WaitForSeconds(0.2f);
        }
        ishit = false;
    }
}
