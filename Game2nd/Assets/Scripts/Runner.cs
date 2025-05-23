using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1, MIDDLE = 0, RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine lineNow;
    [SerializeField] float moveX;
    bool touch, isMoving;
    Animator runnerAnimator;
    Collider collider;

    RoadManager roadManager;
    ObstacleManager obstacleManager;
    TimeManager timeManager;

    void Start()
    {
        runnerAnimator = GetComponent<Animator>();
        collider = GameObject.Find("Runner").GetComponent<Collider>();
        moveX = 3;
        touch = false;
        lineNow = RoadLine.MIDDLE;
        isMoving = false;

        roadManager = GameObject.Find("RoadManager").GetComponent<RoadManager>();
        obstacleManager = GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>();
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard();
    }

    public void StartRunner()
    {
        if (!touch)
        {
            runnerAnimator.SetTrigger("Touch");
            touch = true;

            Debug.Log("Runner Started!");
        }
    }

    void Keyboard()
    {
        Vector3 targetPos = new Vector3(0,0,5);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lineNow != RoadLine.LEFT && isMoving == false && touch == true) {
                lineNow--;
                targetPos = new Vector3((float)lineNow * moveX, 0, 5);
                
                StartCoroutine(MoveOverSeconds(targetPos, 0.7f));
                runnerAnimator.SetTrigger("moveLeft");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lineNow != RoadLine.RIGHT && isMoving == false && touch == true) {
                lineNow++;
                targetPos = new Vector3((float)lineNow * moveX, 0, 5);

                StartCoroutine(MoveOverSeconds(targetPos, 0.7f));
                runnerAnimator.SetTrigger("moveRight");
            }
        }

        IEnumerator MoveOverSeconds(Vector3 endPos, float duration)
        {
            isMoving = true;
            float elapsedTime = 0f;
            Vector3 startPos = transform.position;

            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = endPos;
            // transform.rotation = Quaternion.Euler(0,0,0);   // 방향 고정
            isMoving = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Runner runner = GetComponent<Runner>();
        runner.transform.position += new Vector3(0,0,-1);

        runnerAnimator.SetTrigger("Die");
        roadManager.EndRoad();
        obstacleManager.EndObstacleManager();
        timeManager.EndTimer();
    }
}
