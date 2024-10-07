using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public GameObject targetVirus = null;
    public float SPEED = 1;
    public float DAMAGE = 20;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == targetVirus)
        {
            targetVirus.GetComponent<EnemyBehavior>().DamageVirus(DAMAGE);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetVirus.transform.position, SPEED * Time.deltaTime);
    }
}
