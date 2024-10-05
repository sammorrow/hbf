using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot1Behavior : MonoBehaviour
{
    private float lifeTime = 60; // one minute lifetime
    private float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
            Destroy(this.gameObject);
    }
}
