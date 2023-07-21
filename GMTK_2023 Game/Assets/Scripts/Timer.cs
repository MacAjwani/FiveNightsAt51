using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private int maxTime = 480;
    public float timer;
    public bool timeIsRunning = true;
    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            DisplayTime(timer);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = (int) timer / 60;
        int seconds = (int) timer % 60;
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AlterTime(float change)
    {
        timer -= change;
    }
}
