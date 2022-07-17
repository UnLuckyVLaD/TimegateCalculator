using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Notifications.Android;
using System;

public class PushNotificator : MonoBehaviour
{
    public Toggle ToggleNotification;
    public TextMeshProUGUI AlertTimeText;

    private void Awake()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Id = "0",
            Name = "Time Alert",
            Description = "Your stamina is full",
            Importance = Importance.High
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void SendNotification()
    {
        if (ToggleNotification.isOn)
        {
            AndroidNotification notification = new AndroidNotification()
            {
                Title = "FULL STAMINA",
                Text = "Your stamina is full, time to play!",
                Style = NotificationStyle.BigTextStyle,
                FireTime = Convert.ToDateTime(AlertTimeText.text)
            };
            AndroidNotificationCenter.SendNotification(notification, channelId: "0");
        }
    }

}
