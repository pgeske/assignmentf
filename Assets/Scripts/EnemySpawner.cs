using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject area;
    private EnemyMovement.Side currentSide;

    private EnemyMovement.Side getNextSide()
    {   
        if (currentSide == EnemyMovement.Side.Right)
        {
            return EnemyMovement.Side.Bottom;
        }
        else if (currentSide == EnemyMovement.Side.Bottom)
        {
            return EnemyMovement.Side.Left;
        }
        else if (currentSide == EnemyMovement.Side.Left)
        {
            return EnemyMovement.Side.Top;
        }

        return EnemyMovement.Side.Right;
    }

    private void InstantiateEnemy()
    {
        // pick next side to spawn enemy at
  
        Tilemap tilemap = area.GetComponent<Tilemap>();
        EnemyMovement.Side side = getNextSide();
        currentSide = side;
        Vector2 spawnPosition;

        // set enemy to spawn on that side
        if (side == EnemyMovement.Side.Left)
        {
            spawnPosition = new Vector2(-1 * tilemap.size.x / 2 + 1, 0);
        }
        else if (side == EnemyMovement.Side.Top)
        {
            spawnPosition = new Vector2(0, -1 * tilemap.size.y / 2 + 1);
        }
        else if (side == EnemyMovement.Side.Right)
        {
            spawnPosition = new Vector2(tilemap.size.x / 2 - 1, 0);
        }
        else
        {
            spawnPosition = new Vector2(0, tilemap.size.y / 2 - 1);
        }
        

        // spawn the enemy
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().side = side;
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
