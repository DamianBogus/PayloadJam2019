using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : Enemy
{
    public override void AttackPlayer()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer > attackCooldown)
        {
            attackTimer = 0;
            rb.AddForce(Vector2.up * 100, ForceMode2D.Impulse);
            target.Damage(DamageOutput * Enemy.DamageScale);
        }
    }

    public override void ChasePlayer()
    {
        Move(direction, moveSpeed);
    }

}