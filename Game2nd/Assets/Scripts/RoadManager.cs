using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roadList;
    [SerializeField] GameObject startButton;
    [SerializeField] float speed;
    [SerializeField] float offset;
    int roadNum;
    [SerializeField] float moveDist;
    bool touch;

    void Start()
    {
        speed = 30f;
        offset = 40f;
        roadNum = 0;
        moveDist = offset * roadList.Count;
        touch = false;
    }

    void Update()
    {
        if (touch)
        {
            for (int i = 0; i < roadList.Count; i++)
            { roadList[i].transform.Translate(speed * Vector3.back * Time.deltaTime); }
        }
    }

    public void initializePosition()
    {
        GameObject road = roadList[roadNum];
        
        float newZ = road.transform.position.z + moveDist;

        road.transform.position = new Vector3(0,0,newZ);

        Debug.Log("Road Initialized! roadNum: " + roadNum);
        if (roadNum == 4) { roadNum = 0; }
        else { roadNum += 1; }
    }

    public void StartRoad()
    { if (!touch) { touch = true; Debug.Log("Road Started!"); } }

    public void EndRoad()
    {
        if (touch) {
            StopAllCoroutines();
            touch = false; Debug.Log("Road Ended!");
        }
    }
}
