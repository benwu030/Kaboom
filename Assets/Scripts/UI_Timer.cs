using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{

    public int totalTime ; // The total time for the timer
    public int currentTime; // Current time left
    public TextMeshProUGUI timerText; // Reference to the UI text element to display timer
    public TimeBar timeBar; // Reference to the time bar
    // Start is called before the first frame update
    public BombGM bombGM;

    void Start()
    {
        // timerText = GetComponent<TextMeshProUGUI>();
        // currentTime = totalTime; // Set the current time to the total time
        // timeBar.totalTime = totalTime;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void forceUpdateTimer(int updateTime)
    {
        currentTime += updateTime;
        TimerUpdated(currentTime);
        if (currentTime > 0)
        UpdateTimerDisplay();
        else {
            currentTime = 0;
            
            UpdateTimerDisplay();
            
        }
    }
    public IEnumerator Countdown()
    {
        GameManager.instance.TimerTickingAudio.Play();

        while (currentTime >= 0)
        {
           
        yield return new WaitForSeconds(1);
        if (currentTime == 0)
        {
            TimerEnded();
            break;
        }
        else{
            currentTime -= 1;
            TimerUpdated(currentTime);  
            UpdateTimerDisplay();
        }
        // Debug.Log("Countdown passed");

        }
    }


    private void TimerEnded()
    {   
        // Debug.Log(currentTime);
        // Handle timer end
        GameManager.instance.TimerTickingAudio.Stop();

        bombGM.ExplodeBomb("KeyPadBombImage");
        
    }
    void TimerUpdated(int time)
    {
        // Handle timer update
        if(bombGM.gameObject.name == "CutBombGM"){
            bombGM.GetComponent<CutBombGM>().HandleTimerUpdate();
        }
            
    }
    public void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeBar.UpdateTimeBar(totalTime-currentTime);
        //update TimeBar
    }



}
