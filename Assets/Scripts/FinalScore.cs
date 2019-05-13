using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = Timer.GetTimePassed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
