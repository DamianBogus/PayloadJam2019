using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EntityBase
{

    public float DamageOutput = 2.0f;
    public Transform target;
    public bool inRange = false;
    public float attackRange = 0.5f;

    private void Start()
    {
        
    }

    private void Update()
    {
        CheckPlayerInRange();

        if (inRange) AttackPlayer();
        else ChasePlayer();
    }

    private void CheckPlayerInRange()
    {
        inRange = (Vector2.Distance(target.position, transform.position) <= attackRange) ? true : false;
    }

    public virtual void AttackPlayer()
    {

    }

    public virtual void ChasePlayer()
    {

    }

}
