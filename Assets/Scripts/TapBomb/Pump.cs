using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject Pump_body;
    // public GameObject Pump_pipe;
    public GameObject Pump_handle;
    private Vector3 FixedUpdatePosition;
    public Vector3 Pump_handle_originalPosition;
    private float moveTime = 15f;
    private bool isPumpHandleTapped = false;    
    void Start()
    {
        Pump_handle_originalPosition = Pump_handle.transform.position;  
        FixedUpdatePosition = Pump_handle.transform.position;  
        FixedUpdatePosition.y -= 1.1f;     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fixed update is called every fixed frame
    void FixedUpdate()
    {
        // UpdatePumpHandlePosition();
        if(isPumpHandleTapped)
        {
            Pump_handle.transform.position = Vector3.Lerp(Pump_handle.transform.position, FixedUpdatePosition, moveTime * Time.fixedDeltaTime);
            isPumpHandleTapped = false;  
        }
        else
        {
            Pump_handle.transform.position = Vector3.Lerp(Pump_handle.transform.position, Pump_handle_originalPosition, moveTime * Time.fixedDeltaTime);
        }
        
    }

    public void UpdatePumpHandlePosition()
    {
        isPumpHandleTapped = true;
    }
}
