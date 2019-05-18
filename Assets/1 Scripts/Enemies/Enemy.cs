﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EntityBase
{

    public float DamageOutput = 2.0f;
    public Player target;
    public bool inRange = false;
    public float attackRange = 0.2f;

    public float moveSpeed = 6.0f;

    public float attackCooldown = 1.0f;
    public float attackTimer = 0.0f;
    public Vector2 direction = Vector2.zero;

    public bool Grounded = true;

    public void Init(Player Target)
    {
        target = Target;
    }

    private void FixedUpdate()
    {
        if (!target) return;

        CheckPlayerInRange();
        CheckGrounded();

        if (inRange) AttackPlayer();
        else if(Grounded) ChasePlayer();
    }

    private void CheckPlayerInRange()
    {
        inRange = (Vector2.Distance(target.transform.position, transform.position) <= attackRange) ? true : false;
    }

    public virtual void CheckGrounded()
    {

    }

    public virtual void AttackPlayer()
    {

    }

    public virtual void ChasePlayer()
    {

    }

}
