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
    public LayerMask mask;
    public GameObject Tip;
    public GameObject TestSphere;
    public bool Collided = false;
    public float tridentDamage = 10 ;


    Vector3 shootDirection;
    private Rigidbody2D rb;
    Vector2 direction;
    public GameObject Player;
    void Start()
    {
       // mask = ~(1 << 10);
        Player = GameObject.FindGameObjectWithTag("Player");

        TriggerForwarder forwarder = GetComponentInChildren<TriggerForwarder>();
        forwarder.OnTriggerEvent += OnTriggerEnter2D;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("called");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("called");
        Enemy enem = collision.gameObject.GetComponent<Enemy>();
        if (enem)
        {
            enem.Damage(tridentDamage);
            enem.Knockback(transform.position, 5);
      //      GetComponentInChildren<BoxCollider2D>().enabled = false;
        }
    }

    public void ShootTrident()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Player.transform.position, mousepos - Player.transform.position, Mathf.Infinity, mask);
        hitpoint = hit.point;
        Instantiate(TestSphere, hit.point, Quaternion.identity);
        Debug.DrawRay(transform.position, direction * 1000, Color.yellow);

        gameObject.transform.parent = null;
        GetComponentInChildren<Rigidbody2D>().simulated = true;
        Thrown = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (!Thrown)
        {
      
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) -Player.transform.position;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
            rotation.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 500 * Time.deltaTime);




            //throw




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

    public void OnDestroy()
    {
        GetComponentInChildren<TriggerForwarder>().OnTriggerEvent -= OnTriggerEnter2D;
    }
}
