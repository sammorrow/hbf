using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float health;
    private float splitHealthThreshold; // amount of health enemy needs to be able to split and reproduce
    private float damageHealthThreshold; // min amount of health enemy needs to be able to start attacking body
    private float deadTime = 30; // how long the enemy will remain dead/removable for
    private float deadTimer;

    private 

    void SetHealth(float newHealthValue)
    {
        health = newHealthValue;
    }

    void Split()
    {
        // TODO: split the enemy (create new copy) and set its health = damageHealthThreshold
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
