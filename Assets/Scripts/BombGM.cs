using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public abstract class BombGM : MonoBehaviour
{

    public static event System.Action<bool> BombDefused = delegate { };

    public GameObject bombPrefab; // Reference to the bomb prefab
    
    public GameObject explosionPrefab; // Reference to the explosion prefab
    public Transform bombSpawnPoint; // Position to spawn the bomb
    public Camera mainCamera; // Reference to the main camera
    public TextMeshProUGUI timerText; // Reference to the UI text element to display timer
    public GameObject currentBombInstance; // Reference to the spawned bomb
    private RectTransform bombImageLocation;
    public int bombTime = 5;
    // Start is called before the first frame update
    public UI_Timer  UI_Timer_Controller;
    public Coroutine CountDownCoroutine =null;
    public abstract void StartGame();
    public void SpawnBomb()
    {

        currentBombInstance = Instantiate(bombPrefab, bombSpawnPoint.position, Quaternion.identity);
        // Get the UI_Timer script component from the bomb prefab
        UI_Timer_Controller = currentBombInstance.GetComponentInChildren<UI_Timer>();
        //set the bomb time and update bomb displaytime
        UI_Timer_Controller.totalTime = bombTime;
        UI_Timer_Controller.currentTime = bombTime;
        UI_Timer_Controller.timeBar.totalTime = bombTime;
        UI_Timer_Controller.UpdateTimerDisplay();
        CountDownCoroutine = StartCoroutine(UI_Timer_Controller.Countdown());
    }




   public IEnumerator ShakeXY(float duration, float magnitude,string tag)
    {
            
         _ = (GameObject.FindGameObjectWithTag(tag)?.TryGetComponent(out bombImageLocation));
        if (bombImageLocation == null)
            yield break; // Stop the coroutine if bombImageLocation is null
    
        Vector3 originalPos = bombImageLocation.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            if (bombImageLocation == null)
            yield break; // Stop the coroutine if bombImageLocation is null
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            bombImageLocation.localPosition = new Vector3(x, y, originalPos.z);
            
            elapsed += Time.deltaTime;
            Debug.Log("Shaking");
            Debug.Log(bombImageLocation.localPosition);
            yield return null;
        }

        bombImageLocation.localPosition  = originalPos;
    }

    public IEnumerator ShakeX(float duration, float magnitude,string tag)
    {

        _ = (GameObject.FindGameObjectWithTag(tag)?.TryGetComponent(out bombImageLocation));
        if (bombImageLocation == null)
            yield break; // Stop the coroutine if bombImageLocation is null

        Vector3 originalPos = bombImageLocation.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
             if (bombImageLocation == null)
                yield break; // Stop the coroutine if bombImageLocation is null
            float x = Random.Range(-1f, 1f) * magnitude;

            bombImageLocation.localPosition = new Vector3(x, originalPos.y, originalPos.z);
            
            elapsed += Time.deltaTime;
            yield return null;
        }

        bombImageLocation.localPosition  = originalPos;
    }
    

    public void ExplodeBomb(string tag = "KeyPadBombImage"){
        GameManager.instance.TimerTickingAudio.Stop();
        Debug.Log("KABOOM");
        //wait until explosionInstance is destroyed
        bombImageLocation = GameObject.FindGameObjectWithTag(tag).GetComponent<RectTransform>();
        Vector3 explosionPos = new Vector3(bombImageLocation.position.x, bombImageLocation.position.y, bombImageLocation.position.z+5);
        GameObject explosionInstance = Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
        ParticleSystem explosion = explosionInstance.GetComponent<ParticleSystem>();
        GameManager.instance.BombExplodedSound.Play();
        GameObject temp = Instantiate(GameManager.instance.BombKaboomPrefab, GameManager.instance.transform.position, Quaternion.identity);
        Destroy(temp, explosion.main.duration);
        Destroy(explosionInstance,explosion.main.duration);
        UI_Timer_Controller = null;
        //check if destroy explosionInstance is finished
        //notify the gamemanager move to next bomb
 
        GameManager.instance.InstantiateNextBomb(false, 0);

        
    }


    public void DefuseBomb(string tag = "KeyPadBombImage"){
        GameManager.instance.TimerTickingAudio.Stop();
        Debug.Log("Bomb Defused");
    
        GameManager.instance.BombDefusedSound.Play();
        
        GameObject temp = Instantiate(GameManager.instance.BombDefusedPrefab, GameManager.instance.transform.position, Quaternion.identity);
        Destroy(temp, 2f);
        GameManager.instance.InstantiateNextBomb(true,UI_Timer_Controller.currentTime);
        UI_Timer_Controller = null;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
