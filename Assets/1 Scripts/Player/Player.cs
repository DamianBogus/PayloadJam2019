using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : EntityBase
{
    [HideInInspector]
    public PlayerMovement Movement;

    public KillCounter Killcounter;

    private GameUI gameUI;

    public void Awake()
    {
        Killcounter = new KillCounter();
    }

    public void Start()
    {
        base.Start();

        gameUI = FindObjectOfType<GameUI>();
        Movement = GetComponent<PlayerMovement>();
    }

    public override void Die()
    {
        base.Die();

        Movement.enabled = false;

        gameUI.EnableDeathPanel();
    }

#if UNITY_EDITOR

    [ContextMenu("Hurt")]
    public void Hurt()
    {
        Damage(999);
    }
#endif
}
