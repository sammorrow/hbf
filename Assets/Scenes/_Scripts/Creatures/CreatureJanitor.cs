﻿using UnityEngine;
using System.Collections;

public class CreatureJanitor : CreatureBase
{

    [SerializeField] private Animator _animator;

    public float ATTACK_RANGE = 175;
    // this is tied (but not coupled) to animation length; don't change one without the other
    private float BOMB_FUSE = 2f;
    public LayerMask enemyLayer;

    public AudioSource explosionSound;

    void Start()
    {
        StartCoroutine(Boom());
    }


    IEnumerator Boom()
    {
        yield return new WaitForSeconds(BOMB_FUSE);

        Collider[] targets = Physics.OverlapSphere(transform.position, ATTACK_RANGE, enemyLayer);
        foreach (Collider virus in targets)
        {
            if (virus.gameObject.GetComponent<EnemyBehavior>().GetHealth() <= 0)
            {
                Destroy(virus.gameObject);
                GameManager.Instance.KillCount++;
            }
        }
        explosionSound.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }

}
