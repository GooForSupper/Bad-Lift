using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstaclePoint : MonoBehaviour
{
    Vector3 mainCamera;
    public TextMeshPro distanceText;
    public float distance;
    public float editedDistance;

    public float distanceBeforeEndingPreview = 10;

    public GameObject previewScreen;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(mainCamera, transform.position);
        editedDistance = distance -= 10;

        distanceText.text = editedDistance.ToString("F0");

        if (editedDistance < distanceBeforeEndingPreview)
        {
            Destroy(previewScreen);
            Destroy(gameObject);
        }
    }
}
