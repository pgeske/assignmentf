using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public int speed;

    Vector2 NoiseVector(float min, float max)
    {
        float xNoise = Random.Range(min, max);
        float yNoise = Random.Range(min, max);

        return new Vector2(
          Mathf.Sin(2 * Mathf.PI * xNoise / 360),
          Mathf.Sin(2 * Mathf.PI * yNoise / 360)
        );
    }


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        Vector2 vectorToPlayer = player.GetComponent<Rigidbody2D>().transform.position
            - transform.position;
        vectorToPlayer.Normalize();
        vectorToPlayer += NoiseVector(0, 10);
        GetComponent<Rigidbody2D>().velocity = speed * (vectorToPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
