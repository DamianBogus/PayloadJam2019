using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraParalax : MonoBehaviour
{
    public Transform Target;
    public Transform Background;
    public Transform Background2;

    public float MoveRate = 0.5f;
    public float MoveRate2 = 0.4f;

    public float MaxY;
    public float MinY;

    private Vector3 _lastPos;

    public void Start()
    {
        if (Target == null) Target = FindObjectOfType<Player>().transform;

        _lastPos = Target.position;
    }

    void LateUpdate()
    {
        Vector3 diff = _lastPos - Target.position;
        diff.y = 0;
        Background.Translate(diff * MoveRate);
        Background2.Translate(diff * MoveRate2);

        _lastPos = Target.position;
    }
}
