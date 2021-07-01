using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject settingPenal;
    [Header("BGM설정")]
    public Scrollbar SoundBarBGM;
    public AudioSource BGMSound;
    public Text SoundBGMTex;
    [Header("플레이어 소리 설정")]
    public Scrollbar swingSoundBar;
    public AudioSource swingSound;
    public Text swingSoundTex;
    [Header("적 소리 설정")]
    public Scrollbar enemySoundBar;
    public AudioSource enemySound;
    public Text enemySoundTex;
    public static bool isActive =false;
    [Header("커멘트 관룐")]
    public GameObject commandObj;
    public GameObject player;
    public bool iscommand = false;
    public InputField whatTex;
    public Text[] reportTex = new Text[6];

    void Start()
    {
        commandObj.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Escape)&&!iscommand)
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
        //BGM사운드
        BGMSound.volume = SoundBarBGM.value;
        SoundBGMTex.text = (SoundBarBGM.value * 100).ToString("N0");

        //스윙사운드
        swingSound.volume = swingSoundBar.value;
        swingSoundTex.text = (swingSoundBar.value * 100).ToString("N0");

        //적 픽격시 사운드
        enemySound.volume = enemySoundBar.value;
        enemySoundTex.text = (enemySoundBar.value * 100).ToString("N0");

        //커멘드 관련
        if (Input.GetKeyDown(KeyCode.Tab) &&!isActive)
        {
            if (!iscommand)
            {
                commandObj.SetActive(true);
                iscommand = true;
                Time.timeScale = 0;
                whatTex.ActivateInputField();
            }
            else if(iscommand)
            {
                commandObj.SetActive(false);
                iscommand = false;
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
        if (whatTex.isFocused && whatTex.text != "" && Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter) && whatTex.text != "적용되었습니다.")
        {
            apply();
        }
    }
    #region 설정창
    //계속하기
    public void Con()
    {
        Time.timeScale = 1;
        settingPenal.SetActive(false);
        isActive = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    //다시하기
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    //나가기
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    #endregion
    #region 커멘드

    public void apply()
    {
        for (int i = 5; i >= 1; i--)
        {
            reportTex[i].text = reportTex[i - 1].text;
        }
        reportTex[0].text = whatTex.text;
        string t = whatTex.text;
        if (whatTex.text.Contains("/Dmg"))
        {
            t = t.Replace("/Dmg", "");
            whatTex.text = t;
            GameManager.Instance.atkDmg = int.Parse(t);
            whatTex.text = "적용되었습니다.";
            Debug.Log("공격력증가");
        }
        else if (whatTex.text.Contains("/Speed"))
        {
            t = t.Replace("/Speed", "");
            GameManager.Instance.speed = float.Parse(t);
            whatTex.text = "적용되었습니다.";
            Debug.Log("이속증가");

        }
        else if (whatTex.text.Contains("/MaxHp"))
        {
            t = t.Replace("/MaxHp", "");
            GameManager.Instance.maxHp = int.Parse(t);
            whatTex.text = "적용되었습니다.";
            Debug.Log("최대 체력증가");
        }
        else if (whatTex.text.Contains("/Heal"))
        {
            t = t.Replace("/Heal", "");
            whatTex.text = whatTex.text.Replace("/Heal", "");
            GameManager.Instance.nowHp += int.Parse(whatTex.text);
            whatTex.text = "적용되었습니다.";
            Debug.Log("체력회복");
        }
        else if (whatTex.text.Contains("/BossRoom"))
        {
            GameObject Boss = GameObject.Find("EndDoor(Clone)");
            player.transform.position = Boss.transform.position;
        }
        else
        {
            whatTex.text = "";
        }
    }
    #endregion
}

