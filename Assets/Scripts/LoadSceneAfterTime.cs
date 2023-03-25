using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTime : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] float time = 25;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCounter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }
}
