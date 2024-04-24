using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_TapCount : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI _TapCountText;
    void Start()
    {
    }

    public void UpdateTapCount(int count)
    {
        _TapCountText.text = count.ToString();
    }
}
