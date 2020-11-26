using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerBehaviour : MonoBehaviour
{
    public Health healthScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            healthScript.health = healthScript.health - 3;
        }
    }

}
