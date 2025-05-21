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
    float speed;
    bool touch;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15f;
        touch = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            touch = true;
            StartCoroutine(addObstacle());
        }

        if (touch)
        {
            for (int i = 0; i < obstacleList.Count; i++)
            { obstacleList[i].transform.Translate(speed * Vector3.up * Time.deltaTime); }
        }
    }

    void createObstacles() {
        int randNum, randX;

        randNum = Random.Range(0, prefab.Count);
        randX = Random.Range(-1, 2);
        GameObject newObstacle = Instantiate(prefab[randNum], parentPos);
        newObstacle.transform.position += new Vector3(randX*3, 0, 130);
        newObstacle.AddComponent<Obstacle>();
        
        // newObstacle.SetActive(false);
        obstacleList.Add(newObstacle);
    }

    public void destroyObstacle()
    {
        Destroy(gameObject);
    }

    public IEnumerator addObstacle()
    {
        while (true)
        {
            createObstacles();
            yield return new WaitForSeconds(3f); // 1초 대기
        }
    }
}
