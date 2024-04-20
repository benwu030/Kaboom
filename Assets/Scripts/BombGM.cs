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
    private GameObject currentBombInstance; // Reference to the spawned bomb
    private RectTransform bombImageLocation;
    public int bombTime = 5;
    // Start is called before the first frame update
    public UI_Timer  UI_Timer_Controller;

    public abstract void StartGame();
    public void SpawnBomb()
    {

        currentBombInstance = Instantiate(bombPrefab, bombSpawnPoint.position, Quaternion.identity);
        UI_Timer_Controller = currentBombInstance.GetComponentInChildren<UI_Timer>();
        UI_Timer_Controller.totalTime = bombTime;
        // Get the UI_Timer script component from the bomb prefab

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
    

    public void ExplodeBomb(string tag){
        Debug.Log("KABOOM");

        bombImageLocation = GameObject.FindGameObjectWithTag(tag).GetComponent<RectTransform>();
        Vector3 explosionPos = new Vector3(bombImageLocation.position.x, bombImageLocation.position.y, bombImageLocation.position.z+5);
        GameObject explosionInstance = Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
        ParticleSystem explosion = explosionInstance.GetComponent<ParticleSystem>();
        Destroy(explosionInstance, explosion.main.duration);
        explosionInstance = null;
        Destroy(currentBombInstance);
        currentBombInstance = null;
        //notify the gamemanager move to next bomb
        gameObject.SetActive(false);//deactivate the bombGM GameObject
        GameManager.instance.InstantiateNextBomb(false, 0);
        
    }

    public void DefuseBomb(string tag = "BombImage"){
        Debug.Log("Bomb Defused");
        Destroy(currentBombInstance);
        currentBombInstance = null;

        //notify the gamemanager move to next bomb
        gameObject.SetActive(false);//deactivate the bombGM GameObject

        GameManager.instance.InstantiateNextBomb(true,UI_Timer_Controller.currentTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
