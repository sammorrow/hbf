using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This should go into the player class really BUT avoiding merge issues for now
public class PlayerShoot : MonoBehaviour
{
    // scaffolding to represent that maybe different ammos could have different fire rates
    public float FIRE_RATE;

    public Transform  creatureSpawnTransform;
    public GameObject creaturePrefab, worldObject;

    // no fixedupdate, uses time.deltatime
    private void Update()
    {
        if (GameManager.Instance.GunCooldown > 0)
        {
            GameManager.Instance.GunCooldown -= Time.deltaTime / FIRE_RATE;
        }


        // tbd use input manager
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.GunCooldown <= 0)
        {
            GameManager.Instance.GunCooldown = GameManager.GUN_COOLDOWN;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject creature = Instantiate(creaturePrefab, creatureSpawnTransform.position, new Quaternion(0, 180, 180, 0), worldObject.transform);
    }
}