using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for checking wire connection and generating the wires
public class DragBombGM : BombGM
{
    public GameObject LeftWire;
    public GameObject RightWire;
    private int remainingWires = 5;
    // Start is called before the first frame update
    void Start()
    {
         UI_Timer.TimerEnded += () => ExplodeBomb("KeyPadBombImage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      override public void StartGame()
    {
        gameObject.SetActive(true);

        bombTime = 20;
        SpawnBomb();

    }




    public void checkWires(Draggable wire1, Draggable wire2,int wireConnected = 1)
    {
        if(wire1 == null || wire2 == null)
            return;
        //check if all wires are connected
        LightUp(wire1);
        LightUp(wire2);
        remainingWires -= wireConnected;
        if (remainingWires == 0)
        {
            DefuseBomb();
            remainingWires = 5;
        }

    }

  private void LightUp(Draggable Wire){
        if(Wire.Light == null)
            return;
        Wire.Light.SetActive(true);
        Destroy(Wire);
    }


    void OnDestroy(){
        UI_Timer.TimerEnded -= () => ExplodeBomb("KeyPadBombImage");
    }

}