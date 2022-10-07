using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;
    public bool keepRunning = false;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (keepRunning)
        {
            UpdateTime();
        }
    }

    public void UpdateTime() {
        time += Time.deltaTime;
    }

    public void StopTimer()
    {
        keepRunning = false;
    }
    
    public string GetTime() { 
        return TimeToString(time);
    }

    private void Restart()
    {
        this.time = 0f;
    }

    private string TimeToString(float time) {
        return time.ToString("00:00");
    }

    public void StartTimer()
    {
        Restart();
        keepRunning = true;
    }

    
}
