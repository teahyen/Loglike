using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [Header("타겟설정")]
    [SerializeField]
    private GameObject target;
    [Header("따라갈 시간")]
    [SerializeField]
    private float followDur = 1f;
    [Header("오프셋")]
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
