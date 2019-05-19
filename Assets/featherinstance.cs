using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class featherinstance : MonoBehaviour
{
    public Vector3 Target;
    private bool chase;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }


// Update is called once per frame
void Update()
    {
        if (Target!= null)
        {

            Target.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, Target, speed *Time.deltaTime);
        }

    }
}
