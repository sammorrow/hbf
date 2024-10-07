using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAmmo : MonoBehaviour
{

    public TMP_Text textAmmoCount1;
    public TMP_Text textAmmoCount2;
    public TMP_Text textAmmoCount3;

    private void FixedUpdate()
    {
        UpdateUIAmmo();
    }

    public void UpdateUIAmmo()
    {
        textAmmoCount1.text = Player.Instance.ammo[0].ToString();
        textAmmoCount2.text = Player.Instance.ammo[1].ToString();
        textAmmoCount3.text = Player.Instance.ammo[2].ToString();
    }
}
