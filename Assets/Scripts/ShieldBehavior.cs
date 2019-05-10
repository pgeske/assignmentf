using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // get normalized vector from player to mouse
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 delta = mousePosition - playerPosition;
        delta.Normalize();
        transform.position = playerPosition + delta;

        // set rotation of shield
        float playerToMouseAngle = Mathf.Rad2Deg * Mathf.Atan(delta.y / delta.x);
        transform.rotation = Quaternion.Euler(0, 0, playerToMouseAngle);

    }
}
