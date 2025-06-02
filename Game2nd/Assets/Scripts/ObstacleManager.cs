using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacleList;
    [SerializeField] List<GameObject> prefab;
    [SerializeField] Transform parentPos;
    [SerializeField] float speed;
    [SerializeField] int listCap;
    string temp;
    // 데이터 캐싱 : 비싼 연산 결과나 자주 사용되는 데이터를 임시 저장하고,
    //               필요할 때 다시 계산하지 않고 빠르게 가져와 사용하는 기술

    void Awake()
    {
        setSpeed();
        prefab.Add(Resources.Load<GameObject>("Barrier"));
        prefab.Add(Resources.Load<GameObject>("OilDrum"));
        prefab.Add(Resources.Load<GameObject>("TrafficCone"));
        obstacleList.Capacity = 20;
        listCap = obstacleList.Capacity;

        Debug.Log(listCap);
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.START, StartObstacles);
        State.Subscribe(Condition.FINISH, EndObstacles);
    }

    IEnumerator setObstacle()
    {
        while (true)
        {
            GameObject newObstacle;
            int found = -1, prefabNum, randX;
            
            prefabNum = Random.Range(0, prefab.Count);
            randX = Random.Range(-1, 2);

            if(prefabNum == 0) { temp = "Barrier"; }
            else if (prefabNum == 1) { temp = "OilDrum"; }
            else if (prefabNum == 2) { temp = "TrafficCone"; }

            for (int i = 0; i < obstacleList.Count; i++)
            {
                if (!obstacleList[i].activeSelf) {
                    if (obstacleList[i].name == temp) { found = i; break; }
                }
            }

            if (found != -1)        // 있으면 재사용
            {
                newObstacle = obstacleList[found];
                newObstacle.transform.position = new Vector3(randX * 3, 0, 180);
                newObstacle.SetActive(true);
            }
            else            // 없으면 생성
            {
                
                newObstacle = Instantiate(prefab[prefabNum], parentPos);
                newObstacle.name = newObstacle.name.Replace("(Clone)","");
                newObstacle.transform.position = new Vector3(randX * 3, 0, 180);
                newObstacle.AddComponent<Obstacle>();
                newObstacle.SetActive(true);
                obstacleList.Add(newObstacle);
            }

            yield return CoroutineCache.WaitForSecond(2.0f);
        }
    }

    IEnumerator moveObstacles()
    {
        while(true)
        {
            for (int i = 0; i < obstacleList.Count; i++)
            {
                if (!obstacleList[i].activeSelf) { continue; }
                obstacleList[i].transform.Translate(speed * Vector3.up * Time.deltaTime);
            }

            setSpeed();

            yield return null;
        }
    }

    // void Execute()
    void StartObstacles()
    {
        StartCoroutine(setObstacle());
        StartCoroutine(moveObstacles());
        Debug.Log("Obstacles Started!");
    }

    public void EndObstacles()
    {
        StopAllCoroutines();
        Debug.Log("Obstacles Ended!");
    }

    void setSpeed() { speed = SpeedManager.Instance.Speed; }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, StartObstacles);
        State.UnSubscribe(Condition.FINISH, EndObstacles);
    }
}
