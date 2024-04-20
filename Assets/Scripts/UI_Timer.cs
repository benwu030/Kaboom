using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{

    public static event System.Action TimerEnded = delegate { };
    public int totalTime ; // The total time for the timer
    public int currentTime; // Current time left
    public TextMeshProUGUI timerText; // Reference to the UI text element to display timer

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        currentTime = totalTime; // Set the current time to the total time
        UpdateTimerDisplay();
        // Start the timer countdown
        InvokeRepeating("Countdown", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void forceUpdateTimer(int updateTime)
    {
        currentTime += updateTime;
        if (currentTime > 0)
        UpdateTimerDisplay();
        else {
            currentTime = 0;
            UpdateTimerDisplay();
            TimerEnded();
            CancelInvoke("Countdown");
        }
    }
    void Countdown()
    {


        if (currentTime <= 0)
        {
            TimerEnded();
            CancelInvoke("Countdown");
            return;
        }
                
        currentTime -= 1;
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }



}
