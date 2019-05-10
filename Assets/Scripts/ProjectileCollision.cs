﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterHealth>().Damage(1);
            Destroy(gameObject);
        }
        
        else if (collision.gameObject.tag == "Shield") {
            Destroy(gameObject);
        }
    }
}
