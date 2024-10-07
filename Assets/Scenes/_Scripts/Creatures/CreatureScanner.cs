using UnityEngine;
using System.Collections;
using System;

public class CreatureScanner : CreatureBase
{

    public float scanRange = 1000;
    public float ALARM_CYCLE = 1;
    public LayerMask enemyLayer;
    private Collider[] _detectedEnemies = Array.Empty<Collider>();

    void Start()
    {
        Lifespan = 60;
    }

    new void Update()
    {
        DetectEnemies();
    }

    public void DetectEnemies()
    {
        Collider[] potentialThreats = Physics.OverlapSphere(transform.position, scanRange, enemyLayer);
        if (potentialThreats.Length > 0 && _detectedEnemies.Length == 0)
        {
            _detectedEnemies = potentialThreats;
            StartCoroutine(Alarm());
        }
        if (_detectedEnemies.Length != potentialThreats.Length)
        {
            _detectedEnemies = potentialThreats;
        }

    }

    IEnumerator Alarm()
    {
        while (_detectedEnemies.Length > 0)
        {
            foreach (Collider enemy in _detectedEnemies)
            {
                var affectedZone = ZoneManager.Instance.GetZoneByPos(enemy.transform.position);
                affectedZone.SoundAlarm();
            }
            yield return new WaitForSeconds(ALARM_CYCLE);
        }
    }

}

