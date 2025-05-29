using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public void Execute()
    {
        {
            GameObject.Find("Start Button").GetComponent<StartButton>().OnStart();
            GameObject.Find("Runner").GetComponent<Runner>().StartRunner();
            GameObject.Find("RoadManager").GetComponent<RoadManager>().StartRoad();
            GameObject.Find("Virtual Camera").GetComponent<Camera>().StartCamera();
            GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>().StartObstacleManager();
            GameObject.Find("TimeManager").GetComponent<TimeManager>().StartTimer();
        }

        Debug.Log("Excute!");
    }

    //public void Finish()
    //{

    //}
    
    public void Resume()
    {
        Debug.Log("Resume!");
    }

}
