using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TimeBar timeBar;

    [SerializeField]
    private List<BombGM> BombGMs;
    private int numberOfBombs;
    
    private List<BombGM> bombs = new List<BombGM>();
    private int bombID = 0;

    private int _gameMode;
    public float totalTime = 60.0f;
    private int previousBombId = -1;
    public AudioSource  TimerTickingAudio;
    public AudioSource BombDefusedSound;
    public AudioSource BombExplodedSound;

    public GameObject BombDefusedPrefab;
    public GameObject BombKaboomPrefab;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        //get cross reference params
        
        _gameMode = CrossSceneReference.gameMode;
        switch(_gameMode){
            case 0: //default
                numberOfBombs = 5;
                break;
            case 1: // practice
                numberOfBombs = 1;
                break;
            case 2:
                numberOfBombs = 10;
                break;
            default:
                numberOfBombs = 3;
                break;
        }

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
void Update()
    {

    }

//ugly way to Instantiate A Bomb
//The design is really bad
//Current: InstantiateNextBomb is called from BombGM.cs which is diffucult to refer to the instance gameobject instantiated in GM
//gameobject in BombGM or its children will be referring to the prefab not the instance
    public void InstantiateNextBomb(bool isPreivousBombDefused = false, int remainingTime = 0)
 
    {
        int randomBomb;
        CrossSceneReference.score+=remainingTime *100;
        if(CrossSceneReference.gameMode==0){
            randomBomb = UnityEngine.Random.Range(0, BombGMs.Count);
        }
        else{
            randomBomb = CrossSceneReference.bombSelected;
        }
        if(previousBombId!=-1){
            bombs[previousBombId].gameObject.SetActive(false);
            Destroy(bombs[previousBombId].currentBombInstance);
        }
        // int randomBomb = 1;
        
        previousBombId = randomBomb;


        
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
            Debug.Log("Game Over" + CrossSceneReference.score);
            StartCoroutine(WaitAndShowGameEndStats(2f));
            return; 
        }


        if(!bombs[randomBomb].gameObject.activeSelf && bombs[randomBomb] != null){
            bombs[randomBomb].gameObject.SetActive(true);
            StartCoroutine(WaitAndCreateNextBomb(2f,randomBomb));//ugly way to force gamemanager to wait for the explosion animation
            numberOfBombs--;
        }


        
    }

    private IEnumerator WaitAndCreateNextBomb(float seconds, int randomBomb){
        //create the next bomb
        //notify the gamemanager move to next bomb
        yield return new WaitForSeconds(seconds);
        //deactivate the bombGM GameObject
        BombExplodedSound.Stop();
        BombDefusedSound.Stop();

        bombs[randomBomb].StartGame();
    }

    private IEnumerator WaitAndShowGameEndStats(float seconds){
        //create the next bomb
        //notify the gamemanager move to next bomb
        yield return new WaitForSeconds(seconds);
        //deactivate the bombGM GameObject
        BombExplodedSound.Stop();
        BombDefusedSound.Stop();
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(3);

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
