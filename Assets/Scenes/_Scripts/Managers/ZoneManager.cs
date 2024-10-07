﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEditor.PlayerSettings;

public class ZoneManager : Singleton<ZoneManager>
{

    public GameObject zonesParent;


    public void OnVirusDetected(Vector3 pos)
    {
       var colliderArr = zonesParent.GetComponentsInChildren<MeshCollider>();
       MeshCollider intrusionZone = null;

        foreach (MeshCollider collider in colliderArr)
        {
            if (collider.bounds.Contains(pos)) {
                intrusionZone = collider;
            }
        }
        if (intrusionZone)
            Debug.Log("Virus detected by unit in zone" + intrusionZone);

    }

    public Zone GetRandomZoneWeighted()
    {
        var zoneArr = zonesParent.GetComponentsInChildren<Zone>();
        Zone selectedZone = null;

        while (selectedZone == null)
        {
            var randomZone = zoneArr[Random.Range(0, zoneArr.Length)];
            if (randomZone.spawnChance * 100 > Random.Range(0, 100))
            {
                selectedZone = randomZone;
            }
        }
        return selectedZone;
    }

    public static Vector3 GetRandomPointInZone(Zone zone)
    {
        MeshCollider collider = zone.gameObject.GetComponent<MeshCollider>();

        Vector3 point = new Vector3();

        point.x = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        point.y = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
        point.z = Random.Range(collider.bounds.min.z, collider.bounds.max.z);

        // check if it's actually in the mesh, somehow

        return point;
    }
}

