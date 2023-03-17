using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappingGuide : MonoBehaviour
{
    Vector2 pointerPosition;
    Vector2 snappedPointerPosition;
    public Vector2 lastPosition;

    public bool detectedObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        snappedPointerPosition = new Vector2(Mathf.RoundToInt(pointerPosition.x), Mathf.RoundToInt(pointerPosition.y));
        transform.position = snappedPointerPosition;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        if (!detectedObject)
        {
            lastPosition = transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.GetComponent<LiftPiece>().beingDragged)
        {
            detectedObject = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        detectedObject = false;
    }
}
