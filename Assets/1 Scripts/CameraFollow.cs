using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    [Range(0,1)]
    public float LerpRate;

    private void LateUpdate()
    {
        Vector3 targetpos = Target.position;
        targetpos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, targetpos, LerpRate);
    }
}
