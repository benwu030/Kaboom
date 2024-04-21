using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using System;
public class KeyPadDisplay : MonoBehaviour
{


    public int password = 1234;
    public TextMeshProUGUI displayText;

    private KeyPadGM keyPadGM;
    public TextMeshProUGUI QuestionText;
    // Start is called before the first frame update
    void Start()
    {
        keyPadGM = FindFirstObjectByType<KeyPadGM>();
        QuestionText.text = keyPadGM.questionText;
        displayText.text ="";
        KeyPadButton.KeyPadButtonPressed += UpdateDisplay;
    }

    
    private void UpdateDisplay(string value)
    {

        switch (value)
        {
            case "Enter":
                keyPadGM.ValidatePwd(displayText.text);
                displayText.text = "";
                break;
            case "Clear":
                displayText.text = "";
                break;
            default:
                if(displayText.text.Length < 5)
                displayText.text += value;
                else
                keyPadGM.ValidatePwd(displayText.text);
                break;
        }
    }

    private void OnDestroy()
    {
        KeyPadButton.KeyPadButtonPressed -= UpdateDisplay;
    }



}
