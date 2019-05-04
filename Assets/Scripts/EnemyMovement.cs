using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    public Side side;

    public enum Side { Left, Right, Top, Bottom };

    public static Side GetRandomSide()
    {
        List<Side> sides = new List<Side> { Side.Left, Side.Right, Side.Top, Side.Bottom };
        return sides[Random.Range(0, 3)];
    }


    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    
        // set velocity
        if (side == Side.Left || side == Side.Right)
        {
            this.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            direction = new Vector2(0, speed);
        }
        else
        {
            this.rb.constraints = RigidbodyConstraints2D.FreezePositionY;
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
        direction = -1 * direction;
    }
}