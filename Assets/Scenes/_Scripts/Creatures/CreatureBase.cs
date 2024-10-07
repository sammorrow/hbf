using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class. It is born, and it dies.
public abstract class CreatureBase : MonoBehaviour
{

    protected const float BASE_CREATURE_LIFESPAN = 15;

    public float Lifespan = BASE_CREATURE_LIFESPAN;

    protected void Update()
    {
        Lifespan -= Time.deltaTime;

        if (Lifespan < 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // TBD, base collision logic
    }
}