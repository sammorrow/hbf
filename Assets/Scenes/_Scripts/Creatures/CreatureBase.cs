using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class. It is born, and it dies.
public abstract class CreatureBase : MonoBehaviour
{

    private const float BASE_CREATURE_LIFESPAN = 3;

    public float Lifespan = BASE_CREATURE_LIFESPAN;

    private void Update()
    {
        Lifespan -= Time.deltaTime;

        if (Lifespan < 0)
            Destroy(gameObject);
    }

    public abstract void CreateAggroZone();

    private void OnTriggerEnter(Collider other)
    {
        // TBD, base collision logic
    }
}