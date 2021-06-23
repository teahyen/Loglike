using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndMap : MonoBehaviour
{
    TextSC TS;
    [Header("시아 범위")]
    public float sightRange;
    public bool bPlayerInSightRange;
    Vector2 pos;
    public LayerMask whatIsPlayer;

    private bool isKnow = false;    

    private void Start()
    {
        TS = GameObject.Find("What?").GetComponent<TextSC>();
    }
    void Update()
    {
        bPlayerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, whatIsPlayer);
        if (bPlayerInSightRange) NextStage();
    }
    private void NextStage()
    {
        if (!isKnow)
        {
            TS.Text("저 돌 가까이 가서 F를 누르면 다음 스테이지로 갈거야");
            isKnow = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameManager.Instance.satge++;
            TS.Stage(GameManager.Instance.satge);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Box>())
        {
            Destroy(col.gameObject);
        }
    }
}
