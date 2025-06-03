using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour, Collidable
{

    void OnEnable()
    {
        State.Subscribe(Condition.FINISH, Release);
    }

    public void Activate()
    {
        gameObject.SetActive(false);
    }

    void Release()
    {
        Destroy(this);
    }

    void OnDisable()
    {
        State.UnSubscribe(Condition.FINISH, Release);
    }
}
