using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDraggaing;

    // private Collider2D _collider;
    public SpriteRenderer wireEnd;
    public Vector2 originalSize;
    public GameObject Light;
    public Vector3 originalPosition;
    public Vector3 LastPosition;

    private DragController _dragController;
    public float moveTime = 15f;
    private System.Nullable<Vector3> moveDestination;
    // Start is called before the first frame update
    void Start()
    {
        // _collider = GetComponent<Collider2D>();
        // _dragController = FindObjectOfType<DragController>();
        originalSize = wireEnd.size;
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void FixedUpdate()
    // {
    //     if(moveDestination.HasValue)
    //     {
    //         if(IsDraggaing)
    //             {
    //                 moveDestination = null;
    //                 return;
    //             }
    //         if(transform.position == moveDestination)
    //         {
    //             gameObject.layer = Layer.Default;
    //             moveDestination = null;
                
    //         }
    //         else
    //         {
    //         // transform.position = Vector3.Lerp(transform.position, moveDestination.Value, moveTime * Time.fixedDeltaTime);
    //             transform.position = Vector3.Lerp(transform.position, originalPosition, moveTime * Time.fixedDeltaTime);
    //             wireEnd.size = originalSize;
        
    //         }
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     Draggable collidedDraggable = other.GetComponent<Draggable>();
    //     // Debug.Log("Collided with " + other.gameObject.name);
    //     if(collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject){
    //         ColliderDistance2D colliderDistance2D = other.Distance(_collider);
    //         Vector3 diff =  new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y, 0) * colliderDistance2D.distance;
    //         transform.position -= diff;
    //     }

    //     //call gameManger to check if it is a valid trigger
    //     // if(true)
    //     // moveDestination = other.transform.position;
    //     // moveDestination = LastPosition;

    // }
}
