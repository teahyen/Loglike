using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class GameOver : MonoBehaviour
{
    public Text gameOverTex;
    public Image myImage;
    private void Start()
    {
        myImage.DOFade(0, 3);
    }
    //1: 잔몹사 2: 미믹사 3: 보스사
    public void EndGame(int HowKill)
    {
        switch (HowKill)
        {
            case 1:
                OverTex("적에게 당했습니다.");
                break;

            case 2:
                OverTex("미믹에게 습격당했습니다.");
                break;

            case 3:
                OverTex("보스에게 사망했습니다.");
                break;
        }
    }
    public void OverTex(string tex)
    {
        gameOverTex.text = " ";
        gameOverTex.DOText(tex,3);
    }
    public void ReStart()
    {
        SceneManager.LoadScene("StartScenes");
        GameManager.Instance.maxHp = 170;
        GameManager.Instance.nowHp = GameManager.Instance.maxHp;
        GameManager.Instance.satge = 1;
        GameManager.Instance.atkDmg = 30;
        GameManager.Instance.atkSpeed = 0.3f;
    }
}
