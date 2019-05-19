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
    private float lastDistance = 9999;
    private float currentdistance;
    private Vector3 lastpos;
    private Vector3 currentpos;


    Vector3 shootDirection;
    private Rigidbody2D rb;
    Vector2 direction;
    public GameObject Player;
    void Start()
    {
        GetComponentInChildren<BoxCollider2D>().enabled = true;
        GameManager.Tridentlist.Add(gameObject);
       // mask = ~(1 << 10);
        Player = GameObject.FindGameObjectWithTag("Player");

        TriggerForwarder forwarder = GetComponentInChildren<TriggerForwarder>();
        forwarder.OnTriggerEvent += OnTriggerEnter2D;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        GetComponentInChildren<BoxCollider2D>().enabled = true;
        gameObject.transform.parent = null;
    //    GetComponentInChildren<Rigidbody2D>().simulated = true;
        Destroy(gameObject, 4);
        Thrown = true;
    }



    // Update is called once per frame
    void Update()
    {
        GameManager.CooldownScaleFactor += 0.0001f;








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
            currentpos = gameObject.transform.position;
            currentdistance = Vector2.Distance(Tip.transform.position, hitpoint);

            if (currentdistance <= lastDistance)
            {
                transform.Translate(Vector3.right * 50 * Time.deltaTime);
            }
            else
            {
                gameObject.transform.position = lastpos;
                Collided = true;
                gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
            }
            lastpos = currentpos;
            lastDistance = currentdistance;

            
 

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
        GameManager.Tridentlist.Remove(gameObject);
    }
}
