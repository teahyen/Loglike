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
        Text("어서오세요 ");
        yield return new WaitForSeconds(2f);
        Text("당신은 호기심에 여기 들어왔습니다.");

        yield return new WaitForSeconds(2f);
        Text("들어올땐 마음대로 였지만 나갈때는 말이 다르죠ㅎㅎ");
        
        yield return new WaitForSeconds(2f);
        Text("W A S D로 움직일 수 있고 ");
        yield return new WaitForSeconds(2f);
        Text("마우스 우클릭으로 공격할 수 있습니다.");

        yield return new WaitForSeconds(2f);
        Text("그럼 열심히 집으로 오세요~~");
        isETC.SetActive(false);
    }
}
