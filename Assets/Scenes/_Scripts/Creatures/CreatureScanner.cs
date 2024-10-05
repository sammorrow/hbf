using UnityEngine;
using System.Collections;

public class CreatureScanner : CreatureBase
{

    void Start()
    {
       // set up trigger zone around creature
    }

    private void OnTriggerEnter(Collider other)
    {
        Alarm();
	}

    void Alarm()
    {
        // sound alarm;
    }

    public override void CreateAggroZone()
    {

    }
}

