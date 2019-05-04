using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;

    void Attack()
    {
        Debug.Log("attacking");
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", 1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
