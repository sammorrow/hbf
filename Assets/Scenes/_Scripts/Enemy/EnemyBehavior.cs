using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public bool justSplit = false;
    private float health;
    private float splitHealthThreshold = 100; // amount of health enemy needs to be able to split and reproduce
    private float damageHealthThreshold = 25; // min amount of health enemy needs to be able to start attacking body
    private float deadTime = 30; // how long the enemy will remain dead/removable for
    private float deadTimer;
    public float ATTACK_RATE = .2f;
    public float DAMAGE_VALUE = 1;
    public float REGENERATION = .5f;
    private float attackCooldown;

    [SerializeField] GameObject selfPrefab; // used when enemy splits/duplicates

    void SetHealth(float newHealthValue)
    {
        health = newHealthValue;
    }

    void Split()
    {
        Vector3 randomVelocity = new Vector3(0,0,0); // TODO: set the newly created copy to have this velocity
        Quaternion randomRotation = Quaternion.identity; // TODO: set this to be a random rotation (only 1 axis needs to be set probably)
        GameObject newEnemy = Instantiate(selfPrefab); // TODO: split the enemy (create new copy) and set its health = damageHealthThreshold
        newEnemy.GetComponent<EnemyBehavior>().justSplit = true;
        SetHealth(damageHealthThreshold);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (justSplit)
        {
            health = damageHealthThreshold;
            justSplit = false;
        }

        if (health > 0)
        {
            // if not dead (health > 0), increase health every few game ticks, then change size
            health += REGENERATION * Time.deltaTime;
            float enemySize = 2 * health / splitHealthThreshold;
            transform.localScale = new Vector3(enemySize, enemySize, 1);
        }
        if (health > damageHealthThreshold)
        {
            // if (health > damageHealthThreshold), deal damage to body (player) every damage interval
            if (attackCooldown <= 0)
            {
                Player.Instance.DamagePlayer(DAMAGE_VALUE); // TODO: multiply damage by zone bonus
                attackCooldown = ATTACK_RATE;
            }

            attackCooldown -= Time.deltaTime * ATTACK_RATE;
        }
        if (health <= 0)
        {
            if (deadTime < deadTimer)
                deadTimer += Time.deltaTime; // if dead AND deadTime < deadTimer, increment deadTimer
            else
            {
                health = 1;
                deadTimer = 0;
                // if dead AND deadTime >= deadTimer, set health to 1 (resurrect)
            }
        }
            
        if (health >= splitHealthThreshold)
            Split();
    }
}
