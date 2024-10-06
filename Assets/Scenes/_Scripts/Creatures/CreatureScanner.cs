using UnityEngine;
using System.Collections;

public class CreatureScanner : CreatureBase
{

    GameObject _aggroPrefab;
    [SerializeField] private Animator _animator;

    void Start()
    {
        Lifespan = 8;
    }

    private void FixedUpdate()
    {
        CheckAnimState();
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

    private void CheckAnimState()
    {
        if (Input.GetMouseButton(0))
        {
            _animator.SetInteger("AnimState", 1);
        }
        else
        {
            _animator.SetInteger("AnimState", 0);
        }
    }
}

