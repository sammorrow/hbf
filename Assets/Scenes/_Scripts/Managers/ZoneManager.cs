using System;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

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
}

