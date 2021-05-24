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
    private Vector3 offset = Vector3.zero;
    public bool atking = false;

    public bool rotate;
    //피격 시 일어나는 함수들
    [SerializeField]
    private Image playerImg;
    public int hitTime =3;
    public bool ishit =false;
    public CanvasGroup hitRed;
    [Header("붉은 색인 시간")]
    public float changTime;

    void SetAttackSpeed(float speed)
    {
        atkSpeed = speed;
    }
    private void Start()
    {
        Sword.SetActive(false);
        Sword.transform.SetParent(null);
        offset = transform.position - Sword.transform.position;

    SetAttackSpeed(1.5f);
    }
    private void Update()
    {
        nowKpbar.fillAmount = (float)nowHp / (float)maxHp;
        PlayerMove();
        SwordMove();
        //근접 공격

        if (Input.GetMouseButtonDown(0) && atking == false)
        {
            Debug.Log("뽈롱뽀륭");
            StartCoroutine(atk());
        }
    }

    private void SwordMove()
    {
        Sword.transform.position = transform.position + offset;
        Sword.transform.rotation = transform.rotation;
    }

    private void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.F) && rotate)
        {
            player.transform.Rotate(new Vector3(0, 180, 0));
            Debug.Log("돌아간드아ㅏㅏ");
            rotate = false;
        }
        else if (Input.GetKeyDown(KeyCode.F) && !rotate)
        {
            player.transform.Rotate(new Vector3(0, -180, 0));
            Debug.Log("다시 돌아간드아ㅏ");
            rotate = true;
        }
        if (rotate == false)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                player.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            }

        }
        else if (rotate == true)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                player.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * -speed * Time.deltaTime, 0f, 0f));
            }
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
            print("힐 개꿀");
            Destroy(col.gameObject,1);   
        }
    }
    //공격할 경우
    IEnumerator atk()
    {
        Sword.SetActive(true);
        anim.Play("SwordAnimation");
        atking = true;
        yield return new WaitForSeconds(0.5f);
        Sword.SetActive(false);
        atking = false;
    }
    //적에게 맞았을 경우
    IEnumerator hit()
    {
        nowHp -= 10;
        print("아파!");
        hitRed.alpha = 1;
        if (nowHp <= 10)
        {
            SceneManager.LoadScene("GameOver");
        }
        Camera.main.DOShakePosition(3);
        yield return new WaitForSeconds(changTime);
        hitRed.alpha = 0;
        yield return new WaitForSeconds(hitTime-changTime);
        ishit = false;
    }
}
