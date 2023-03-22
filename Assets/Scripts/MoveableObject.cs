using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    public bool selected;
    public bool mouseOver;

    public GameObject selectedOutline;
    public GameObject hoverOutline;

    public Transform upCollider;
    public Transform leftCollider;
    public Transform downCollider;
    public Transform rightCollider;

    public bool upDetected;
    public bool leftDetected;
    public bool downDetected;
    public bool rightDetected;

    public LayerMask movableLayer;

    public ParticleSystem breakingParticles;

    public GameObject leftAudioObject;
    public GameObject rightAudioObject;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mouseOver)
            {
                selected = true;
                selectedOutline.SetActive(true);
            }
            else
            {
                selected = false;
                selectedOutline.SetActive(false);
            }
        }

        if (selected)
        {
            MoveObject();
            DetectNearObjects();
        }

        SparkSounds();
    }

    void MoveObject()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!upDetected)
            {
                transform.position = transform.position + new Vector3(0, 1, 0);
            }
            else
            {
                animator.SetTrigger("shake");
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (!leftDetected)
            {
                transform.position = transform.position + new Vector3(-1, 0, 0);
            }
            else
            {
                animator.SetTrigger("shake");
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!downDetected)
            {
                transform.position = transform.position + new Vector3(0, -1, 0);
            }
            else
            {
                animator.SetTrigger("shake");
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (!rightDetected)
            {
                transform.position = transform.position + new Vector3(1, 0, 0);
            }
            else
            {
                animator.SetTrigger("shake");
            }
        }
    }

    void DetectNearObjects()
    {
        upDetected = Physics2D.OverlapCircle(upCollider.position, 0.2f);
        leftDetected = Physics2D.OverlapCircle(leftCollider.position, 0.2f);
        downDetected = Physics2D.OverlapCircle(downCollider.position, 0.2f);
        rightDetected = Physics2D.OverlapCircle(rightCollider.position, 0.2f);
    }

    public void DestroySelf()
    {
        Instantiate(breakingParticles, transform.position, Quaternion.identity);
        FindObjectOfType<LoseCondition>().LoseGame();
        Destroy(gameObject);
    }

    void SparkSounds()
    {
        var movableLayer = 1 << 6 | 1 << 8;

        if (Physics2D.OverlapCircle(leftAudioObject.transform.position, 0.02f, ~movableLayer))
        {
            leftAudioObject.SetActive(true);
        }
        else
        {
            leftAudioObject.SetActive(false);
        }

        if (Physics2D.OverlapCircle(rightAudioObject.transform.position, 0.02f, ~movableLayer))
        {
            rightAudioObject.SetActive(true);
        }
        else
        {
            rightAudioObject.SetActive(false);
        }
    }

    void OnMouseOver()
    {
        mouseOver = true;
        hoverOutline.SetActive(true);
    }

    void OnMouseExit()
    {
        mouseOver = false;
        hoverOutline.SetActive(false);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        DestroySelf();
    }
}
