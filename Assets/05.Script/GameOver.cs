using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class GameOver : MonoBehaviour
{
    public Text myText;
    public GameObject fadeImg;
    Image myImage = null;
    private void Start()
    {
        myImage = fadeImg.GetComponent<Image>();
        Time.timeScale = 1;
        myImage.DOFade(0, 5);
    }
    private void Update()
    {
        if(myImage.color.a <= 0.3f)
        {
            fadeImg.SetActive(false);
        }
    }
    //1: �ܸ��� 2: �̹ͻ� 3: ������
    public void EndGame()
    {

        switch (GameManager.Instance.whokill)
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
        myText.text = " ";
        myText.DOText(tex, 1.5f);
    }
    public void ReStart()
    {
        SceneManager.LoadScene("StartScenes");
        GameManager.Instance.maxHp = 170;
        GameManager.Instance.nowHp = GameManager.Instance.maxHp;
        GameManager.Instance.satge = 1;
        GameManager.Instance.atkDmg = 30;
        GameManager.Instance.atkSpeed = 0.3f;
        GameManager.Instance.timeCount = 0;
    }
}
