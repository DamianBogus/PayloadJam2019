using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int enemyCount = 0;

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

        if (player == null) player = FindObjectOfType<Player>();
    }

    private void SpawnNewEnemy()
    {
        if (enemyCount > 100) return;

        if (Random.value > 0.5f) randomPos = leftSpawn.position;
        else randomPos = rightSpawn.position;


        GameObject enemy;

        if (Random.value > 0.5f) enemy = Instantiate(crawler);
        else enemy = Instantiate(fly);

        enemy.transform.position = randomPos;
        enemy.GetComponent<Enemy>().Init(player);
        NewEnemy();
    }

    public void NewEnemy()
    {
        enemyCount++;
    }

    public void LostEnemy()
    {
        enemyCount--;
    }
}
