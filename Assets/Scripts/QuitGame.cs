using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuitGame : MonoBehaviour
{
    TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Application.Quit();
    }

    void OnMouseOver()
    {
        text.color = Color.red;
    }

    void OnMouseExit()
    {
        text.color = Color.black;
    }
}
