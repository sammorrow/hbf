using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Placeholder class to store player state. 
public class Player : MonoBehaviour
{

    public float maxHealth = 100;
    public float health;
    public float[] ammo = new float[3]; // player has 3 types of ammo
    public float ammoType;

    public bool IsDead;

    void SwitchAmmo()
    {
        ammoType = (ammoType + 1) % 3;
    }

    public void DamagePlayer(float damageValue)
    {
        health -= damageValue;
    }

    void Start()
    {
        health = maxHealth;
        ammoType = 0;
    }

    void Update()
    {

    }
}
