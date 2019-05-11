using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public EnemyMovement enemyMovement;

    void Attack()
    {
        Vector2 projectileOffset;
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        if (enemyMovement.side == EnemyMovement.Side.Left)
        {
            projectileOffset = new Vector2(1, 0);
        }
        else if (enemyMovement.side == EnemyMovement.Side.Right)
        {
            projectileOffset = new Vector2(-1, 0);
        }
        else if (enemyMovement.side == EnemyMovement.Side.Top)
        {
            projectileOffset = new Vector2(0, 1);
        }
        else
        {
            projectileOffset = new Vector2(0, -1);
        }
        Instantiate(projectilePrefab, playerPosition + projectileOffset, Quaternion.identity);
        Invoke("Attack", Random.Range(3, 6));
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();

        Invoke("Attack", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
