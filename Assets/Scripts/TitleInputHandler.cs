using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleInputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("here");
        if (Input.GetKeyDown("return"))
        {
            Debug.Log("changing scene");
            SceneManager.LoadScene("Play");
        }   
    }
}
