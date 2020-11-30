using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public PlayerMovement playerScript;
    public Animator anim;
    public Slider healthBar;

    public int maxHealth = 100;

    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;
    }

    void FaceLeft()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    void FaceRight()
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            death();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.kbCounter = playerScript.kbDuration;

            // Checks if the position of player is on the left which will set kbRight to true in the playermovement script
            if (other.transform.position.x < transform.position.x)
            {
                playerScript.kbRight = true;
            }
            else
            {
                playerScript.kbRight = false;
            }
        }
    }

    void death()
    {
        anim.SetTrigger("dead");
    }
}
