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


    public GameObject _camera;
    public bool rotate;
    //�ǰ� �� �Ͼ�� �Լ���
    [SerializeField]
    private Image playerImg;
    public int hitTime =3;
    public bool ishit =false;
    [Header("�¾����� �����̴� Ƚ��")]
    private int hitEffect;
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
        _camera.transform.position = player.transform.position - new Vector3(0, 0, 3);

        nowKpbar.fillAmount = (float)nowHp / (float)maxHp;
        if (Input.GetKeyDown(KeyCode.F)&&rotate)
        {
            player.transform.Rotate(new Vector3(0,180,0));
            Debug.Log("���ư���Ƥ���");
            rotate = false;
        }
        else if (Input.GetKeyDown(KeyCode.F)&&!rotate)
        {
            player.transform.Rotate(new Vector3(0,-180,0));
            Debug.Log("�ٽ� ���ư���Ƥ�");
            rotate = true;
        }
        if(rotate == false)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                player.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            }

        }
        else if(rotate == true)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                player.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * -speed * Time.deltaTime, 0f, 0f));
            }
        }
        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            player.transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
        }
        //���� ����
        if (Input.GetMouseButtonDown(0) && atking == false)
        {
            Debug.Log("�ʷջǸ�");
            StartCoroutine(atk());
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            StartCoroutine(hit());
        }
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
    IEnumerator hit()
    {
        nowHp -= 10;
        print("����!");
        yield return new WaitForSeconds(hitTime);
    }
}
