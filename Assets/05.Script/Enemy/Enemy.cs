using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
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
        if (col.CompareTag("Sword"))
        {
            nowHp -= player.atkDmg;
            Debug.Log(nowHp);
            player.attacked = false;
            player.nowHp += 10000000 ;
            if (nowHp <= 0)
            {
                Destroy(gameObject);
                Destroy(hpBar.gameObject);
                GameManager.Instance.lastenemy--;
                //StartCoroutine(spawnHeal());
                //���� ��ȯ
                if (Heal < 10)
                {
                    Instantiate(objHeal, transform.position, Quaternion.identity);
                }
            }
        }
    }
    //IEnumerator spawnHeal()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    Heal = Random.Range(1, maxHeal);


    //}

}