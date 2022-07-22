using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StaminaGifter : MonoBehaviour
{
    public TextMeshProUGUI DistrTimeText;
    public TextMeshProUGUI ServerTimeText;
    public TextMeshProUGUI CurrTimeText;
    string serTimeText = "Server Time: ";
    string currTimeText = "Your Time: ";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime();
    }

    void DisplayTime()
    {
        DistrTimeText.text = "12:00-14:00 / 18:00-20:00";
        ServerTimeText.text = serTimeText + DateTime.UtcNow.AddHours(-7).ToShortTimeString();
        CurrTimeText.text = currTimeText + DateTime.Now.ToShortTimeString();
    }
}
