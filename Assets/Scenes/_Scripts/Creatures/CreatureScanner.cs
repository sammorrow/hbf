using UnityEngine;
using System.Collections;

public class CreatureScanner : CreatureBase
{

    GameObject _aggroPrefab;

    void Start()
    {
        Lifespan = 8;
    }


    private void OnTriggerEnter(Collider other)
    {
        Alarm();
	}

    void Alarm()
    {
        Debug.Log("ALARM ALARM!");
        // sound alarm;
    }

    public override void CreateAggroZone()
    {
        Instantiate(_aggroPrefab, gameObject.transform);
    }
}

