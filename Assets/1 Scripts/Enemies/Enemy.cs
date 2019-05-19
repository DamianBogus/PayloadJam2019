using System.Collections;
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

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public bool Grounded = true;

    public void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    public void Init(Player Target)
    {
        target = Target;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        base.FixedUpdate();

        if (!target) return;

        CheckPlayerInRange();
        CheckGrounded();

        if (inRange) AttackPlayer();
        else if(Grounded) ChasePlayer();
    }

    private void CheckPlayerInRange()
    {
        inRange = (Vector2.Distance(target.transform.position, transform.position) <= attackRange) ? true : false;
        direction.x = (transform.position.x < target.transform.position.x) ? 1 : -1;

        if (direction.x == 1) spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;

    }

    public virtual void CheckGrounded()
    {
        Grounded = IsGrounded;
    }

    public virtual void AttackPlayer()
    {

    }

    public virtual void ChasePlayer()
    {

    }

    public override void Damage(float damage)
    {
        base.Damage(damage);

        anim.SetTrigger("Damaged");
    }

    public override void Die()
    {
        base.Die();

        anim.SetTrigger("Die");

        //Increase kill count.
        target.Killcounter.Kills++;

        Invoke("DestroyDeath", 1.1f);
    }

    private void DestroyDeath()
    {
        Destroy(gameObject);
    }
}
