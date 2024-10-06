using UnityEngine;
using System.Collections;

public class CreatureShooter : CreatureBase
{

    [SerializeField] private Animator _animator;

    public float ATTACK_RANGE = 4;
    public float FIRE_RATE = 1;
    public float fireTimer;
    public LayerMask enemyLayer;

    private bool _isFiring = false;

    void Start()
    {
        // set up trigger zone around creature
    }

    private void OnTriggerEnter(Collider other)
    {
        // determine highest priority enemy, then
        Attack();
    }

    private void FixedUpdate()
    {
        RefreshAnimState();
    }

    void Attack()
    {
        fireTimer = FIRE_RATE;
        // TODO: spawn projectile aimed at target (transform)
    }

    private GameObject FindClosestVirus()
    {
        float closestDistance = 100000;
        GameObject closestVirus = null;
        Collider[] targets = Physics.OverlapSphere(transform.position, ATTACK_RANGE, enemyLayer);
        foreach (Collider virus in targets)
        {
            if (virus.gameObject.GetComponent<EnemyBehavior>().GetHealth() <= 0)
                continue;
            else
            {
                float distance = Vector3.Distance(transform.position, virus.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestVirus = virus.gameObject;
                }
            }
        }

        return closestVirus;
    }

    public override void CreateAggroZone(){
    }

    private void Shoot(GameObject targetVirus)
    {
        Debug.Log("Shooting at " + targetVirus);
        // TODO: spawn a projectile prefab that moves towards enemy and can collide
    }

    private void Update()
    {
        GameObject target = FindClosestVirus();
        _isFiring = target;

        fireTimer -= Time.deltaTime;
        if (fireTimer < 0)
        {
            fireTimer = FIRE_RATE;
            if (target)
                Shoot(target);
        }
        
    }

    private void RefreshAnimState()
    {
        if (_isFiring)
        {
            _animator.SetInteger("AnimState", 1);
        }
        else
        {
            _animator.SetInteger("AnimState", 0);
        }
    }

}

