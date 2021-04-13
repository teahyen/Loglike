using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator anim = null;

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject player;

    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1;
    public bool attacked = false;
    public Image nowKpbar;

    [SerializeField]
    private GameObject Sword;
    public bool atking = false;

    [SerializeField]
    private GameObject _camera;

    public bool isAngle = true;
    void SetAttackSpeed(float speed)
    {
        atkSpeed = speed;
    }
    private void Start()
    {
        Sword.SetActive(false);

        SetAttackSpeed(1.5f);
    }
    private void Update()
    {
        //�÷��̾ ���� ����
        if (Input.GetKeyDown(KeyCode.F)&&isAngle)
        {
            gameObject.transform.rotation = (Quaternion.Euler(0, 180, 0));
            isAngle = false;
           
        }
        else if (Input.GetKeyDown(KeyCode.F) && !isAngle)
        {
            gameObject.transform.rotation = (Quaternion.Euler(0, 0, 0));
            isAngle = true;
        }
        //���� ����
        if (Input.GetKeyDown(KeyCode.Space) && atking == false)
        {
            Debug.Log("�ʷջǸ�");
            StartCoroutine(atk());
        }
        //�÷��̾� �̵� ��/�Ʒ�
        nowKpbar.fillAmount = (float)nowHp / (float)maxHp;

        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            player.transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
        }
        //�÷��̾� ������ �̵�
        if (isAngle== true)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                player.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            }
        }
        else if (isAngle == false)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                player.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * -speed * Time.deltaTime, 0f, 0f));
            }
        }

        //ī�޶� �̵�
        _camera.transform.position = (new Vector3(transform.position.x, transform.position.y, -3));
    }
    IEnumerator atk()
    {
        Sword.SetActive(true);
        anim.Play("SwordAnimation");
        atking = true;
        yield return new WaitForSeconds(0.5f);
        Sword.SetActive(false);
        atking = false;
    }

}
