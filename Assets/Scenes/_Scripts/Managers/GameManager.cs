using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    public GameObject CooldownText;


    // This shouldn't be in here long term but it avoids merge conflicts :P
    public const float GUN_COOLDOWN = 1;
    public float GunCooldown = 0;


    void FixedUpdate()
    {
        refreshUI();
    }

    void refreshUI()
    {
        CooldownText.GetComponentInChildren<TMP_Text>().text = "cd:" + GunCooldown.ToString("G1");
    }
}
