using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeBar : MonoBehaviour
{

    private Slider slider;
    public float increaseSpeed = 0.5f;
    public int volumeSense = 500;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
    

    }


    //update the VolumeBar
    public float UpdateVolume(float volume)
    {
        // Debug.Log(volume);
        slider.value += volume/volumeSense;
        return slider.value;
    }
}
