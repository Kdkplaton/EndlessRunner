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
    //[SerializeField] Rigidbody rigidbody;
    [SerializeField] float moveX;
    bool touch, isMoving;
    Animator runnerAnimator;

    private void Awake()
    {
        //rigidbody = gameObject.GetComponent<Rigidbody>();
        runnerAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        moveX = 3;
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
