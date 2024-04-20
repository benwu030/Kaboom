using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class KeyPadButton : MonoBehaviour
{

    public static event Action<string> KeyPadButtonPressed = delegate { };
    private string buttonName, buttonValue;
    // Start is called before the first frame update
    void Start()
    {
        buttonName = gameObject.name; //get the name of the button
        buttonValue = buttonName.Substring(6);// as "Button" is 6 characters long
    }

    public void OnButtonPressed()
    {
        KeyPadButtonPressed(buttonValue);
        // Debug.Log("Button Pressed: " + buttonValue);
    }
}
