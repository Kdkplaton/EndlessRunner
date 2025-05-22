using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour, Collidable
{

    void Start()
    {
    }

    public void Activate()
    {
        gameObject.SetActive(false);
    }
}
