using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitAttack : MonoBehaviour
{
    private float timer = 0;
    private Transform target;

    //public void AddForceToAttack(Vector2 direction, ForceMode2D forceMode)
    //{
    //    GetComponent<Rigidbody2D>().AddForce(direction, forceMode);
    //}

    
    public void SetTarget(Transform Target)
    {
        target = Target;
    }
    private void Update()
    {

        MoveToPlayer();
        timer += Time.deltaTime;

        if (timer > 0.9f) Destroy(gameObject);
    }

    private void MoveToPlayer()
    {
        if (target == null) return;

        Vector2 direction = transform.position - target.position;
        direction.Normalize();
        transform.Translate(direction * -0.2f);
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
