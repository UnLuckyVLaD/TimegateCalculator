using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI DisplayTimeText;
    /// <summary>
    /// [debug] change access later
    /// </summary>
    public float timerTime = 0;
    public bool Enabled = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Enabled & timerTime > 0)
        {
            EnableTimer();
            timerTime -= 1;
        }
        else EnableTimer();
        DisplayTime(timerTime);
    }

    public void EnableTimer()
    {
        if (timerTime <= 0)
        {
            Enabled = false;
            timerTime = 0;
        }
        else Enabled = true;
    }

    /// <summary>
    /// Set time for Timer and converts to miliseconds
    /// </summary>
    /// <param name="time">time in seconds (usually)</param>
    public void SetTimerTime(float time)
    {
        //miliseconds
        timerTime = time * 1000;
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
            timeToDisplay = 0;
        else if (timeToDisplay > 0)
            timeToDisplay += 1;
        DateTime time = new DateTime();
        time = time.AddMilliseconds(timeToDisplay);
        DisplayTimeText.text = time.ToLongTimeString();
    }
}
