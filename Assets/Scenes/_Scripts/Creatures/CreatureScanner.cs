using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;
using Random = UnityEngine.Random;

public class CreatureScanner : CreatureBase
{

    public float scanRange = 1000;
    public float ALARM_CYCLE = 1;
    public LayerMask enemyLayer;
    private Collider[] _detectedEnemies = Array.Empty<Collider>();

    [SerializeField] private Animator _animator;
    private Tween tween;

    void Start()
    {
        tween = transform.DORotate(new Vector3(-90, 0f, -180 + Random.Range(-25, 25)), 3).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        Lifespan = 60;
    }

    new void Update()
    {
        DetectEnemies();
        base.Update();
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

    void OnDestroy()
    {
        tween.Kill(true);
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

