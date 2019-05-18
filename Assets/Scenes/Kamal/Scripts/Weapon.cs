using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    private float angle;
    private Vector2 offset;
    private Vector3 mouse;
    private Vector3 screenPoint;
    public Animation StabAnimation;
    public GameObject TridentPrefab;
    int layerMask = 1 << 8;
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {



        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 50 * Time.deltaTime);





        //throw
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (hit.collider != null)
            {
                Debug.DrawRay(transform.position, direction * 1000, Color.yellow);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, direction *1000, Color.white);
                Debug.Log("Did not Hit");
            }



            ThrowTridentInstance();
        }



        //stab
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            Stab();
        }


        //follow mouse direction

    }

   
    private void OnCollisionEnter2D(Collision2D col)
    {
        //damage enemy
    }






    public void ThrowTridentInstance()
    {
        Ray mseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject TridentInstance = Instantiate(TridentPrefab, gameObject.transform);

  //      TridentInstance.GetComponent<TridentInstance>().Endpoint =
        TridentInstance.transform.parent = null;
    }



    private void Stab()
    {
        StabAnimation.Play();
    }
}
