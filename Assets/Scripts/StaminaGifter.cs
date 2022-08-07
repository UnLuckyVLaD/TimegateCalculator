using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StaminaGifter : MonoBehaviour
{
    /// <summary>
    /// display when user can get free stamina
    /// </summary>
    public TextMeshProUGUI DistrTimeText;
    /// <summary>
    /// User's current time
    /// </summary>
    public TextMeshProUGUI CurrTimeText;
    // what to display ? CurrTime || ServerTime
    bool isCurrTime = false;
    DateTime ServerTime;
    string serTimeText = "Server Time: ";
    string currTimeText = "Your Time: ";
    public Image Panel;
    public Color ApprovedColor;
    public Color ReceviedColor;
    public Color StandartColor;
    bool isRecevied = false;
    DateTime LastReceviedTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime();
    }

    /// <summary>
    /// Display Supply Time, Server Time || Current Time and [check] for Supply Time
    /// </summary>
    void DisplayTime()
    {
        DistrTimeText.text = "12:00-14:00\n18:00-20:00";
        ServerTime = DateTime.UtcNow.AddHours(-7);
        if (!isCurrTime)
            CurrTimeText.text = serTimeText + ServerTime.ToString();
        else
            CurrTimeText.text = currTimeText + DateTime.Now.ToString();
        CheckTime();
    }

    /// <summary>
    /// Change CurrTime || Server Time (not really) => from buttonClick
    /// </summary>
    public void ChangeTime()
    {
        isCurrTime = !isCurrTime;
    }

    public void ClaimSupply()
    {
        if (ServerTime.Hour >= 12 & ServerTime.Hour < 14 || ServerTime.Hour > 18 & ServerTime.Hour < 20)
        {
            LastReceviedTime = DateTime.UtcNow.AddHours(-7);
            isRecevied = !isRecevied;
            Panel.color = ReceviedColor;
        }
    }

    /// <summary>
    /// Check if its Time for Supply
    /// </summary>
    public void CheckTime()
    {
        if (ServerTime.Hour >= 12 & ServerTime.Hour < 14 || ServerTime.Hour > 18 & ServerTime.Hour < 20)
        {
            // time for bento
            if (!isRecevied)
            {
                // didn't claimed
                Panel.color = ApprovedColor;
                // here code for notification...
            }
            else if (LastReceviedTime.Hour != ServerTime.Hour)
            {
                // claimed before but time is diff now
                isRecevied = false;
                Panel.color = ApprovedColor;
                // here code for notification...
            }
        }
        else
        {
            // when not time
            Panel.color = StandartColor;
            //Button button = Panel.GetComponentInChildren<Button>();
            //button.interactable = false;
        }
    }
}
