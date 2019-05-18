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
    public GameObject TestSphere;
    public bool Collided = false;


    Vector3 shootDirection;
    private Rigidbody2D rb;
    Vector2 direction;
    public GameObject Player;
    void Start()
    {
    
    }


    // Update is called once per frame
    void Update()
    {
        if (Thrown == false)
        {
      
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) -Player.transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
            rotation.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 50 * Time.deltaTime);




            //throw
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(Player.transform.position, mousepos - Player.transform.position, layerMask);
                hitpoint = hit.point;
                Instantiate(TestSphere, hit.point, Quaternion.identity);
                Debug.DrawRay(transform.position, direction * 1000, Color.yellow);
             
                gameObject.transform.parent = null;
                GetComponentInChildren<Rigidbody2D>().simulated = true;
                Thrown = true;
            
            }



            //stab
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                Stab();
            }


            //follow mouse direction
        }
        else if(Collided == false)
        {
            if (Vector2.Distance(Tip.transform.position,hitpoint) >= 0.5f)
            {
                transform.Translate(Vector3.right * 10 * Time.deltaTime);
            }
          

            
 

        }

    }






    public void ThrowTridentInstance()
    {
    
    }

    

    private void Stab()
    {
        StabAnimation.Play();
    }
}
