using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // TBD Centralize this
    private const float MAX_HEALTH = 9000f;

    public float Health = MAX_HEALTH;


    public Image CurrentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth.fillAmount = Health / MAX_HEALTH;    
    }
}
