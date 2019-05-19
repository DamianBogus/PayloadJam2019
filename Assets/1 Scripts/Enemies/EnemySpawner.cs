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
    private float lastSpawnTime = -9999f;

    private void Start()
    {
        if (player == null) player = FindObjectOfType<Player>();
        player.Killcounter.OnThresholdsPassed += OnThresholdPassed;
    }

    private void OnThresholdPassed(int count)
    {
        switch (count)
        {
            case 1:
                spawnRate *= 0.6f;
                break;
            case 2:
                spawnRate *= 0.6f;
                break;
            case 3:
                spawnRate *= 0.8f;
                break;
            default:
                break;
        }
    }

    public void Update()
    {
        if(Time.time >= lastSpawnTime + spawnRate)
        {
            SpawnNewEnemy();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnNewEnemy()
    {
        if (enemyCount > 150) return;

        if (Random.value > 0.5f) randomPos = leftSpawn.position;
        else randomPos = rightSpawn.position;


        GameObject enemy;

        if (Random.value > 0.5f) enemy = Instantiate(crawler);
        else enemy = Instantiate(fly);

        enemy.transform.position = randomPos;
        Enemy enem = enemy.GetComponent<Enemy>();
        enem.Init(player);
        enem.OnDie += LostEnemy;

        NewEnemy();
    }

    public void NewEnemy()
    {
        enemyCount++;
    }

    public void LostEnemy(Enemy e)
    {
        //reduce the count and unsub ourselves.
        enemyCount--;
        e.OnDie -= LostEnemy;
    }
}
