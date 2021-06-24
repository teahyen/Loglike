using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastStat : MonoBehaviour
{

    public Sprite[] addAtkSpeedImg = new Sprite[4];
    public Sprite[] addAtkDmgImg = new Sprite[4];
    public Sprite[] addMaxHpImg = new Sprite[4];
    int a = 0;

    SpriteRenderer MySpriteRenderer;
    private void Start()
    {
        MySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    //1번 공속 2번 데미지 3번 체력

    public void AddStat(int whatStat)
    {
        if(GameManager.Instance.MaxStat > 0)
        {
            a++;
            if (whatStat == 1 && a > 3)
            {
                MySpriteRenderer.sprite = addAtkSpeedImg[a];
            }
            else if (whatStat == 2 && a > 3)
            {
                MySpriteRenderer.sprite = addAtkDmgImg[a];
            }
            else if (whatStat == 3 && a > 3)
            {
                MySpriteRenderer.sprite = addMaxHpImg[a];
            }
            GameManager.Instance.MaxStat--;
        }
        print("눌렸습니다");
    }
    //1번 공속 2번 데미지 3번 체력

    public void RemoveStat(int whatStat)
    {

        if (GameManager.Instance.MaxStat < 5)
        {
            a--;
            if (whatStat == 1 && a > 3)
            {
                MySpriteRenderer.sprite = addAtkSpeedImg[a];
            }
            else if (whatStat == 2 && a > 3)
            {
                MySpriteRenderer.sprite = addAtkDmgImg[a];
            }
            else if (whatStat == 3 && a > 3)
            {
                MySpriteRenderer.sprite = addMaxHpImg[a];
            }
            GameManager.Instance.MaxStat++;
        }
        print("사라집니다.");

    }
}
