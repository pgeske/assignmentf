﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private Vector2 preCollisionVelocity;
    private Rigidbody2D projectile;

    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        preCollisionVelocity = projectile.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterHealth>().Damage(1);
            Destroy(gameObject);
        }
    }
}
