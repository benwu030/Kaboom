using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{

   private Vector3 touchPosition;
    private Vector2 _screenPos;
    private Vector3 _worldPos;
    private TapWire LeftWire;
    private TapWire RightWire;
    private GameObject DisconnectedWire;
    private TapBombGM tapBombGM;
    private float DisconnectedWireOffset = 0.4f;
    void Start()
    {
        tapBombGM = FindObjectOfType<TapBombGM>();
    }

    void Update()
    {   

    if (Input.touchCount ==1 && Input.GetTouch(0).phase == TouchPhase.Ended)
    {
        touchPosition = Input.GetTouch(0).position;
        Debug.Log(touchPosition);

        _screenPos = new Vector2(touchPosition.x, touchPosition.y);
        _worldPos = Camera.main.ScreenToWorldPoint(_screenPos);
        _worldPos.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(_worldPos, Vector2.zero);
        if (hit.collider != null)
        {
            TapWire TappedWire = hit.collider.GetComponent<TapWire>();
            if (TappedWire != null && TappedWire.PairedWire != null && TappedWire.PairedWire.IsDisconnected == false)
            {
                LeftWire = TappedWire;
                RightWire = TappedWire.PairedWire;
                UpdateLeftRightWirePosistion(_worldPos);
                UpdateDisconnectedWire(_worldPos,LeftWire);
                UpdateDisconnectedWire(_worldPos,RightWire);
                tapBombGM.CheckWireCuttingOrder(LeftWire);
            }
        }
    }

    }
    private void UpdateLeftRightWirePosistion(Vector3 newPosition){
        
        Debug.Log("updatiing "+newPosition);
        //deduct the offset from newPosition
        newPosition.x -= (LeftWire.transform.lossyScale.x * DisconnectedWireOffset);
        UpdatePosistion(newPosition, LeftWire);
        newPosition.x -= (RightWire.transform.lossyScale.x * DisconnectedWireOffset * 2);
        UpdatePosistion(newPosition, RightWire);


    }

    private void UpdatePosistion(Vector3 newPosition, TapWire wire){
        float dist = Vector2.Distance(wire.originalPosition, newPosition);
        wire.wireEnd.size =  new Vector2(dist,wire.wireEnd.size.y);

    }

    private void UpdateDisconnectedWire(Vector3 newPosition, TapWire wire)
    {
        if (!wire.IsDisconnected){
            wire.IsDisconnected = true;
            wire.DisconnectedWire.SetActive(true);

        }
        else return;

        float dist = (float)(newPosition.x -  wire.transform.lossyScale.x * DisconnectedWireOffset);
        wire.DisconnectedWire.transform.position = new Vector2(dist, wire.originalPosition.y);
    }

}

