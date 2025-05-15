using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] GameObject borderZone;
    Collider border;

    private void Start()
    {
        border = borderZone.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Collidable collidable = other.GetComponent<Collidable>();

        if(collidable != null) { collidable.Activate(); }
    }
}
