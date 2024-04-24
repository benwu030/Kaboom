using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class KeyPadGM : BombGM
{
    public string questionText;
    private int operand1;
    private int operand2;

    private int remainder;
    private int password;
    private static bool isDefused = false;
    private Coroutine shakeCoroutine;
    void Start()
    {
    //    UI_Timer.TimerEnded += () => ExplodeBomb("KeyPadBombImage");
    }


 
    override public void StartGame()
    {
        isDefused = false;
        GenerateQuestion();//generate questions and set bomb time
        SpawnBomb();

    }

    public int GenerateQuestion()
    {
        // int operation =  3;
        int operation = Random.Range(0, 4); // 0 for addition, 1 for subtraction, 2 for multiplication, 3 for division
        password = Random.Range(1000, 10000); // Generate a random target result between 1000 and 9999
        switch (operation)
    {
        case 0: // Addition
            operand1 = Random.Range(1000, password);
            operand2 = password - operand1;
            questionText = operand1 + " + " + operand2 + " = ?";
            bombTime = 10;
            break;
        case 1: // Subtraction
            operand1 = Random.Range(password, 10000);
            operand2 = operand1 - password;
            questionText= operand1 + " - " + operand2 + " = ?";
            bombTime = 10;

            break;
        case 2: // Multiplication
            operand1 = Random.Range(10, 100); // Limit the range to avoid very large numbers
            remainder = password % operand1; //get remainder
            password -= remainder; // Adjust the password to be divisible by operand1
            operand2 = password / operand1;
            questionText = operand1 + " * " + operand2 + " = ?";
            bombTime = 20;

            break;
        case 3: // Division
            operand2 = Random.Range(2, 100); // Limit the range to avoid division by 0 and very small quotients
            operand1 = password * operand2;
            questionText = operand1 + " / " + operand2 + " = ?";
            bombTime = 25;

            break;


    }

    return bombTime;

    }
    public void ValidatePwd(string value)
    {
        if (value.Length <= 0 || int.Parse(value) != password)
        {
            Debug.Log("Invalid Password");
            //play password error sound
            GetComponent<AudioSource>().Play();
            //deduct Time
            UI_Timer_Controller.forceUpdateTimer(-2);
            //shake the camera
            if(gameObject.activeSelf){
                Handheld.Vibrate();
                shakeCoroutine = StartCoroutine(ShakeX(1f, 5f,"KeyPadBombImage"));
            }
 
            return;
        }

        else //correct password
        {
            //play bomb defused sound
            //Destroy the bomb
            if(!isDefused)
            {
                isDefused = true;
                DefuseBomb();
            }
      
        }
    
    }



    void OnDestroy()
    {
        // UI_Timer.TimerEnded -= () => ExplodeBomb("KeyPadBombImage");
        if(shakeCoroutine!=null)
        StopCoroutine(shakeCoroutine);
    }
}

