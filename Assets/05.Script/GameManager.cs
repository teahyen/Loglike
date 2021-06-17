using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region ΩÃ±€≈Ê
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
    public List<Sprite> swordList = new List<Sprite>();
    private void Start()
    {
        
    }
    private void Update()
    { 
        
    }
}
