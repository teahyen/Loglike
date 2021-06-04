using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region ½Ì±ÛÅæ
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject temp = new GameObject("GameManager");
                    instance = temp.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    public bool clear = false;
    public int lastenemy;
    public int listMap = 10;

    //public GameObject[] maps = new GameObject[13];
    //[Header("À§ ¾Æ·¡ ¿À¸¥ÂÊ ¿ÞÂÊ")]
    //public GameObject[] endMaps = new GameObject[4];
    //public bool isStop;
    private void Start()
    {
        //isStop = false;
    }
    private void Update()
    {
        if (lastenemy == 0)
            clear = true;
    }
}
