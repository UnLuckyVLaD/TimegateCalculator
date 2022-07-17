using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI DisplayTimerText;
    //for debug, change later
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

    public void SetTimerTime()
    {
        DateTime time = Convert.ToDateTime(TimerText.text);
        //miliseconds
        timerTime = (time.Hour * 3600 + time.Minute * 60 + time.Second) * 1000;
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
            timeToDisplay = 0;
        else if (timeToDisplay > 0)
            timeToDisplay += 1;
        DateTime time = new DateTime();
        time = time.AddMilliseconds(timeToDisplay);
        DisplayTimerText.text = time.ToLongTimeString();
    }
}
