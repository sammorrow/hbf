using UnityEngine;
using System.Collections;

public class CreatureFighter : CreatureBase
{


    void Start()
    {
        // set up trigger zone around creature
    }

    private void OnTriggerEnter(Collider other)
    {
        // determine highest priority enemy, then
        Attack();
    }

    void Attack()
    {
        // combat logic
    }

    public override void CreateAggroZone(){
    }
}

