using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    public GameObject CooldownText;


    public const float GUN_COOLDOWN = 1;
    public float GunCooldown = 0;

    public float enemySpawnTime;
    public float enemySpawnTimer;
    public float gameRunTime;

    public void StartGame()
    {
        Time.timeScale = 1;
        gameRunTime = 0;
        enemySpawnTime = 20; // TODO: tweak enemySpawnTime and Timer
        enemySpawnTimer = enemySpawnTime;
        Player.Instance.Initialize();
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    void FixedUpdate()
    {
        refreshUI();
        enemySpawnTimer -= Time.deltaTime;
        gameRunTime += Time.deltaTime;
    }

    void refreshUI()
    {
        CooldownText.GetComponentInChildren<TMP_Text>().text = "cd:" + GunCooldown.ToString("G1");
    }
}
