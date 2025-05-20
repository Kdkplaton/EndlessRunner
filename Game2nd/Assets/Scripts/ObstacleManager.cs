using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacleList;
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] Transform parentPosition;
    [SerializeField] int obstacleCount;

    // Start is called before the first frame update
    void Start()
    {
        createObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createObstacles() {
        int randNum = 0;
        Transform tempPos = parentPosition;

        for(int i=0; i<5; i++)
        {
            randNum = Random.Range(0, obstacles.Count);
            obstacleList.Add(Instantiate(obstacles[randNum], parentPosition));
            obstacleList[i].transform.position += new Vector3(0, 0, 10+(10*i));
            obstacleList[i].SetActive(false);
        }
        
    }
}
