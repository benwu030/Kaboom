using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNormalBombGame()
    {
        CrossSceneReference.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        CrossSceneReference.gameMode = 0; // normal mode
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadBombSelection()
    {
        CrossSceneReference.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadSceneAsync(2);
    }
}
