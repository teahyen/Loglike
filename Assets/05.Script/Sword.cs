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

    Player Player;
    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        Swordcol = SwordObg.GetComponent<BoxCollider2D>();
        Swordcol.enabled = false;
        SwordObg.transform.SetParent(null);
    }
    void Update()
    {
        if(!Setting.isActive && !GameManager.Instance.isDie)
        SwordPos();
        //if (isSwap&& rot.z < 0) rot *= -1;
        //else if (!isSwap&& rot.z > 0) rot *= -1;

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
        Swordcol.enabled = true;
        transform.DORotate(rot, atkspeed, RotateMode.FastBeyond360).SetEase(Ease.InOutExpo);
        //transform.DORotate(rot,3, RotateMode.Fast)/*.SetLoops(-1).SetEase(Ease.Linear)*/;
        yield return new WaitForSeconds(atkspeed);
        isAtk = false;
        Swordcol.enabled = false;
    }
}
