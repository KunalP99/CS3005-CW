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

    [HideInInspector] public bool weaponPickedUp = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) /*&& weaponPickedUp == true*/)
        {
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
            Destroy(blueSword);
            weaponPickedUp = true;
        }
    }

}
