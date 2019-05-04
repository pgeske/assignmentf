using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public bool vertical = true;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        if (vertical)
        {
            direction = new Vector2(0, speed);
        }
        else
        {
            direction = new Vector2(speed, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.rb.velocity = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        direction = -1 * direction;
    }
}