using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Animator anim = null;

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject player;

    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1;
    public Image nowKpbar;

    [SerializeField]
    private GameObject Sword;
    public Vector3 offset;

    //피격 시 일어나는 함수들
    [SerializeField]
    public int hitTime =3;
    public bool ishit =false;
    public CanvasGroup hitRed;
    [Header("붉은 색인 시간")]
    public float changTime;

    public SpriteRenderer myImg;



    private void Update()
    {
        nowKpbar.fillAmount = (float)nowHp / (float)maxHp;
        PlayerMove();
        SwordMove();
        //근접 공격
    }


    private void SwordMove()
    {
        Sword.transform.position = transform.position + offset;
        //Sword.transform.rotation = transform.rotation;
    }
    private void PlayerMove()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            player.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            player.transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy")&&!ishit)
        {
            ishit = true;
            StartCoroutine(hit());
        }
        if (col.CompareTag("Heal"))//&& Input.GetKey(KeyCode.E)
        {
            nowHp += 15;
            Destroy(col.gameObject,1);   
        }
    }

    //적에게 맞았을 경우
    public IEnumerator hit()
    {
        Color myColor = myImg.color;
        nowHp -= 10;
        hitRed.alpha = 1;
        if (nowHp <= 0)
        {
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
