using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject crawler;
    public GameObject fly;


    public float spawnRate = 1.0f;


    public Player player;
    public Transform leftSpawn;
    public Transform rightSpawn;

    private Vector2 randomPos;

    private void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 1.0f, spawnRate);
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
