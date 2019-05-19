using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderAbility : MonoBehaviour
{
    private float ThunderCooldown= 1;
    private bool oncooldown;
    public GameObject ThunderPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (oncooldown == false)
            {
                GetThunder();
                Invoke("ResetCD",ThunderCooldown * GameManager.CooldownScaleFactor);
            }
          
        }
        
    }
    public void ResetCD()
    {
        oncooldown = false;
    }

    public void GetThunder()
    {
        oncooldown = true;
        foreach (GameObject Trident in GameManager.Tridentlist)
        {
            Vector3 pos = Trident.GetComponentInChildren<ObjectTajer>().gameObject.transform.position;
            StrikeThunder(pos);
        }
    }

    public void StrikeThunder(Vector3 ThunderLocation) {
        Instantiate(ThunderPrefab, ThunderLocation, Quaternion.identity);
    }

    
}
