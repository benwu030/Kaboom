using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private List<BombGM> BombGMs;
    private bool gameEnd = false;
    private int numberOfBombs = 5;
    
    private List<BombGM> bombs = new List<BombGM>();
    private int bombID = 0;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Instantiate GMS all types of bombs

        foreach(BombGM bomb in BombGMs)
        {
            bombs.Add(Instantiate(bomb));
            bombs[bombID].gameObject.SetActive(false);
            bombID++;
        }

        // Instantiate first bomb
        InstantiateNextBomb();


    }

    public void InstantiateNextBomb(bool isPreivousBombDefused = false, int remainingTime = 0)
 
    {
        Debug.Log(numberOfBombs);

        int randomBomb = 2;
        // int randomBomb = UnityEngine.Random.Range(0, BombGMs.Count);
        Debug.Log(isPreivousBombDefused);
        Debug.Log(remainingTime);

        // Calculate score and update score
        if(isPreivousBombDefused)
        {
            // Calculate score
            // Update score
        }
        else
        {
            // Calculate score
            // Update score
        }
        // Instantiate next bomb
        // GameObject bombGM = Instantiate(BombGMs[Random.Range(0, BombGMs.Count)]);





        if(numberOfBombs == 0)
        {
            HandleGameEnd();
            return; 
        }

        // if (!bombs[randomBomb].getActive())
        // {
        //     bombs[randomBomb].setActive(true);
        //     bombs[randomBomb].StartGame();
        //     numberOfBombs--;
        // }

        if(!bombs[randomBomb].gameObject.activeSelf){
            bombs[randomBomb].gameObject.SetActive(true);
            bombs[randomBomb].StartGame();
            numberOfBombs--;
        }


        
    }

    private void HandleGameEnd()
    {
   
            Debug.Log("Game Over");
        
    }

    public static implicit operator GameManager(BombGM v)
    {
        throw new NotImplementedException();
    }
}
