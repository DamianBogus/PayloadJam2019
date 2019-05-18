using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EntityBase : MonoBehaviour
{
    public float Health;

    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Damage(float damage)
    {
        Health -= damage;
        if(Health > 0)
        {
            Health = 0;
            Die();
        }
    }

    public virtual void Die()
    {
        //Do death stuff.
    }

    public virtual void Move(Vector2 direction, float multiplier = 3)
    {
        rb.AddForce(direction * multiplier, ForceMode2D.Impulse);
    }
}
