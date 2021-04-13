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
        //플레이어가 보는 방향
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
        //근접 공격
        if (Input.GetKeyDown(KeyCode.Space) && atking == false)
        {
            Debug.Log("뽈롱뽀륭");
            StartCoroutine(atk());
        }
        //플레이어 이동 위/아래
        nowKpbar.fillAmount = (float)nowHp / (float)maxHp;

        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            player.transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
        }
        //플레이어 반전시 이동
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

        //카메라 이동
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
