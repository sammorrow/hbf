using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float PROJECTILE_SPEED;
    public float FIRE_RATE;


    [Header("Initial Setup")]
    public Transform bulletSpawnTransform;
    public GameObject creaturePrefab;

    private float timer;

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime / FIRE_RATE;
        }


        if (Input.GetButton("LeftClick") && timer <= 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject creature = Instantiate(creaturePrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);
        creature.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * PROJECTILE_SPEED, ForceMode.Impulse);

        timer = 1;
    }
}