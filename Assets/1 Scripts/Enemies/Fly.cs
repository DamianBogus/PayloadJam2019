using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Enemy
{
    public override void AttackPlayer()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer > attackCooldown)
        {
            attackTimer = 0;
           // rb.AddForce(Vector2.up * 100, ForceMode2D.Impulse);
            target.Damage(DamageOutput);
        }
    }

    public override void ChasePlayer()
    {
        Vector2 pos = target.transform.position;
        pos.y += 2;

        direction.y = (transform.position.y <= pos.y) ? 1 : -1;
        Move(direction, moveSpeed);
    }


}
