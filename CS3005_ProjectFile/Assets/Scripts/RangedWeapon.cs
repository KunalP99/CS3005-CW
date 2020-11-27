using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{

    public PlayerMovement player;

    public Transform shotPoint;
    public GameObject bullet;
    float rateOfFire = 0.5f;
    float nextFire = 0;

    [HideInInspector] public bool weaponPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && weaponPickedUp == true)
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
            }
            else if (player.faceRight == false)
            {
                Instantiate(bullet, shotPoint.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }


}
