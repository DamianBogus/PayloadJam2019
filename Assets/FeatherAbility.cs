using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherAbility : MonoBehaviour
{
    public GameObject FeatherPrefab;
    public int NumberOfFeathers = 10;
    private List<Vector3> EnemyList = new List<Vector3>();
    private List<GameObject> FeatherList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

 
    }




    public void SpawnFeathers(int NumberofEnemies)
    {
        for (int i = 0; i < NumberofEnemies; i++)
        {
          GameObject feather =  Instantiate(FeatherPrefab, gameObject.transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            FeatherList.Add(feather);
        }
        EnemyList.Clear();
        AssignFeathers();

    }
    public void DetectEnemies()
    {
        RaycastHit2D[] Enemies = Physics2D.CircleCastAll(transform.position, 6, Vector2.zero);
        if (Enemies != null)
        {
            foreach (var Enemy in Enemies)
            {
                Vector3 e = Enemy.collider.gameObject.transform.position;
                EnemyList.Add(e);

            }
    
        }
        else
        {
            DetectEnemies();//ad delay
        }
        SpawnFeathers(EnemyList.Count);

    }

    public void AssignFeathers()
    {
        int i = 0;
        foreach (var pos in EnemyList)
        {
            FeatherList[i].GetComponent<featherinstance>().Target = pos;
            i++;
        }
    }


    //e.Damage(ThunderDamage);
    //                    e.Knockback(transform.position + new Vector3(0, -1, 0), 200);
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DetectEnemies();
        }
        
    }
}
