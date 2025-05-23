using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionList : MonoBehaviour
{
    List<Action> functionList;

    private void Start()
    {
        functionList = new List<Action>
        {
            () => GameObject.Find("Start Button").GetComponent<StartButton>().OnStart(),
            () => GameObject.Find("Runner").GetComponent<Runner>().StartRunner(),
            () => GameObject.Find("RoadManager").GetComponent<RoadManager>().StartRoad(),
            () => GameObject.Find("Main Camera").GetComponent<Camera>().StartCamera(),
            () => GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>().StartObstacleManager(),
            () => GameObject.Find("TimeManager").GetComponent<TimeManager>().StartTimer()
        };
    }

    public List<Action> getList() { return functionList; }
}
