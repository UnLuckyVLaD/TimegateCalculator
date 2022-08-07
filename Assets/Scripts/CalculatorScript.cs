using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class CalculatorScript : MonoBehaviour
{
    // text with last time when chanched variables
    public TextMeshProUGUI DebugCalcTimeText;
    public TMP_InputField MaxStaminaInput;
    public TMP_InputField StaminaTimeInput;
    public TMP_InputField CurrentStaminaInput;
    // display currentStamina / maxStamina
    public TextMeshProUGUI StaminaText;
    // display for notification time
    public TextMeshProUGUI AlertTimeText;
    // hidden display for needed time
    public TextMeshProUGUI DebugNeedTimeText;
    // Timer
    public Timer Timer;
    // Dialog window with user data
    public GameObject DialogRect;

    // maxStamina >= 1
    int maxStamina = 1;
    // staminatime >= 1
    int staminaTime = 1;
    // not null
    int currentStamina = 0;
    // время нажатия расчета стамины
    public DateTime CalcTime;
    public DateTime AlertTime;


    /// <summary>
    /// get replenish time for stamina
    /// </summary>
    public void CalculateTime()
    {
        if (MaxStaminaInput.text != "")
            maxStamina = Convert.ToInt32(MaxStaminaInput.text);
        if (StaminaTimeInput.text != "")
            staminaTime = Convert.ToInt32(StaminaTimeInput.text) * 60;
        if (CurrentStaminaInput.text != "")
            currentStamina = Convert.ToInt32(CurrentStaminaInput.text);
        if (currentStamina < maxStamina)
        {
            int time = staminaTime * (maxStamina - currentStamina);
            // display
            GetCalcTime();
            DebugNeedTimeText.text = new DateTime().AddSeconds(time).ToLongTimeString();
            AlertTime = DateTime.Now.AddSeconds(time);
            AlertTimeText.text = AlertTime.ToString();
            // timer
            Timer.SetTimerTime(time);
            Timer.EnableTimer();
            // end
            DialogRect.SetActive(false);
        }
        else
        {
            CurrentStaminaInput.text = "";
            CurrentStaminaInput.Select();
        }
    }

    /// <summary>
    /// get time when all calculated
    /// </summary>
    public void GetCalcTime()
    {
        CalcTime = DateTime.Now;
        DebugCalcTimeText.text = CalcTime.ToString();
    }


    /// <summary>
    /// display Stamina/MaxStamina and Replenish Time
    /// </summary>
    public void DisplayStamina()
    {
        if (MaxStaminaInput.text != "" & StaminaTimeInput.text != "" & CurrentStaminaInput.text != "" & (DebugNeedTimeText.text != "" || DebugNeedTimeText.text == "00:00:00"))
        {
            CalcTime = Convert.ToDateTime(DebugCalcTimeText.text);
            DateTime CurrentTime = DateTime.Now;
            int calctime, currenttime, time;
            calctime = CalcTime.Hour * 3600 + CalcTime.Minute * 60 + CalcTime.Second;
            currenttime = CurrentTime.Hour * 3600 + CurrentTime.Minute * 60 + CurrentTime.Second;
            time = currenttime - calctime;
            int stamina = currentStamina + (time / staminaTime);
            StaminaText.text = stamina.ToString() + " / " + maxStamina.ToString();
        }
    }

    void Update()
    {
        DisplayStamina();
    }
}
