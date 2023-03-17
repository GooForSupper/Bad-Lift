using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkMaker : MonoBehaviour
{
    public ParticleSystem sparkParticles;

    public LayerMask movableLayer;
    public LayerMask reactorLayer;

    public bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        sparkParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTouching())
        {
            sparkParticles.Play();
        }
        else
        {
            sparkParticles.Stop();
        }
    }

    bool IsTouching()
    {
        var movableLayer = 1 << 6 | 1 << 8;
        return Physics2D.OverlapCircle(transform.position, 0.02f, ~movableLayer);
    }
}
