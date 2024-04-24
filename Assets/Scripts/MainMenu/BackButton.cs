using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPreviousScene()
    {
        int temp = CrossSceneReference.previousSceneIndex;
        CrossSceneReference.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        CrossSceneReference.gameMode = 0; // normal mode
        SceneManager.LoadSceneAsync(temp);
    }

        public void LoadMainMenuScene()
    {
        CrossSceneReference.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        CrossSceneReference.gameMode = 0; // normal mode
        SceneManager.LoadSceneAsync(0);
    }

}