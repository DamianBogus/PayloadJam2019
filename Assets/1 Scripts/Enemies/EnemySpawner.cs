using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject crawler;

    public Player player;
    public Transform leftSpawn;
    public Transform rightSpawn;

    private Vector2 randomPos;

    private void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 1.0f, 0.2f);
    }

    private void SpawnNewEnemy()
    {
        if (Random.value > 0.5f) randomPos = leftSpawn.position;
        else randomPos = rightSpawn.position;

        GameObject enemy = Instantiate(crawler);
        enemy.transform.position = randomPos;
        enemy.GetComponent<Enemy>().Init(player);
    }
}
