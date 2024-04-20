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
    private DragBombGM dragBombGM;
    void Start()
    {
        // dragBombGM = FindObjectOfType<DragBombGM>();
    }

    void Update()
    {   

        // if(Input.touchCount ==1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        //     return;

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
            if (TappedWire != null)
            {
                LeftWire = TappedWire;
                RightWire = TappedWire.PairedWire;
                UpdateLefTRightWirePosistion(_worldPos);
                UpdateDisconnectedWire(_worldPos,LeftWire);
                UpdateDisconnectedWire(_worldPos,RightWire);

            }
        }
    }

    }
    private void UpdateLefTRightWirePosistion(Vector3 newPosition){
        
        Debug.Log("updatiing "+newPosition);
        UpdatePosistion(newPosition, LeftWire);
        UpdatePosistion(newPosition, RightWire);


    }

    private void UpdatePosistion(Vector3 newPosition, TapWire wire){
        float dist = Vector2.Distance(wire.originalPosition, newPosition);
        wire.wireEnd.size =  new Vector2(dist,wire.wireEnd.size.y);

    }

    private void UpdateDisconnectedWire(Vector3 newPosition,TapWire wire){


        if(!wire.DisconnectedWire.activeSelf)
            wire.DisconnectedWire.SetActive(true);
        else return;

        float offset = Vector2.Distance(wire.originalPosition, wire.PairedWire.originalPosition);
        float dist = Vector2.Distance(wire.originalPosition, newPosition);
        wire.DisconnectedWire.transform.position =  new Vector2(newPosition.x-5,wire.originalPosition.y);

    }   

}

