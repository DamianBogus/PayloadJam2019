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
    public Vector3 hitpoint;
    private bool Thrown = false;
    int layerMask = 1 << 8;
    public GameObject Tip;



    private Rigidbody2D rb;
    private RaycastHit hit;
    private Vector3 movdir;
    void Start()
    {
    
    }


    // Update is called once per frame
    void Update()
    {
        if (Thrown == false)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
            rotation.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 50 * Time.deltaTime);







            //throw
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

                if (hit.collider != null)
                {
                    hitpoint = hit.point;
                    movdir = (hitpoint - gameObject.transform.position);

                    Debug.DrawRay(transform.position, direction * 1000, Color.yellow);
                    Debug.Log("Did Hit");
                                gameObject.transform.parent = null;
                    Thrown = true;
             
                }
                else
                {
                    Debug.DrawRay(transform.position, direction * 1000, Color.white);
                    Debug.Log("Did not Hit");
                }



             
            }



            //stab
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                Stab();
            }


            //follow mouse direction
        }
        else
        {

            Vector2 direction = hitpoint - gameObject.transform.position;
            direction.Normalize();
            //  GameObject projectile = (GameObject)Instantiate(projectilePrefab, myPos, Quaternion.identity);
            print(Vector2.Distance(transform.position, hitpoint));
            if (Vector2.Distance(transform.position,hitpoint) >= 1.9f)
            {
                transform.position = Vector3.MoveTowards(transform.position, hitpoint, 5f * Time.deltaTime);
            }
 

        }

    }

   
    private void OnCollisionEnter2D(Collision2D col)
    {
        //damage enemy
    }






    public void ThrowTridentInstance()
    {
    
    }

    

    private void Stab()
    {
        StabAnimation.Play();
    }
}
