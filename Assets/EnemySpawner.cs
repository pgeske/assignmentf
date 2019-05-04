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
        // pick a side
        Tilemap tilemap = area.GetComponent<Tilemap>();
        int side = Random.Range(0, 3);
        Vector2 spawnPosition;

        if (side == 0)
        {
            spawnPosition = new Vector2(-1 * tilemap.size.x / 2 + 1, 0);
        }
        else if (side == 1)
        {
            spawnPosition = new Vector2(0, -1 * tilemap.size.y / 2 + 1);
        }
        else if (side == 2)
        {
            spawnPosition = new Vector2(tilemap.size.x / 2 - 1, 0);
        }
        else
        {
            spawnPosition = new Vector2(0, tilemap.size.y / 2 - 1);
        }
        

        // spawn enemy on that side
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().vertical = side % 2 == 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        area.GetComponent<Tilemap>();
        InvokeRepeating("InstantiateEnemy", 1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Tilemap tilemap = area.GetComponent<Tilemap>();
    }
}
