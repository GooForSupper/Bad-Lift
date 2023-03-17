using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftPiece : MonoBehaviour
{
    Vector2 pointerPosition;
    Vector2 snappedPointerPosition;

    public bool beingDragged;

    SnappingGuide snappingGuide;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        snappingGuide = FindObjectOfType<SnappingGuide>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        snappedPointerPosition = new Vector2(Mathf.RoundToInt(pointerPosition.x), Mathf.RoundToInt(pointerPosition.y));
    }

    void OnMouseDrag()
    {
        transform.position = pointerPosition;
        //rb.bodyType = RigidbodyType2D.Kinematic;

        beingDragged = true;
    }

    void OnMouseUp()
    {
        //transform.position = snappedPointerPosition;
        //rb.bodyType = RigidbodyType2D.Dynamic;

        transform.position = snappingGuide.lastPosition;

        beingDragged = false;
    }
}
