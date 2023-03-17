using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public bool move = true;
    bool speedUp;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            if (speedUp)
            {
                rb.velocity = new Vector2(transform.position.x, moveSpeed * Time.deltaTime * 2);
            }
            else
            {
                rb.velocity = new Vector2(transform.position.x, moveSpeed * Time.deltaTime);
            }
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedUp = true;
        }
        else
        {
            speedUp = false;
        }
    }
}
