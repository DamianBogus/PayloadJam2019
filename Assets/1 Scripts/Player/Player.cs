using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : EntityBase
{
    [HideInInspector]
    public PlayerMovement Movement;

    public KillCounter Killcounter;

    public void Awake()
    {
        Killcounter = new KillCounter();
    }

}
