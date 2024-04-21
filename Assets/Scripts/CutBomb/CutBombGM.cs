using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class CutBombGM : BombGM
{   
    public int TapBombTime = 10;
    private List<string> WireCuttingOrder;
    private List<int> WireCuttingOrderIndex;
    private HintLightsControll _hintLightsController;
    private GameObject Lights;
    private int HintRemainningTime;
    void Start()
    {
        UI_Timer.TimerEnded += () => ExplodeBomb("KeyPadBombImage");
        UI_Timer.TimerUpdated += (int time) => HandleTimerUpdate(time);
        if(currentBombInstance != null)
        _hintLightsController = currentBombInstance.GetComponentInChildren<HintLightsControll>();
    }
    //reset parameters when setactive 
    void OnEnable()
    {

    }

    void onDisable()
    {
        _hintLightsController = null;
    }
    override public void StartGame()
    {


        generateWireCuttingOrder();
        bombTime = TapBombTime;
        SpawnBomb();
        _hintLightsController = currentBombInstance.GetComponentInChildren<HintLightsControll>();
        HintRemainningTime = 4;

    }
    private void LightOff(TapWire Wire){
        if(Wire.Light == null)
            return;
        Wire.PairedWire.Light.SetActive(false);
        Destroy(Wire);
    }

    private void generateWireCuttingOrder()
    {
        WireCuttingOrder = new List<string> { "Wire Red", "Wire Blue", "Wire Green", "Wire Yellow"};
        WireCuttingOrderIndex = new List<int>{0,1,2,3};
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
            ExplodeBomb("KeyPadBombImage");
        }
    }

    void HandleTimerUpdate(int time)
    {   
        Debug.Log("HintRemainningTime: "+HintRemainningTime);
        if(HintRemainningTime > 0)
        {
            _hintLightsController.UpdateLight(WireCuttingOrderIndex[4-HintRemainningTime]);
        }
        if(HintRemainningTime == 0)
        {
            
            _hintLightsController.UpdateAllLights(false);
        }
       HintRemainningTime--;

    }
    void OnDestroy()
    {
        UI_Timer.TimerEnded -= () => ExplodeBomb("KeyPadBombImage");
        UI_Timer.TimerUpdated -= (int time) => HintRemainningTime = time;
    }


}