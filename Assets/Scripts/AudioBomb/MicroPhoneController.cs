using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroPhoneController : MonoBehaviour

{
    public int sampleWindow = 64;
    private AudioClip micropPhoneClip;
    // Start is called before the first frame update
    void Start()
    {
        MicrophoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MicrophoneToAudioClip(){

        string microphoneName = Microphone.devices[0];
        Debug.Log("Microphone Name: " + microphoneName);
        micropPhoneClip = Microphone.Start(microphoneName, true, 10, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone(){
       return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), micropPhoneClip);
    }
    public float GetLoudnessFromAudioClip(int clipPos, AudioClip clip){

        int startPosition = clipPos - sampleWindow;
        if(startPosition < 0)
            return 0;
        float[] samples = new float[sampleWindow];
        clip.GetData(samples, startPosition);
        float Loudness = 0;
        for (int i = 0; i < samples.Length; i++)
        {
            Loudness += Mathf.Abs(samples[i]);
        }
        return Loudness / sampleWindow;
    }
}
