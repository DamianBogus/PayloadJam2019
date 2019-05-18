using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    private float cameraSize = 5.5f;
    float height = 0;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        height = Mathf.Clamp((transform.position.y + 6) * 0.45f, 1, 2);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, cameraSize * height, Time.deltaTime * 2.0f);
        
    }

}
