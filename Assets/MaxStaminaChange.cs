using UnityEngine;
using TMPro;
using System;

public class MaxStaminaChange : MonoBehaviour
{
    //text with last time when chanched variables
    public TextMeshProUGUI DebugCalcTimeText;
    public TMP_InputField MaxStaminaInput;
    public TMP_InputField StaminaTimeInput;
    public TMP_InputField CurrentStaminaInput;
    public TMP_InputField ReserveHoursInput;
    public TMP_InputField ReserveMinutesInput;
    public TMP_InputField ReserveSecondsInput;
    //display currentStamina / maxStamina
    public TextMeshProUGUI StaminaText;
    //debug display for needed time
    public TextMeshProUGUI DebugNeedTimeText;
    //display for notification time
    public TextMeshProUGUI AlertTimeText;

    int maxStamina = 1;
    int staminaTime = 1;
    int currentStamina = 0;
    //время нажатия расчета стамины
    DateTime CalcTime;


    public void CalculateTime()
    {
        if (MaxStaminaInput.text != "")
            maxStamina = Convert.ToInt32(MaxStaminaInput.text);
        if (StaminaTimeInput.text != "")
            staminaTime = Convert.ToInt32(StaminaTimeInput.text) * 60;
        if (CurrentStaminaInput.text != "")
            currentStamina = Convert.ToInt32(CurrentStaminaInput.text);
        int rt, rh = 0, rm = 0, rs = 0;
        if (ReserveHoursInput.text != "")
            rh = Convert.ToInt32(ReserveHoursInput.text);
        if (ReserveMinutesInput.text != "")
            rm = Convert.ToInt32(ReserveMinutesInput.text);
        if (ReserveSecondsInput.text != "")
            rs = Convert.ToInt32(ReserveSecondsInput.text);
        rt = rh * 3600 + rm * 60 + rs;
        DateTime maxTime = new DateTime();
        maxTime = maxTime.AddSeconds(staminaTime * (maxStamina - currentStamina));
        try
        {
            maxTime = maxTime.AddSeconds(-rt);
            if (maxTime.Hour * 3600 + maxTime.Minute * 60 + maxTime.Second == 0)
                throw new Exception("");
        }
        catch (Exception)
        {
            Debug.LogError("Time reserve > Needed time \r\nTry to change Reserve Time again");
        }
        //display
        SetCalcTime();
        DebugNeedTimeText.text = maxTime.ToLongTimeString();
        int time = maxTime.Hour * 3600 + maxTime.Minute * 60 + maxTime.Second;
        DateTime AlertTime = DateTime.Now;
        AlertTime = AlertTime.AddSeconds(time);
        AlertTimeText.text = AlertTime.ToString();
    }

    public void SetCalcTime()
    {
        CalcTime = DateTime.Now;
        DebugCalcTimeText.text = CalcTime.ToString();
    }

    public void DisplayStamina()
    {
        if (MaxStaminaInput.text != "" & StaminaTimeInput.text != "" & CurrentStaminaInput.text != "" & (DebugNeedTimeText.text != "" || DebugNeedTimeText.text == "00:00:00"))
        {
            CalcTime = Convert.ToDateTime(DebugCalcTimeText.text);
            DateTime CurrentTime = DateTime.Now;
            int stamina = currentStamina;
            int calctime, currenttime, time;
            calctime = CalcTime.Hour * 3600 + CalcTime.Minute * 60 + CalcTime.Second;
            currenttime = CurrentTime.Hour * 3600 + CurrentTime.Minute * 60 + CurrentTime.Second;
            time = currenttime - calctime;
            stamina = currentStamina + (time / staminaTime);
            StaminaText.text = stamina.ToString() + "/" + maxStamina.ToString();
        }
    }

    private void Update()
    {
        DisplayStamina();
    }
}
