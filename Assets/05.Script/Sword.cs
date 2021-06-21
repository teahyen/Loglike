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
    BoxCollider2D Swordcol;
    private void Start()
    {
        Swordcol = SwordObg.GetComponent<BoxCollider2D>();
        Swordcol.enabled = false;
        SwordObg.transform.SetParent(null);
    }
    void Update()
    {
        SwordPos();
        //if (isSwap&& rot.z < 0) rot *= -1;
        //else if (!isSwap&& rot.z > 0) rot *= -1;

    }
    private void SwordPos()
    {
        if (Input.GetMouseButtonDown(0)&&!isAtk)
        {
            rot.y = 0;
            transform.Rotate(rot);
            StartCoroutine(atk());
            print("눌림");
        }
        else if (Input.GetMouseButtonDown(1) && !isAtk)
        {
            rot.y = 180;
            transform.Rotate(rot);
            StartCoroutine(atk());
            print("눌림");
        }
    }
    IEnumerator atk()
    {
        isAtk = true;
        Swordcol.enabled = true;
        transform.DORotate(rot, 0.3f, RotateMode.FastBeyond360).SetEase(Ease.InOutExpo);
        //transform.DORotate(rot,3, RotateMode.Fast)/*.SetLoops(-1).SetEase(Ease.Linear)*/;
        yield return new WaitForSeconds(0.3f);
        isAtk = false;
        Swordcol.enabled = false;

    }
}
