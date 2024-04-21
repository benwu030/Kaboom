using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMicroPhoneUI : MonoBehaviour
{
    // Start is called before the first frame update

    public MicroPhoneController microPhoneController;
    public Vector3 loudnessBarMaxScale;
    public Vector3 loudnessBarMinScale;
    public Transform[] loudnessBar_components; //0: Microphone 1: main 2:Right 3:Left

    public float loudnessSense = 100;
    public float threshold = 0.2f;
    public VolumeBar _volumeBar;

    private AudioBombGM _audioBombGM;
    void Start()
    {
        loudnessBar_components = GetComponentsInChildren<Transform>();
        _audioBombGM = FindObjectOfType<AudioBombGM>();
        //log all the components and the index

    }

    // Update is called once per frame
    void Update()
    {
        float Loudness = microPhoneController.GetLoudnessFromMicrophone()*loudnessSense;
        if(Loudness < threshold)
        {
            Loudness = 0;
        }
        UpdateLoudnessBar(Loudness);
        if(_volumeBar.UpdateVolume(Loudness) >=1)
        {
            // Bomb Defused
            _audioBombGM.DefuseBomb();
        }
    }

    void UpdateLoudnessBar(float Loudness)
    {

        loudnessBar_components[2].localScale = Vector3.Lerp(loudnessBarMinScale, loudnessBarMaxScale, Loudness);
        loudnessBar_components[3].localScale = Vector3.Lerp(loudnessBarMinScale, loudnessBarMaxScale, Loudness);

        
    }
}
