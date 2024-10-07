using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public float spawnChance = .5f;
    public float damageMultiplier = 1f;

    public Material _alarmMaterial;
    public Material _defaultMaterial;

    private const float ALARM_CYCLE = 0.5f; 

    private bool _isAlarmed;

    void Start()
    {
        _defaultMaterial = gameObject.GetComponent<MeshRenderer>().materials[0];
        _alarmMaterial = ZoneManager.Instance.AlarmMaterial;
    }

    public void SoundAlarm()
    {
        if (_isAlarmed) return;
        _isAlarmed = true;
        StartCoroutine(Alarm());
    }

    IEnumerator Alarm()
    {
        gameObject.GetComponent<MeshRenderer>().SetMaterials(new List<Material> { _alarmMaterial });
        Debug.Log("applied material", _alarmMaterial);
        yield return new WaitForSeconds(ALARM_CYCLE);
        Debug.Log("removed material", _alarmMaterial);
        gameObject.GetComponent<MeshRenderer>().SetMaterials(new List<Material> { _defaultMaterial });
        yield return new WaitForSeconds(ALARM_CYCLE);
        _isAlarmed = false;
    }

}
