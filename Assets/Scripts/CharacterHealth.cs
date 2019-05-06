using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    public int health;
    public GameObject healthIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthIndicator.GetComponent<UnityEngine.UI.Text>().text = "Health: " + health;

    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }

        // increase player speed when player has low health
        if (health == 1)
        {
            GameObject.Find("Player").GetComponent<CharacterMovement>().speed += 5;
        }
    }
}
