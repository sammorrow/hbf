using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Placeholder class to store player state. 
public class Player : Singleton<Player>
{
    public float maxHealth = 100;
    public float health;
    public float[] ammo = new float[3]; // player has 3 types of ammo
    public float ammoType; // 0, 1, or 2

    public bool IsDead;

    [SerializeField] private GameObject prefabShot1;
    [SerializeField] private GameObject prefabShot2;
    [SerializeField] private GameObject prefabShot3;

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 randomLocation = transform.position;
            Quaternion randomRotation = Quaternion.identity; // TODO: set this to be a random rotation (only 1 axis needs to be set probably)
            Instantiate(prefabShot1, randomLocation, randomRotation); // TODO: change
            // TODO: spawn creature based on ammoType
        }
    }

    private void SwitchAmmo()
    {
        if (Input.GetButton("X"))
        {
            ammoType = (ammoType + 1) % 3;
        }
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

    void FixedUpdate()
    {
        Shoot();
        SwitchAmmo();
    }


}
