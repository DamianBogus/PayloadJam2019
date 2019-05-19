using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Trident;
    private float BasicAttackRate = 0.2f;
 //   public static LayerMask layermask;
    void Start()
    {

     // Trident = GetComponentInChildren<Weapon>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (GetComponentInChildren<Weapon>())
            {
                GetComponentInChildren<Weapon>().ShootTrident();
                Invoke("SpawnNewTrident", BasicAttackRate * GameManager.CooldownScaleFactor);
            }
 

        }

    }

    public void SpawnNewTrident()
    {
        Instantiate(Trident, gameObject.transform.position + new Vector3(0f,1f,0), Quaternion.identity).transform.parent = gameObject.transform;
    }
}
