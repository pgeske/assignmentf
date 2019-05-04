using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject area; 

    private void InstantiateEnemy()
    {
        Tilemap tilemap = area.GetComponent<Tilemap>();
        Instantiate(enemyPrefab, new Vector2(tilemap.size.x / 2 - 1, 0), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        area.GetComponent<Tilemap>();
        InvokeRepeating("InstantiateEnemy", 1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Tilemap tilemap = area.GetComponent<Tilemap>();
        Debug.Log(tilemap.size.x);
        Debug.Log(tilemap.size.y);
        Debug.Log(tilemap.localBounds);
    }
}
