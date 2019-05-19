using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderinstance : MonoBehaviour
{
    private float temp = 6;
    public float ThunderDamage = 100;
    private List<Enemy> EnemyList = new List<Enemy>();
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(0,10,0);
        Invoke("ToggleThunder", 0.2f);
        Invoke("ToggleThunder", 0.4f);
        Invoke("ToggleThunder", 0.6f);
        Invoke("Applythunder", 0.5f);

    }
    private void ToggleThunder()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void Applythunder()
    {    
            RaycastHit2D[] Enemies = Physics2D.CircleCastAll(transform.position, 6, Vector2.zero);
            if (Enemies != null)
            {
                foreach (var Enemy in Enemies)
                {
                    Enemy e = Enemy.collider.gameObject.GetComponent<Enemy>();
                EnemyList.Add(e);
                    if (e)
                    {
                        e.Damage(ThunderDamage);
                        e.Knockback(transform.position + new Vector3(0, -1, 0), 200);
                    }
                }
            Destroy(gameObject,0.1f);
            }      
    }

    public void applyknockback()
    {

    }
    // Update is called once per frame
    void Update()
    {
   
        if (temp > 0)
        {
            transform.position -= new Vector3(0, 1f, 0);
            temp -= 0.5f;
        }
        
    }
}
