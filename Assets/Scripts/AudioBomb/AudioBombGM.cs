using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBombGM : BombGM
{
    // Start is called before the first frame update
    void Start()
    {
        // UI_Timer.TimerEnded += () => ExplodeBomb("KeyPadBombImage");
    }

    override public void StartGame()
    {
        // UI_Timer.TimerEnded += () => ExplodeBomb("KeyPadBombImage");
        bombTime = 8;
        SpawnBomb();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnDestroy()
    // {
    //     UI_Timer.TimerEnded -= () => ExplodeBomb("KeyPadBombImage");
    // }
}
