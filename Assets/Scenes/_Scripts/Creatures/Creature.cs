using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test class
public class Creature : MonoBehaviour
{
    public float damage;
    public float LIFE_SPAN = 3;

    private void Update()
    {
        LIFE_SPAN -= Time.deltaTime;

        if (LIFE_SPAN < 0)
            Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // TBD
        Destroy(gameObject);
    }
}