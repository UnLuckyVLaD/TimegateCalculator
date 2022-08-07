using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Notifications.Android;
using System;
using System.Collections.Generic;

public class PushNotificator : MonoBehaviour
{
    #region Variables
    #region MaxStamina
    public CalculatorScript Calculator;
    // MaxStamina
    public Toggle isMaxStamina;
    public TextMeshProUGUI AlertTimeText;
    #endregion

    #region StaminaSupply
    // Stamina Supply
    public StaminaGifter StaminaGifter;
    // Stamina Supply ready
    public Toggle isStaminaSupply;
    #endregion

    #region DailyLogin
    // Daily Login Rewards
    public Toggle isDailyLogin;
    #endregion
    public double DebugDelayAlert = 0;
    #endregion

    private enum Channels
    { 
        Main = 0,
        MaxStamina = 1,
        DailyLogin = 2,
        StaminaSupply = 3
    }

    private void Awake()
    {
        AndroidNotificationChannel MainChannel = new AndroidNotificationChannel()
        {
            Id = Channels.Main.ToString(),
            Name = "Alerts",
            Description = "Main channel",
            Importance = Importance.Default
        };
        AndroidNotificationCenter.RegisterNotificationChannel(MainChannel);
    }


    #region MaxStaminaAlert
    /// <summary>
    /// Send Notification about full Stamina, from textfield with [5] minutes reserve
    /// </summary>
    public void SendMaxStaminaAlert()
    {
            AndroidNotification MaxStaminaAlert = new AndroidNotification()
            {
                Title = "FULL STAMINA",
                Text = "Your stamina is full, time to play!",
                Style = NotificationStyle.BigTextStyle,
                FireTime = Convert.ToDateTime(AlertTimeText.text).AddMinutes(-5)
            };
            AndroidNotificationCenter.SendNotification(MaxStaminaAlert, Channels.Main.ToString());
    }

    /// <summary>
    /// Send Notification about full Stamina
    /// </summary>
    /// <param name="AlertTimeString">textfield with datetime when its full</param>
    /// <param name="ReserveMin">reserved time, notify before stamina is really full</param>
    public void SendMaxStaminaAlert(string AlertTimeString, double ReserveMin)
    {
            AndroidNotification MaxStaminaAlert = new AndroidNotification()
            {
                Title = "FULL STAMINA",
                Text = "Your stamina is full, time to play!",
                Style = NotificationStyle.BigTextStyle,
                FireTime = Convert.ToDateTime(AlertTimeString).AddMinutes(-ReserveMin)
            };
            AndroidNotificationCenter.SendNotification(MaxStaminaAlert, Channels.Main.ToString());
    }

    public void SendMaxStaminaAlert(DateTime AlertTime, double ReserveMin)
    {
        AndroidNotification MaxStaminaAlert = new AndroidNotification()
        {
            Title = "FULL STAMINA",
            Text = "Your stamina is full, time to play!",
            Style = NotificationStyle.BigTextStyle,
            FireTime = AlertTime.AddMinutes(-ReserveMin)
        };
        AndroidNotificationCenter.SendNotification(MaxStaminaAlert, Channels.Main.ToString());
    }
    #endregion

    /// <summary>
    /// send notification for debug
    /// </summary>
    public void SendDebugAlert()
    {
        DateTime AlertTime = DateTime.Now.AddSeconds(-DebugDelayAlert);
        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Debug Alert",
            Text = "It is a debug alert (notification) with "+DebugDelayAlert.ToString()+" sec delay",
            Style = NotificationStyle.BigTextStyle
        };
        notification.FireTime = AlertTime;
        AndroidNotificationCenter.SendNotification(notification, Channels.Main.ToString());
    }

    public void ToggleChanged(Toggle Toggle, AndroidNotification Notification, string ChannelId)
    {
        // reEdit this later, this will not work
        int id = 0;
        if (Toggle.isOn)
        {
           id = AndroidNotificationCenter.SendNotification(Notification, ChannelId);
        }
        else
        {
            AndroidNotificationCenter.CancelNotification(id);
        }
    }

}
