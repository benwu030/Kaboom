using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{

    public Draggable LastDragged => _lastDraggable;
   private Vector3 touchPosition;
    private Vector2 _screenPos;

    private Vector3 _worldPos;
    private bool isDragedActive = false;
    private Draggable _lastDraggable;

    private DragBombGM dragBombGM;

    public AudioSource wireConnectSound;
    void Start()
    {
        dragBombGM = FindObjectOfType<DragBombGM>();
    }

    void Update()
    {   



        if(isDragedActive && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Drop();
            return;
        }

        if (Input.touchCount > 0)
        {
            _screenPos = Input.GetTouch(0).position;
           
        }
        else{
            return;
        }

        _worldPos = Camera.main.ScreenToWorldPoint(_screenPos);
        _worldPos.z = 0;
        if(isDragedActive)
            Drag();
        else
        {
                RaycastHit2D hit = Physics2D.Raycast(_worldPos, Vector2.zero);
                if(hit.collider != null){
                     Draggable _draggable = hit.transform.gameObject.GetComponent<Draggable>();
                        if (_draggable != null)
                        {
                            _lastDraggable = _draggable;
                            InitDrag();

                        }
                }
               
            
        }
    }

    private void Drag(){
        Vector3 startPoint = _lastDraggable.gameObject.transform.parent.position;
        
        //check for nearby connections
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_worldPos, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject !=_lastDraggable.gameObject){
                UpdatePosistion(collider.transform.position,startPoint);
                 wireConnectSound.Play();
                //check if it connects with the correct wire
                if(collider.gameObject.transform.parent.name == _lastDraggable.gameObject.transform.parent.name){
                    UpdateDragStatus(false);//if connected toggle drag status so it can no longer be dragged
                    dragBombGM.checkWires(_lastDraggable,collider.gameObject.GetComponent<Draggable>(),1);

                    return;
                }
                return;
            }
        }
        
        UpdatePosistion(_worldPos,startPoint);    


    }


  
    private void InitDrag(){
        _lastDraggable.LastPosition = _lastDraggable.transform.position;
        UpdateDragStatus(true);
    }

    private void Drop(){
       
        Vector3 startPoint = _lastDraggable.gameObject.transform.parent.position;
        UpdateDragStatus(false);
        UpdatePosistion(_lastDraggable.originalPosition,startPoint);    

    }

    void UpdateDragStatus(bool isDragging){
        isDragedActive = _lastDraggable.IsDraggaing = isDragging;
        _lastDraggable.gameObject.layer = isDragging ? Layer.Dragging : Layer.Default;
    }


    private void UpdatePosistion(Vector3 newPosition, Vector3 startPoint){
        
        
        Vector3 direction = newPosition - startPoint;   
        _lastDraggable.transform.position = newPosition;
        _lastDraggable.transform.right = direction * _lastDraggable.transform.lossyScale.x;
        float dist = Vector2.Distance(startPoint, newPosition);
        _lastDraggable.wireEnd.size =  new Vector2(dist,_lastDraggable.wireEnd.size.y);
    }



}
