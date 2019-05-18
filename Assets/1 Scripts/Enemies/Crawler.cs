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
            target.Damage(DamageOutput);
        }
    }

    public override void ChasePlayer()
    {
        direction.x = (transform.position.x <= target.transform.position.x) ? 1 : -1;
        Move(direction, moveSpeed);
    }

}