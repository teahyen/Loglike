using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //³Ë¹é±¸Çö
    public Rigidbody2D rigid2D;
    [Header("³Ë¹éµÇ´Â Èû")]
    public float nkpower;
    [Header("³Ë¹éµÇ´Â ½Ã°£")]
    public float nkDur;

    public bool attacked = false;


    public int Heal;
    public int maxHeal = 25;
    public GameObject objHeal;
    public GameObject prfHpBar;
    public GameObject canvas;

    RectTransform hpBar;

    public float height = 1.7f;

    public string enemyName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int atkSpeed;
    private void SetEnemyStatus(string _enemyName, int _maxHp, int _atkDmg, int _atkSpeed)
    {
        enemyName = _enemyName;
        maxHp = _maxHp;
        nowHp = _maxHp;
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
    }
    public Player player;
    Image nowHpbar;
    private void Start()
    {

        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
        if (name.Equals("E-WingDown"))
        {
            SetEnemyStatus("E-WingDown", 100, 10, 1);
        }
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        attacked = true;
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
            nowHp -= player.atkDmg;
            Debug.Log(nowHp);
            attacked = false;

            Vector2 dir = transform.position - col.transform.position;

            rigid2D.AddForce(dir.normalized * nkpower, ForceMode2D.Impulse);

            //StartCoroutine(Knockback(nkDur, nkpower));
            if (nowHp <= 0)
            {
                Destroy(gameObject);
                Destroy(hpBar.gameObject);
                GameManager.Instance.lastenemy--;
                //StartCoroutine(spawnHeal());
                //ÈúÆÑ ¼ÒÈ¯
                if (Heal < 10)
                {
                    Instantiate(objHeal, transform.position, Quaternion.identity);
                }
            }
            attacked = true;
        }
    }
    public EnemyMove enemyMove;
    public IEnumerator Knockback(float dur, float power)
    {
        float timer = 0;
        //enemyMove.bPlayerInSightRange = false;
        while (timer <= dur)
        {
            timer += Time.deltaTime;
            if (player.rotate)
            {
           
                //transform.Translate(transform.position - new Vector3(5, 0, 0));
            }
            else if (!player.rotate)
            {
                //transform.Translate(transform.position - new Vector3(-5, 0, 0));
            }
        }
        //enemyMove.bPlayerInSightRange = true;
        yield return 0;
    }

}