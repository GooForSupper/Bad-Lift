using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooler : MonoBehaviour
{
    public Transform upCollider;
    public Transform leftCollider;
    public Transform downCollider;
    public Transform rightCollider;

    public LayerMask reactorLayer;

    Reactor reactor;

    // Start is called before the first frame update
    void Start()
    {
        reactor = FindObjectOfType<Reactor>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectNearObjects();
    }

    void DetectNearObjects()
    {
        if (Physics2D.OverlapCircle(upCollider.position, 0.2f, reactorLayer)
            || Physics2D.OverlapCircle(leftCollider.position, 0.2f, reactorLayer)
            || Physics2D.OverlapCircle(downCollider.position, 0.2f, reactorLayer)
            || Physics2D.OverlapCircle(rightCollider.position, 0.2f, reactorLayer))
        {
            reactor.beingCooled = true;
        }
        else
        {
            reactor.beingCooled = false;
        }
    }
}
