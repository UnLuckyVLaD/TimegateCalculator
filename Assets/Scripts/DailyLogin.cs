using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DailyLogin : MonoBehaviour
{
    public TextMeshProUGUI TimeLeftText;
    public TextMeshProUGUI ServerTimeText;
    public TextMeshProUGUI RewardText;

    public Image ColorTarget;
    public Color RewardReadyColor;
    public Color RewardReceivedColor;

    string RewardReadyString = "There is a Reward today";
    string RewardReceived = "You received Reward today";
    bool isRewardReceived = false;

    DateTime ServerTime;

    void Update()
    {
        ServerTime = DateTime.UtcNow.AddHours(-7);
        DateTime NextDay = new DateTime(ServerTime.Year, ServerTime.Month, ServerTime.Day + 1);
        TimeLeftText.text = "Time left: " + new DateTime(NextDay.Subtract(ServerTime).Ticks).ToShortTimeString();
        ServerTimeText.text = "Server Time: " + ServerTime.ToShortDateString() + " " + ServerTime.ToShortTimeString();

    }

    void Start()
    {
        if (!isRewardReceived)
        {
            RewardText.text = RewardReadyString;
            ColorTarget.color = RewardReadyColor;
        }
    }

    public void GetReward()
    {
        if (!isRewardReceived)
        {
            isRewardReceived = true;
            RewardText.text = RewardReceived;
            ColorTarget.color = RewardReceivedColor;
        }
        else
        {
            isRewardReceived = false;
            RewardText.text = RewardReadyString;
            ColorTarget.color = RewardReadyColor;
        }
    }
}
