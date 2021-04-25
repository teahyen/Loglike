using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceManager : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("StageScenes");
    }
    public void ReStart()
    {
        SceneManager.LoadScene("StartScenes");
    }
}
