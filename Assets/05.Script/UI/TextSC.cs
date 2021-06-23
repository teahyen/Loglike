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
            Text($"지금은 {GameManager.Instance.satge}스테이지 라네");
            isETC.SetActive(false);

        }
        stageTex.text = ($"스테이지 {GameManager.Instance.satge}");

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
        stageTex.text = ($"스테이지 {nowStage}");
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

        Text("어이 정신이 드니?");
        yield return new WaitForSeconds(time);

        Text("나는 이 던전의 수호자인데..가만보자...");
        yield return new WaitForSeconds(time);

        Text("어...그러니깐 나무뿌리에 걸려서 여기에 들어왔네...?");
        yield return new WaitForSeconds(time);

        Text("하...이런 경우는 또 처음인데...");
        yield return new WaitForSeconds(time);

        Text("하지만! 이 던전에 들어온 이상 쉽게 못 나올껄?");
        yield return new WaitForSeconds(time);

        Text("일단 W A S D로 움직일 수 있고 ");
        yield return new WaitForSeconds(time);
        Text("마우스 좌클릭으로 공격할 수 있어");

        yield return new WaitForSeconds(time);
        Text("그럼 출구에서 기다리고 있을께");

        yield return new WaitForSeconds(time);
        Text("아 그리고 이 던전엔 적들이 많으니깐 조심하고~");
        isETC.SetActive(false);
        yield return new WaitForSeconds(time);
        Text("아참 SPACE를 누르면 대화를 스킵할 수 있지");
    }
}
