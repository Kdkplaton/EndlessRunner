using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour, Collidable
{
    ObstacleManager obstacleM;
    [SerializeField] UnityEvent callback;

    void Start()
    {
        callback = new UnityEvent();
        obstacleM = FindObjectOfType<ObstacleManager>();

        if (obstacleM != null)
        { callback.AddListener(obstacleM.destroyObstacle); }
        else { Debug.Log("ObstacleManager 감지실패!"); }
    }

    public void Activate()
    {
        if (callback != null) { callback.Invoke(); }
    }
}
