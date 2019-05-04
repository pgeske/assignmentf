using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private bool vertical = true;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        if (vertical)
        {
            this.rb.velocity = new Vector2(0, speed);
        }
        else
        {
            this.rb.velocity = new Vector2(speed, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.rb.velocity = new Vector2(
            -1 * this.rb.velocity.x,
            -1 * this.rb.velocity.y
         );
    }
}