using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        Vector2 vectorToPlayer = player.GetComponent<Rigidbody2D>().transform.position
            - transform.position;
        vectorToPlayer.Normalize();
        GetComponent<Rigidbody2D>().velocity = speed * (vectorToPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
