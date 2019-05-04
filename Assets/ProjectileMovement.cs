using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public GameObject player;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody2D>().velocity = speed * (player.transform.position 
            - transform.position);
        Debug.Log("testing");
        Debug.Log(transform.position);
        Debug.Log(player.transform.position);
        Debug.Log(player.transform.position
            - transform.position);
        // GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        // Debug.Log(GetComponent<Rigidbody2D>().velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
