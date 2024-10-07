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
        Lifespan = 60;
        if (IsEnemyDetected())
            _enemyAround = true;
            StartCoroutine(Alarm());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsEnemyDetected())
            StartCoroutine(Alarm());
    }

    new private void Update()
    {
        if (!IsEnemyDetected())
            _enemyAround = false;

        base.Update();
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

