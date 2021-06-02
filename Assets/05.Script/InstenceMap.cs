using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InstenceMap : MonoBehaviour
{
    public GameObject[] maps;
    public Vector3[] allpos;
    
    public void Open4()
    {
        int randomMap = Random.Range(0, 4);
        Instantiate(maps[1],transform.position + allpos[1],Quaternion.identity);
    }
}
