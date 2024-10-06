using UnityEngine;
using System.Collections;

public class CreatureJanitor : CreatureBase
{

    void Start()
    {
        // set up trigger zone around creature
    }

    private void OnTriggerEnter(Collider other)
    {
        // determine priority??? then
        Eat();
    }

    void Eat()
    {
        // if dead enemies in eat zone, clean em up
    }

}

