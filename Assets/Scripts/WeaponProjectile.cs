using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // set initial velocity towards the mouse
        Vector2 projectilePosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 toMouseVector = mousePosition - projectilePosition;
        toMouseVector.Normalize();

        rb.velocity = toMouseVector * speed;

        // set angle of projectile
        float playerToMouseAngle = Mathf.Rad2Deg * Mathf.Atan(toMouseVector.y / toMouseVector.x);
        if (toMouseVector.x < 0)
        {
            playerToMouseAngle = 180 + playerToMouseAngle;
        }
        transform.rotation = Quaternion.Euler(0, 0, playerToMouseAngle);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
