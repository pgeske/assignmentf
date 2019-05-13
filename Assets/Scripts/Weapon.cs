using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float cooldown;
    public GameObject cooldownIndicator;
    public GameObject weaponProjectilePrefab;
    public Sprite bowWithArrow;
    public Sprite bowWithoutArrow;
    private float timeStamp;
    private GameObject player;
    private SpriteRenderer weaponRenderer;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        player = transform.parent.gameObject;
        InvokeRepeating("Attack", 1.0f, 5.0f);
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    void Shoot()
    {
        // intantiate weapon projectile just in front of weapon
        Vector2 spawnPosition = (Vector2)transform.position + ToMouse(gameObject);
        Instantiate(weaponProjectilePrefab, spawnPosition, Quaternion.identity);
    }


    Vector2 ToMouse(GameObject source)
    {
        Vector2 sourcePosition = source.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 delta = mousePosition - sourcePosition;
        delta.Normalize();

        return delta;
    }

    private bool Ready()
    {
        return timeStamp <= Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        // toggle the arrow on the bow, depending on if the player shot the arrow
        if (!Ready())
        {
            weaponRenderer.sprite = bowWithoutArrow;
        }
        else
        {
            weaponRenderer.sprite = bowWithArrow;
        }

        // get vector from player to mouse
        Vector2 playerToMouse = ToMouse(player) * (float)1.3;
        transform.position = (Vector2)player.transform.position + playerToMouse;

        // set rotation of weapon
        float playerToMouseAngle = Mathf.Rad2Deg * Mathf.Atan(playerToMouse.y / playerToMouse.x);
        Debug.Log(playerToMouseAngle);

        // angles should always be positive
        if (playerToMouse.x < 0)
        {
            playerToMouseAngle = 180 + playerToMouseAngle;
        }
        
        transform.rotation = Quaternion.Euler(0, 0, playerToMouseAngle);

        // shoot weapon on left click
        if (Input.GetMouseButton(0))
        {
            if (Ready())
            {
                Shoot();
                timeStamp = Time.time + cooldown;
            }
        }

        // update cooldown text
        float remainingCooldown = Mathf.Ceil(timeStamp - Time.time);
        if (remainingCooldown > 0)
        {
            cooldownIndicator.GetComponent<UnityEngine.UI.Text>().text = remainingCooldown.ToString();
        } else
        {
            cooldownIndicator.GetComponent<UnityEngine.UI.Text>().text = "";
        }
    }
}
