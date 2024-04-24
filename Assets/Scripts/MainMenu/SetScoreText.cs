using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text =  CrossSceneReference.score.ToString();
        CrossSceneReference.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
