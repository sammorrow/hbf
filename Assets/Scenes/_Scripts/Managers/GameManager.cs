using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject CooldownText;

    public const float BASE_SPAWN_TIME = 20;

    public float enemySpawnTime;
    public float enemySpawnTimer;
    public float gameRunTime;

    public int KillCount = 0;

    [SerializeField] private GameObject enemyPrefab;

    public void StartGame()
    {
        Time.timeScale = 1;
        gameRunTime = 0;
        enemySpawnTime = BASE_SPAWN_TIME; // TODO: tweak enemySpawnTime
        enemySpawnTimer = enemySpawnTime;
        Player.Instance.Initialize();
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowResults();
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    void FixedUpdate()
    {
        enemySpawnTime -= Time.deltaTime / 100; // makes enemies spawn slightly faster over time
        // TODO: work on better algorithm for this! 

        enemySpawnTimer -= Time.deltaTime;
        gameRunTime += Time.deltaTime;
        if (enemySpawnTimer < 0)
        {
            SpawnEnemy();
            enemySpawnTimer = enemySpawnTime;
        }
    }

    void SpawnEnemy()
    {
        Zone randomZone = ZoneManager.Instance.GetRandomZoneWeighted();
        Vector3 spawnLocation = ZoneManager.GetRandomPointInZone(randomZone);
        Instantiate(enemyPrefab, spawnLocation, new Quaternion(0, 180, 180, 0));
    }
}
