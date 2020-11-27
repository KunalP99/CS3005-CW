using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public float time;

    void Awake()
    {
        Destroy(gameObject, time);
    }
}
