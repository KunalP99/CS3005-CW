using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehaviour : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject continueText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.moveSpeed = 0;
            continueText.SetActive(true);
        }
    }
}
