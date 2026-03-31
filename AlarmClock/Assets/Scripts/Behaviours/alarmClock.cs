using UnityEngine;
using System;
using TMPro;

public class alarmClock : MonoBehaviour
{
    public TMP_Text hourText, minuteText, secondText;
    public GameObject hourAlarm, minuteAlarm, secondAlarm;
    private int hours = 0;
    private int minutes = 0;
    private int seconds = 0;
    
    private int hourTime, minuteTime, secondTime;
    void Update()
    {
        hours = DateTime.Now.Hour;
        minutes = DateTime.Now.Minute;
        seconds = DateTime.Now.Second;

        hourText.text = hours.ToString();
        minuteText.text = minutes.ToString();
        secondText.text = seconds.ToString();

        hourTime = int.Parse(hourAlarm.GetComponent<TMP_InputField>().text);
        minuteTime = int.Parse(minuteAlarm.GetComponent<TMP_InputField>().text);
        secondTime = int.Parse(secondAlarm.GetComponent<TMP_InputField>().text);
        if (hourTime == hours && minuteTime == minutes && secondTime == seconds)
        {
            Debug.Log("ALRAM NOISE");
        }
    }
}
