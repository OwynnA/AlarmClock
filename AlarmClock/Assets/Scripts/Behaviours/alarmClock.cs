using UnityEngine;
using System;
using System.Collections;
using TMPro;
using UnityEngine.Events;

public class alarmClock : MonoBehaviour
{
    public TMP_Text hourText, minuteText;
    public GameObject hourAlarm, minuteAlarm;
    private int hours = 0;
    private int minutes = 0;
    private int seconds = 0;

    public UnityEvent alarm;
    private int hourTime, minuteTime, waitTime;

    void Awake()
    {
        hours = DateTime.Now.Hour;
        minutes = DateTime.Now.Minute;
        seconds = DateTime.Now.Second;

        hourText.text = hours.ToString();
        minuteText.text = minutes.ToString();
        waitTime = 60 - seconds;
        StartCoroutine(CheckMinute());

    }
    public IEnumerator CheckMinute()
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Checking for alarm");
        hours = DateTime.Now.Hour;
        minutes = DateTime.Now.Minute;
        hourText.text = hours.ToString();
        minuteText.text = minutes.ToString();
        
        if (hourTime == hours && minuteTime == minutes)
        {
            Debug.Log("ALRAM NOISE");
            alarm.Invoke();
        }
        waitTime = 60;
    }

    public void SetAlarm()
    {
        hourTime = int.Parse(hourAlarm.GetComponent<TMP_InputField>().text);
        minuteTime = int.Parse(minuteAlarm.GetComponent<TMP_InputField>().text);
        Debug.Log("Alarm is set for " + hourTime + " : " + minuteTime);
    }
}
