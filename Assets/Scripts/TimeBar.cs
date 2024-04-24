using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public GameObject timbeBarBombImage;
    public GameObject fill;
    public GameManager gm;

    public int totalTime;
    void Start()
    {
        gm = GameManager.instance;
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void UpdateBombImagePos(){
    }

     //update the TimeBar
    public float UpdateTimeBar(float TimePassed)
    {
        // Debug.Log(volume);
        slider.value = TimePassed/totalTime;

        // float temp = TimePassed/totalTime + timbeBarBombImage.transform.localPosition.x;
        // timbeBarBombImage.transform.localPosition = new Vector2(temp, timbeBarBombImage.transform.localPosition.y);
        
        return slider.value;
    }
}
