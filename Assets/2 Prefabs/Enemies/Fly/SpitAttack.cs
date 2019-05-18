using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitAttack : MonoBehaviour
{
    private float timer = 0;


    public void AddForceToAttack(Vector2 direction, ForceMode2D forceMode)
    {
        GetComponent<Rigidbody2D>().AddForce(direction, forceMode);
    }
    
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.25f) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            collision.GetComponent<Player>().Damage(0.4f);
            Destroy(gameObject);
        }
    }

}
