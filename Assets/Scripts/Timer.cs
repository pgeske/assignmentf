using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static int secondsPassed = 0;

    public static string GetTimePassed()
    {
        int min = Mathf.FloorToInt(secondsPassed / 60);
        int sec = Mathf.FloorToInt(secondsPassed % 60);
        return min.ToString("00") + ":" + sec.ToString("00");
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncrementTime", 1.0f, 1.0f);
    }

    void IncrementTime()
    {
        secondsPassed++;
    }

    // Update is called once per frame
    void Update()
    {
        int min = Mathf.FloorToInt(secondsPassed / 60);
        int sec = Mathf.FloorToInt(secondsPassed % 60);
        GetComponent<UnityEngine.UI.Text>().text = GetTimePassed();
    }
}
