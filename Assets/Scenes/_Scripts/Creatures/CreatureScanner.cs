using UnityEngine;
using System.Collections;

public class CreatureScanner : CreatureBase
{

    public float scanRange = 10;

    public LayerMask enemyLayer;

    void Start()
    {
        Lifespan = 8;
    }

    private void OnTriggerEnter(Collider other)
    {
        Alarm();
    }

    void Update()
    {
        if (Alarm())
            ZoneManager.Instance.OnVirusDetected(gameObject.transform.position);
    }

    public bool Alarm()
    {
        return Physics.CheckSphere(transform.position, scanRange, enemyLayer);
    }


}

