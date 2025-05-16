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
    [SerializeField] bool touch;
    Animator runnerAnimator;
    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        runnerAnimator = GetComponent<Animator>();
        touch = false;
        lineNow = RoadLine.MIDDLE;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard();
    }

    void Keyboard()
    {
        Vector3 targetPos = new Vector3(0,0,5);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(touch == false) {
                runnerAnimator.SetTrigger("Touch");
                touch = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lineNow != RoadLine.LEFT && isMoving == false) {
                if (lineNow == RoadLine.MIDDLE)
                { targetPos = new Vector3(-3, 0, 5); }
                if (lineNow == RoadLine.RIGHT)
                { targetPos = new Vector3(0, 0, 5); }
                
                StartCoroutine(MoveOverSeconds(targetPos, 0.8f));
                runnerAnimator.SetTrigger("moveLeft");
                lineNow--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lineNow != RoadLine.RIGHT && isMoving == false) {
                if (lineNow == RoadLine.MIDDLE)
                { targetPos = new Vector3(3, 0, 5); }
                if (lineNow == RoadLine.LEFT)
                { targetPos = new Vector3(0, 0, 5); }

                StartCoroutine(MoveOverSeconds(targetPos, 0.8f));
                runnerAnimator.SetTrigger("moveRight");
                lineNow++;
            }
        }

        IEnumerator MoveOverSeconds(Vector3 end, float duration)
        {
            isMoving = true;
            float elapsedTime = 0;
            Vector3 startPos = transform.position;

            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(startPos, end, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = end;
            transform.rotation = Quaternion.Euler(0,0,0);
            isMoving = false;
        }
    }
}
