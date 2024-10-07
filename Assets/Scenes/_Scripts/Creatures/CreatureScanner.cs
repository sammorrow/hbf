using UnityEngine;
using System.Collections;

public class CreatureScanner : CreatureBase
{

    public float scanRange = 10;
    public float ALARM_CYCLE = 1;
    public LayerMask enemyLayer;
    private bool _enemyAround = false;

    void Start()
    {
        Lifespan = 8;
        if (IsEnemyDetected())
            _enemyAround = true;
            StartCoroutine(Alarm());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsEnemyDetected())
            StartCoroutine(Alarm());
    }

    void Update()
    {
        if (!IsEnemyDetected())
            _enemyAround = false;
    }

    public bool IsEnemyDetected()
    {
        return Physics.CheckSphere(transform.position, scanRange, enemyLayer);
    }

    IEnumerator Alarm()
    {
        while (_enemyAround)
        {
            Debug.Log("ALARM!!");
            yield return new WaitForSeconds(ALARM_CYCLE);
        }
    }

}

