using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float health;
    private float splitHealthThreshold = 10000; // amount of health enemy needs to be able to split and reproduce
    private float damageHealthThreshold; // min amount of health enemy needs to be able to start attacking body
    private float deadTime = 30; // how long the enemy will remain dead/removable for
    private float deadTimer;

    [SerializeField] GameObject selfPrefab; // used when enemy splits/duplicates

    void SetHealth(float newHealthValue)
    {
        health = newHealthValue;
    }

    void Split()
    {
        Vector3 randomLocation = new Vector3(0,0,0); // TODO: set this to a random position inside the body's bounds
        Quaternion randomRotation = Quaternion.identity; // TODO: set this to be a random rotation (only 1 axis needs to be set probably)
        Instantiate(selfPrefab, randomLocation, randomRotation); // TODO: split the enemy (create new copy) and set its health = damageHealthThreshold
        SetHealth(damageHealthThreshold);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            // TODO: if not dead (health > 0), increase health every few game ticks
        }
        if (health > damageHealthThreshold)
        {
            // TODO: if (health > damageHealthThreshold), deal damage to body (player) every few game ticks
        }
        if (health <= 0)
        {
            if (deadTime < deadTimer)
                deadTimer += Time.deltaTime; // if dead AND deadTime < deadTimer, increment deadTimer
            else
            {
                health = 1;
                deadTimer = 0;
            }
        }
            

        // TODO: if dead AND deadTime >= deadTimer, set health to 1
        if (health >= splitHealthThreshold)
            Split();
    }
}
