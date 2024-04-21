using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TapWire : MonoBehaviour
{
    public bool IsDisconnected = false;

    // private Collider2D _collider;
    public SpriteRenderer wireEnd;
    public Vector2 originalSize;
    public GameObject Light;
    public Vector3 originalPosition;
    public Vector3 LastPosition;
    public TapWire PairedWire;
    public GameObject DisconnectedWire;
    public float moveTime = 15f;
    // Start is called before the first frame update
    void Start()
    {
        DisconnectedWire = transform.GetChild(0).gameObject;
        originalSize = wireEnd.size;
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}