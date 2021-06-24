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

    private void Update()
    {
        nowKpbar.fillAmount = (float)GameManager.Instance.nowHp / (float)GameManager.Instance.maxHp;
        PlayerMove();
        SwordMove();
        //근접 공격
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
            ishit = true;
            en = col.gameObject.GetComponent<Enemy>();
            StartCoroutine(hit());
        }
        //if (col.CompareTag("Heal"))//&& Input.GetKey(KeyCode.E)
        //{
        //    GameManager.Instance.nowHp += 15;
        //    Destroy(col.gameObject,1);   
        //}
    }

    //적에게 맞았을 경우
    public IEnumerator hit()
    {

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
            Image myImage = overCanvas.GetComponent<Image>();
            myImage.DOFade(1, 3);
            mycol.mass = 100;
            yield return new WaitForSeconds(3f);
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
