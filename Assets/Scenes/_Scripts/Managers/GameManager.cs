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

    public const float GUN_COOLDOWN = 1;
    public const float BASE_SPAWN_TIME = 20;
    public float GunCooldown = 0;

    public float enemySpawnTime;
    public float enemySpawnTimer;
    public float gameRunTime;

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
        refreshUI();
        enemySpawnTime -= Time.deltaTime / 100; // makes enemies spawn slightly faster over time
        // TODO: work on better algorithm for this! 

        enemySpawnTimer -= Time.deltaTime;
        gameRunTime += Time.deltaTime;
        if (enemySpawnTimer < 0)
        {
            //SpawnEnemy();
            enemySpawnTimer = enemySpawnTime;
        }
    }

    void SpawnEnemy()
    {
<<<<<<< HEAD
        Vector3 spawnLocation = Vector3.zero; // TODO: figure out where to spawn the enemy! randomly inside the body...
        Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
    }

    void refreshUI()
    {
        CooldownText.GetComponentInChildren<TMP_Text>().text = "cd:" + GunCooldown.ToString("G1");
    }
}
=======
        Zone randomZone = ZoneManager.Instance.GetRandomZoneWeighted();
        Vector3 spawnLocation = ZoneManager.GetRandomPointInZone(randomZone);
        Instantiate(enemyPrefab, spawnLocation, new Quaternion(0, 180, 180, 0));
    }

    void refreshUI()
    {
        CooldownText.GetComponentInChildren<TMP_Text>().text = "cd:" + GunCooldown.ToString("G1");
    }
}
>>>>>>> 6f3ed83c97b16606772152e6f7ba8128e8158dad
