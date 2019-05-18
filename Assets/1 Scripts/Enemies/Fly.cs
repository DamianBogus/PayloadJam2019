using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Enemy
{
    public GameObject spitPrefab;
    private GameObject spitInstance;

    public override void AttackPlayer()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer > attackCooldown)
        {
            attackTimer = 0;

            Vector2 direction = transform.position - target.transform.position;

            spitInstance = Instantiate(spitPrefab);
            spitInstance.transform.position = transform.position;
            spitInstance.GetComponent<SpitAttack>().AddForceToAttack(-direction * 20, ForceMode2D.Impulse);

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
