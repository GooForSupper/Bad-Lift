using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    float currentTime;
    public float maxTime = 6;

    public TextMeshPro counterText;

    public bool beingCooled;
    Animator animator;

    MoveableObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        currentTime = maxTime;
        beingCooled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!beingCooled)
        {
            Overheating();
            animator.SetBool("overheating", true);
        }
        else
        {
            currentTime = maxTime;
            counterText.gameObject.SetActive(false);
            animator.SetBool("overheating", false);
        }

        if (currentTime <= 0)
        {
            Explode();
        }

        counterText.text = currentTime.ToString("F0");
    }

    void Overheating()
    {
        currentTime -= Time.deltaTime;
        counterText.gameObject.SetActive(true);
    }

    void Explode()
    {
        objects = FindObjectsOfType<MoveableObject>();
        foreach (MoveableObject singleObject in objects)
        {
            singleObject.DestroySelf();
        }
        GetComponent<MoveableObject>().DestroySelf();
    }
}
