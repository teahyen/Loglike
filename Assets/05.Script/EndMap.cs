using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndMap : MonoBehaviour
{
    TextSC TS;
    [Header("�þ� ����")]
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
            TS.Text("�� �� ������ ���� F�� ������ ���� ���������� ���ž�");
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
