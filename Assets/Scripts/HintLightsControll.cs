using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintLightsControll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Lights;
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void UpdateLight(int lightIndex)
    {

        for (int i = 0; i < Lights.Length; i++)
        {
            if (i == lightIndex)
            {
                Lights[i].SetActive(true);

            }
            else
            {
                Lights[i].SetActive(false);
            }
        }
    }
    public void UpdateAllLights(bool turnOn)
    {
        for (int i = 0; i < Lights.Length; i++)
        {
                if(!turnOn)
                Lights[i].SetActive(false);
                else
                Lights[i].SetActive(true);
        }
    }
}
