using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectionMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            CrossSceneReference.gameMode = 1; // practive mode
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SelectKeyPadGame()
    {
        CrossSceneReference.bombSelected = 0;
        CrossSceneReference.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
    }
    
    public void SelectDragGame()
    {
        CrossSceneReference.bombSelected = 1;
        CrossSceneReference.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);

    }
    
    public void SelectCutGame()
    {
        CrossSceneReference.bombSelected = 2;
        CrossSceneReference.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);

    }
    
    public void SelectTapGame()
    {
        CrossSceneReference.bombSelected = 3;
        CrossSceneReference.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);

    }
    
    public void SelectAudioGame()
    {
        CrossSceneReference.bombSelected = 4;
        CrossSceneReference.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);


    }

}
