using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimeSurvived : MonoBehaviour
{
    private TMP_Text killCountText;

    // Start is called before the first frame update
    void Start()
    {
        killCountText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        killCountText.text = "Time Survived: " + GameManager.Instance.SurvivalTime.ToString();
    }
}
