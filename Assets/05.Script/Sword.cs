using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sword : MonoBehaviour
{

    [SerializeField]
    private GameObject SwordObg;
    private Vector3 rot;
    bool isAtk = false;
    //피격 시 일어나는 함수들
    BoxCollider2D Swordcol;
    private void Start()
    {
        Swordcol = SwordObg.GetComponent<BoxCollider2D>();
        Swordcol.enabled = false;
        SwordObg.transform.SetParent(null);
        rot = new Vector3(0, 0, -30);
    }
    void Update()
    {
        SwordPos();

    }
    private void SwordPos()
    {
        if (Input.GetMouseButtonDown(0)&&!isAtk)
        {
            StartCoroutine(atk());
            print("눌림");
        }
    }
    IEnumerator atk()
    {
        isAtk = true;
        Swordcol.enabled = true;
        transform.DORotate(rot, 0.4f, RotateMode.FastBeyond360).SetEase(Ease.InOutExpo);
        //transform.DORotate(rot,3, RotateMode.Fast)/*.SetLoops(-1).SetEase(Ease.Linear)*/;
        yield return new WaitForSeconds(0.4f);
        Swordcol.enabled = false;
        isAtk = false;
    }
}
