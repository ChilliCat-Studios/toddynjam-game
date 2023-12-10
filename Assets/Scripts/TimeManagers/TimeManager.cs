using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute {  get; private set; }
    public static int Hour {  get; private set; }

    private float MinuteToRealTime = 0.5f; //ratio is 1:1 , so when I declare 0.5f its Half a second
    private float Timer;

    void Start()
    {
        Minute = 0;
        Hour = 0; 
        Timer = MinuteToRealTime;
    }

    
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Minute++;
            //Debug.Log(Minute);
            OnMinuteChanged? .Invoke();

            if(Minute >= 60)
            {
                Hour++;
                //Debug.Log(Hour);
                Minute = 0;
                OnHourChanged? .Invoke();
            }

            Timer = MinuteToRealTime;
        }
    }
}
