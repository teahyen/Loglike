using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextSC : MonoBehaviour
{
    public static TextSC TextInstence;

    public Text myText;
    public GameObject isETC;
    private float time = 3f;
    Coroutine co;

    public Text TimeTex;
    private float sc;
    private float min;
    private float hour;

    public Text stageTex;

    private void Start()
    {
        if(GameManager.Instance.satge == 1)
        {
            co = StartCoroutine(GameStart());
        }
        else
        {
            Text($"������ {GameManager.Instance.satge}�������� ���");
            isETC.SetActive(false);

        }
        stageTex.text = ($"�������� {GameManager.Instance.satge}");

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(co);
            myText.text = " ";
            DOTween.KillAll();
            isETC.SetActive(false);
        }
        GameManager.Instance.timeCount += Time.deltaTime;
        sc = GameManager.Instance.timeCount;
        min = GameManager.Instance.timeCount / 60;
        hour = GameManager.Instance.timeCount / 3600;
        TimeTex.text = ($"{Mathf.Round(hour %= 60).ToString("00")}:{Mathf.Round(min %= 60).ToString("00")}:{Mathf.Round(sc %= 60).ToString("00")}");
        
    }

    public void Stage(int nowStage)
    {
        stageTex.text = ($"�������� {nowStage}");
    }

    public void Text(string text)
    {
        myText.text = " ";
        Sequence dleay = DOTween.Sequence();
        dleay.OnStart(() =>myText.DOText(text, 1.5f));
        dleay.SetDelay(2f);
        dleay.Append(myText.DOText(" ",0));
    }
    IEnumerator GameStart()
    {

        Text("���� ������ ���?");
        yield return new WaitForSeconds(time);

        Text("���� �� ������ ��ȣ���ε�..��������...");
        yield return new WaitForSeconds(time);

        Text("��...�׷��ϱ� �����Ѹ��� �ɷ��� ���⿡ ���Գ�...?");
        yield return new WaitForSeconds(time);

        Text("��...�̷� ���� �� ó���ε�...");
        yield return new WaitForSeconds(time);

        Text("������! �� ������ ���� �̻� ���� �� ���ò�?");
        yield return new WaitForSeconds(time);

        Text("�ϴ� W A S D�� ������ �� �ְ� ");
        yield return new WaitForSeconds(time);
        Text("���콺 ��Ŭ������ ������ �� �־�");

        yield return new WaitForSeconds(time);
        Text("�׷� �ⱸ���� ��ٸ��� ������");

        yield return new WaitForSeconds(time);
        Text("�� �׸��� �� ������ ������ �����ϱ� �����ϰ�~");
        isETC.SetActive(false);
        yield return new WaitForSeconds(time);
        Text("���� SPACE�� ������ ��ȭ�� ��ŵ�� �� ����");
    }
}
