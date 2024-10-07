using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject CooldownText;

    public const float BASE_SPAWN_TIME = 20;

    public float enemySpawnTime;
    public float enemySpawnTimer;
    public float gameRunTime;
    public int KillCount = 0;
    public float SurvivalTime = 0;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject world;

    public void StartGame()
    {
        ClearGameState();
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

    private void ClearGameState()
    {
        // TODO: get all gameobjects in scene, find all gameobjects in "enemy" layer
        GameObject[] sceneObjs = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject obj in sceneObjs)
        {
            if (obj.layer == LayerMask.NameToLayer("Enemy"))
                Destroy(obj);
        }
        foreach (Transform child in world.transform)
        {
            if (child.tag == "Untagged")
                Destroy(child.gameObject);
        }
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
        SurvivalTime += Time.fixedDeltaTime;
    }

    void SpawnEnemy()
    {
        Zone randomZone = ZoneManager.Instance.GetRandomZoneWeighted();
        Vector3 spawnLocation = ZoneManager.GetRandomPointInZone(randomZone);
        Instantiate(enemyPrefab, spawnLocation, new Quaternion(0, 180, 180, 0));
    }
}
