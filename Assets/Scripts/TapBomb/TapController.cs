using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    private Vector3 touchPosition;
    private Vector2 _screenPos;
    private Vector3 _worldPos;

    private TapBombGM _tapBombGM;
    private Pump _pump;
    private int tapCount = 0;
    public UI_TapCount _uiTapCount;
    public UI_TapDenotate _uiTapDenotate;
    private int tapType;

    float accelerometerUpdateInterval = 1.0f / 60.0f;
    // The greater the value of LowPassKernelWidthInSeconds, the slower the
    // filtered value will converge towards current input sample (and vice versa).
    float lowPassKernelWidthInSeconds = 0.5f;
    // This next parameter is initialized to 2.0 per Apple's recommendation,
    // or at least according to Brady! ;)
    float shakeDetectionThreshold = 2.0f;
    private float lastShakeTime = 0.0f;
    public float minimumRefractoryPeriod = 0.1f;
    float lowPassFilterFactor;
    Vector3 lowPassValue;
    void Start()
    {
        _tapBombGM = FindObjectOfType<TapBombGM>();
        _pump = FindObjectOfType<Pump>();
        tapCount = _tapBombGM.bombTime * 4;
        _uiTapCount.UpdateTapCount(tapCount);
        tapType = _tapBombGM.bombType;
        switch(tapType){
            case 0:
                _uiTapDenotate.UpdateDescription("Tap");
                break;
            case 1:
                _uiTapDenotate.UpdateDescription("Shake");
                break;
        }


        //accelerometer setup
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
        
    }

    //detect tap on pump
    void Update(){
        if(tapType == 0){//tap
            if (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
            _screenPos = Input.GetTouch(0).position;
            _worldPos = Camera.main.ScreenToWorldPoint(_screenPos);
            _worldPos.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(_worldPos, Vector2.zero);
            if(hit.collider != null && hit.collider.gameObject == _pump.gameObject){
                //hit on pump
                tapCount--;

                CheckWin(tapCount);
                }
            }
        }
        
        else if (tapType == 1){//shake
            Vector3 acceleration = Input.acceleration;
            lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
            Vector3 deltaAcceleration = acceleration - lowPassValue;
            
            if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
            {
                // Perform your "shaking actions" here. If necessary, add suitable
                // guards in the if check above to avoid redundant handling during
                // the same shake (e.g. a minimum refractory period).
                if (Time.time - lastShakeTime >= minimumRefractoryPeriod)
                {
                    // Your shaking actions here
                    // Debug.Log("Shake event detected at time " + Time.time);
                    lastShakeTime = Time.time;
                    //hit on pump
                    tapCount--;
                    CheckWin(tapCount);
                }
            }
        }

        else if (tapType == 2){//scream
            // Debug.Log("scream");        
        }
    }
    

    private void CheckWin(int tapCount){
        _uiTapCount.UpdateTapCount(tapCount);
        _pump.UpdatePumpHandlePosition();
        if(tapCount == 0){
            _tapBombGM.Win();
        }
    }



}