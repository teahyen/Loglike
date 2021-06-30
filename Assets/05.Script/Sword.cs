using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sword : MonoBehaviour
{

    [SerializeField]
    private GameObject SwordObg;
    public Vector3 rot;
    bool isAtk = false;
    //피격 시 일어나는 함수들
    public AudioSource swordEffect;
    BoxCollider2D Swordcol;
    public GameObject Effect;
    Player Player;
    private void Start()
    {
        Effect.SetActive(false);
        Player = GameObject.Find("Player").GetComponent<Player>();
        Swordcol = SwordObg.GetComponent<BoxCollider2D>();
        Swordcol.enabled = false;
        SwordObg.transform.SetParent(null);
    }
    void Update()
    {
        if(!Setting.isActive && !GameManager.Instance.isDie)
        SwordPos();
    }
    private void SwordPos()
    {
        if (Input.GetMouseButtonDown(0)&&!isAtk)
        {
            rot.z = 690f;
            //transform.Rotate(rot);
            StartCoroutine(atk(GameManager.Instance.atkSpeed));
        }
        else if (Input.GetMouseButtonDown(1) && !isAtk)
        {
            rot.z = -330f;
            //transform.Rotate(rot);
            StartCoroutine(atk(GameManager.Instance.atkSpeed));

        }
    }
    IEnumerator atk(float atkspeed)
    {
        swordEffect.Play();
        isAtk = true;
        Effect.SetActive(true);
        Swordcol.enabled = true;
        transform.DORotate(rot, atkspeed, RotateMode.FastBeyond360).SetEase(Ease.InOutExpo);
        yield return new WaitForSeconds(atkspeed);
        StartCoroutine(IsEffect());
        isAtk = false;
        Swordcol.enabled = false;

    }
    public IEnumerator IsEffect()
    {
        yield return new WaitForSeconds(0.1f);

        if (isAtk)
        {
            Effect.SetActive(true);
            StartCoroutine(IsEffect());
        }
        else
        {
            Effect.SetActive(false);
        }
    }
}
