using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{

    public PlayerMovement player;
    public Animator anim;

    public Transform shotPoint;
    public GameObject bullet;
    float rateOfFire = 0.5f;
    float nextFire = 0;

    public GameObject blueSword;
    public GameObject tutorialText;

    public AudioSource swordPickedUp;
    public AudioSource rangedWeaponShot;

    [HideInInspector] public bool weaponPickedUp = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && weaponPickedUp == true)
        {
            rangedWeaponShot.Play();
            Fire();
        }
    }

    void Fire()
    {
        if (Time.time > nextFire)
        {
            // Cooldown between shots
            nextFire = Time.time + rateOfFire;

            if (player.faceRight == true)
            {
                // Spawning a projectile at the shotPoint position with no rotation 
                Instantiate(bullet, shotPoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                anim.SetTrigger("Ranged");
            }
            else if (player.faceRight == false)
            {
                Instantiate(bullet, shotPoint.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                anim.SetTrigger("Ranged");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BlueSword")
        {
            tutorialText.SetActive(true);
            swordPickedUp.Play();
            Destroy(blueSword);
            weaponPickedUp = true;
        }
        else if (other.gameObject.tag == "RangedTrigger")
        {
            weaponPickedUp = true;
        }
    }

}
