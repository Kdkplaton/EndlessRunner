using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] GameObject borderZone;
    Collider border;

    void Start()
    {
        border = borderZone.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        Collidable collidable = other.GetComponent<Collidable>();

        if(collidable != null) { collidable.Activate(); }
    }
}
