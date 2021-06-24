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
    //1: �ܸ��� 2: �̹ͻ� 3: ������
    public void EndGame(int HowKill)
    {
        switch (HowKill)
        {
            case 1:
                OverTex("������ ���߽��ϴ�.");
                break;

            case 2:
                OverTex("�̹Ϳ��� ���ݴ��߽��ϴ�.");
                break;

            case 3:
                OverTex("�������� ����߽��ϴ�.");
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
