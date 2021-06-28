using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{
    //넉백구현
    public Rigidbody2D rigid2D;
    [Header("넉백되는 힘")]
    public float nkpower;
    [Header("넉백되는 시간")]
    public float nkDur;

    public bool attacked = false;
    public Animator EnemyAni;


    public int Heal;
    public int maxHeal = 25;
    public GameObject prfHpBar;
    public GameObject canvas;

    RectTransform hpBar;

    public float height = 1.7f;

    public string enemyName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int atkSpeed;

    public EnemySpawn es;
    public Player player;

    [Header("맞으면 나는 소리")]
    public AudioSource hitSound;
    Image nowHpbar;

    private void Start()
    {

        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        attacked = true;
        atkDmg += GameManager.Instance.satge*30;
        maxHp += GameManager.Instance.satge*50;
        nowHp = maxHp;
        atkSpeed += GameManager.Instance.satge;
    }
    private void Update()
    {
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Sword")&&attacked)
        {
            nowHp -= GameManager.Instance.atkDmg;
            //Debug.Log(nowHp);
            attacked = false;
            Vector2 dir = transform.position - col.transform.position;
            rigid2D.AddForce(dir.normalized * nkpower, ForceMode2D.Impulse);
            hitSound.Play();
            if (nowHp <= 0)
            {
                es.IsEtc();
                EnemyAni.Play("EnemyDie");
                gameObject.tag = "Untagged";
                Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
                EnemyMove em = gameObject.GetComponent<EnemyMove>();
                rigid.bodyType = RigidbodyType2D.Static;
                Destroy(em);
                Destroy(gameObject,0.35f);
                Destroy(hpBar.gameObject,0.35f);
            }
            attacked = true;
        }
    }
    public IEnumerator Knockback(float dur, float power)
    {
        float timer = 0;
        //enemyMove.bPlayerInSightRange = false;
        while (timer <= dur)
        {
            timer += Time.deltaTime;
        }
        //enemyMove.bPlayerInSightRange = true;
        yield return 0;
    }

}