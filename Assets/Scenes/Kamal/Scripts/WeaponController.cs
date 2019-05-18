﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Trident;
    public float BasicAttackRate = 0.5f;
    void Start()
    {
      Trident = GetComponentInChildren<Weapon>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (GetComponentInChildren<Weapon>())
            {
                GetComponentInChildren<Weapon>().ShootTrident();
                Invoke("SpawnNewTrident", BasicAttackRate);
            }
 

        }

    }

    public void SpawnNewTrident()
    {
        Instantiate(Trident, gameObject.transform.position, Quaternion.identity).transform.parent = gameObject.transform;
    }
}