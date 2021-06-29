using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [Header("Ÿ�ټ���")]
    [SerializeField]
    private GameObject target;
    [Header("���� �ð�")]
    [SerializeField]
    private float followDur = 1f;
    [Header("������")]
    [SerializeField]
    private Vector3 offset = Vector3.zero;
    private Vector3 targetDir;
    private void FixedUpdate()
    {

        FollowTarget();
    }
    void FollowTarget()
    {
        targetDir.Set(target.transform.position.x + offset.x, target.transform.position.y + offset.y,-1);
        transform.DOMove(targetDir, followDur);
    }
}
