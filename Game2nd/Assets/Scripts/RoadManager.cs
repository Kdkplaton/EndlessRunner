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

    private void Start()
    {
        setSpeed();
        offset = 40f;
        roadNum = 0;
        moveDist = offset * roadList.Count;
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.START, StartRoads);
        State.Subscribe(Condition.FINISH, EndRoads);
    }

    IEnumerator moveRoads()
    {
        while(true)
        {
            for (int i = 0; i < roadList.Count; i++)
            { roadList[i].transform.Translate(speed * Vector3.back * Time.deltaTime); }

            setSpeed();

            yield return null;
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

    public void StartRoads()
    {
        StartCoroutine(moveRoads());
        Debug.Log("Road Started!");
    }

    public void EndRoads()
    {
        StopAllCoroutines();
        setSpeed();
        Debug.Log("Road Ended!");
    }

    void setSpeed() { speed = SpeedManager.Instance.Speed; }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, StartRoads);
        State.UnSubscribe(Condition.FINISH, EndRoads);
    }

}
