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

    private void Start()
    {
        StartCoroutine(GameStart());
    }
    public void Text(string text)
    {
        Sequence dleay = DOTween.Sequence();
        dleay.OnStart(() =>myText.DOText(text, 1f));
        dleay.SetDelay(2f);
        dleay.Append(myText.DOText(" ",0));
    }
    IEnumerator GameStart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        Text("������� ");
        yield return new WaitForSeconds(2f);
        Text("����� ȣ��ɿ� ���� ���Խ��ϴ�.");

        yield return new WaitForSeconds(2f);
        Text("���ö� ������� ������ �������� ���� �ٸ��Ҥ���");
        
        yield return new WaitForSeconds(2f);
        Text("W A S D�� ������ �� �ְ� ");
        yield return new WaitForSeconds(2f);
        Text("���콺 ��Ŭ������ ������ �� �ֽ��ϴ�.");

        yield return new WaitForSeconds(2f);
        Text("�׷� ������ ������ ������~~");
        isETC.SetActive(false);
    }
}
