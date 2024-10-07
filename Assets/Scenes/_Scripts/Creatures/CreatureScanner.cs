using UnityEngine;
using System.Collections;

public class CreatureScanner : CreatureBase
{

    public float scanRange = 10;

    public LayerMask enemyLayer;

    void Start()
    {
        Lifespan = 60;
    }

    private void OnTriggerEnter(Collider other)
    {
        Alarm();
    }

    new private void Update()
    {
        if (Alarm())
            ZoneManager.Instance.OnVirusDetected(gameObject.transform.position);

        base.Update();
    }

    public bool Alarm()
    {
        return Physics.CheckSphere(transform.position, scanRange, enemyLayer);
    }


}

