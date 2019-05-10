using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    private RectTransform rect;
    public GameObject heartPrefab;

    // Return a random position within the bounding rectangle
    private Vector2 getRandomPosition()
    {
        return new Vector2(Random.Range(rect.rect.xMin, rect.rect.xMax), 
            Random.Range(rect.rect.yMin, rect.rect.yMax));
    }


    void InstantiatePowerup()
    {
        if (Random.Range(0, 2) == 1)
        {
            Instantiate(heartPrefab, getRandomPosition(), Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        InvokeRepeating("InstantiatePowerup", 10.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rect.position);
    }
}
