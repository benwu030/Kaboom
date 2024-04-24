using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class CutBombGM : BombGM
{   
    public int TapBombTime = 10;
    private static List<string> WireCuttingOrder;
    private static List<int> WireCuttingOrderIndex;
    public static HintLightsControll _hintLightsController;
    private static int HintRemainningTime;
    void Start()
    {
        // UI_Timer.TimerEnded += () => ExplodeBomb("KeyPadBombImage");
        // UI_Timer.TimerUpdated += (int time) => HandleTimerUpdate(time);

    }
    //reset parameters when setactive 

    override public void StartGame()
    {
        HintRemainningTime = 4;
        WireCuttingOrder = new List<string> { "Wire Red", "Wire Blue", "Wire Green", "Wire Yellow"};
        WireCuttingOrderIndex = new List<int>{0,1,2,3};
        GenerateWireCuttingOrder();
        bombTime = TapBombTime;
        SpawnBomb();
        _hintLightsController = currentBombInstance.GetComponentInChildren<HintLightsControll>();


    }
    private void LightOff(TapWire Wire){
        if(Wire.Light == null)
            return;
        Wire.PairedWire.Light.SetActive(false);
        Destroy(Wire);
    }

    private void GenerateWireCuttingOrder()
    {

        for (int i = 0; i < WireCuttingOrder.Count; i++)
        {
            string temp = WireCuttingOrder[i];
            int tempIndex = WireCuttingOrderIndex[i];
            int randomIndex = Random.Range(i, WireCuttingOrder.Count);
            WireCuttingOrder[i] = WireCuttingOrder[randomIndex];
            WireCuttingOrder[randomIndex] = temp;
            WireCuttingOrderIndex[i] = WireCuttingOrderIndex[randomIndex];
            WireCuttingOrderIndex[randomIndex] = tempIndex;

        }

        // foreach (int index in WireCuttingOrderIndex)
        // {
        //     Debug.Log(index);
        // }
        //another way is to group the two lists together and shuffle them together
    }


    public void CheckWireCuttingOrder(TapWire wire)
    {
        if (WireCuttingOrder.Count == 0)
            return;
        if (wire.transform.parent.name == WireCuttingOrder[0])
        {
            WireCuttingOrder.RemoveAt(0);
            LightOff(wire);
            if (WireCuttingOrder.Count == 0)
            {
                DefuseBomb();
            }
        }
        else
        {
            ExplodeBomb();
        }
    }

    public void HandleTimerUpdate()
    {   
        int index = 4-HintRemainningTime;   
        // Debug.Log(WireCuttingOrderIndex[index]);
        if(HintRemainningTime > 0)
        {
            _hintLightsController.UpdateLight(WireCuttingOrderIndex[index]);
        }
        if(HintRemainningTime == 0)
        {
            
            _hintLightsController.UpdateAllLights(false);
        }
       HintRemainningTime--;

    }
    // void OnDestroy()
    // {
    //     UI_Timer.TimerEnded -= () => ExplodeBomb("KeyPadBombImage");
    //     UI_Timer.TimerUpdated -= (int time) => HintRemainningTime = time;
    // }


}