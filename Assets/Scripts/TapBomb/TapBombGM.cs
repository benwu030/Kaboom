using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TapBombGM : BombGM
{
    public int TapBombTime = 5;
    public int bombType = 0;// 0:tap 1:shake 2:scream
    void Start()
    {
        // UI_Timer.TimerEnded += () => ExplodeBomb("KeyPadBombImage");
    }




    override public void StartGame()
    {
        // UI_Timer.TimerEnded += () => ExplodeBomb("KeyPadBombImage");
        bombType = Random.Range(0, 2);
        bombTime = TapBombTime;
        Invoke("SpawnBomb",0.2f);
    }


    //reset parameter in onEnable and onDisable



    public void Win()
    {
        DefuseBomb("KeyPadBombImage");
    }
    void OnDestroy()
    {
        // UI_Timer.TimerEnded -= () => ExplodeBomb("KeyPadBombImage");
    }

}