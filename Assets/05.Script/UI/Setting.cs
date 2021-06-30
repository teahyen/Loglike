using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject settingPenal;
    [Header("BGM����")]
    public Scrollbar SoundBarBGM;
    public AudioSource BGMSound;
    public Text SoundBGMTex;
    [Header("�÷��̾� �Ҹ� ����")]
    public Scrollbar swingSoundBar;
    public AudioSource swingSound;
    public Text swingSoundTex;
    [Header("�� �Ҹ� ����")]
    public Scrollbar enemySoundBar;
    public AudioSource enemySound;
    public Text enemySoundTex;
    public static bool isActive =false;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isActive = false;
        settingPenal.SetActive(false);
        SoundBarBGM.value = GameManager.Instance.BGMNum ;
        swingSoundBar.value = GameManager.Instance.PlayerNum;
        enemySoundBar.value = GameManager.Instance.EnemyNum;
    }

    void Update()
    {

        GameManager.Instance.BGMNum = SoundBarBGM.value;
        GameManager.Instance.PlayerNum = swingSoundBar.value ;
        GameManager.Instance.EnemyNum = enemySoundBar.value;
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!isActive)
            {
                Time.timeScale = 0;
                settingPenal.SetActive(true);
                isActive = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                settingPenal.SetActive(false);
                isActive = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        //BGM����
        BGMSound.volume = SoundBarBGM.value;
        SoundBGMTex.text = (SoundBarBGM.value * 100).ToString("N0");

        //��������
        swingSound.volume = swingSoundBar.value;
        swingSoundTex.text = (swingSoundBar.value * 100).ToString("N0");

        //�� �Ȱݽ� ����
        enemySound.volume = enemySoundBar.value;
        enemySoundTex.text = (enemySoundBar.value * 100).ToString("N0");

    }
    //����ϱ�
    public void Con()
    {
        Time.timeScale = 1;
        settingPenal.SetActive(false);
        isActive = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    //�ٽ��ϱ�
    public void ReStart()
    {
        SceneManager.LoadScene("StartScenes");
        GameManager.Instance.maxHp = 170;
        GameManager.Instance.nowHp = GameManager.Instance.maxHp;
        GameManager.Instance.satge = 1;
        GameManager.Instance.atkDmg = 30;
        GameManager.Instance.atkSpeed = 0.3f;
        GameManager.Instance.timeCount = 0;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    //������
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

