using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_TapDenotate : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshProUGUI _TapDenotateText;
    //create const string
    const string _TapDenotate = " to denotate the Bomb!";
    void Start()
    {
        _TapDenotateText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDescription(string description)
    {
        _TapDenotateText.text = description + _TapDenotate;
    }
}
