using System.Collections;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1, MIDDLE = 0, RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine lineNow;
    [SerializeField] float moveX;
    bool isMoving;
    Animator runnerAnimator;
    //Rigidbody rigidbody;
    
    // float speed;

    void Start()
    {
        runnerAnimator = GetComponent<Animator>();
        //rigidbody = GetComponent<Rigidbody>();
        moveX = 3;
        lineNow = RoadLine.MIDDLE;
        isMoving = false;
        // speed = 40;
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.START, StartRunner);
        State.Subscribe(Condition.FINISH, EndRunner);
    }

    public void StartRunner()
    {
        runnerAnimator.SetTrigger("Touch");
        StartCoroutine(MoveRunner());
        Debug.Log("Runner Started!");
    }

    IEnumerator MoveRunner()
    {
        Vector3 targetPos = new Vector3(0, 0, 5);

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

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (lineNow != RoadLine.LEFT && isMoving == false)
                {
                    lineNow--;
                    targetPos = new Vector3((float)lineNow * moveX, 0, 5);

                    StartCoroutine(MoveOverSeconds(targetPos, 0.5f));
                    runnerAnimator.SetTrigger("moveLeft");
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (lineNow != RoadLine.RIGHT && isMoving == false)
                {
                    lineNow++;
                    targetPos = new Vector3((float)lineNow * moveX, 0, 5);

                    StartCoroutine(MoveOverSeconds(targetPos, 0.5f));
                    runnerAnimator.SetTrigger("moveRight");
                }
            }
            yield return null;
        }
    }

    public void EndRunner()
    {
        StopAllCoroutines();
        runnerAnimator.SetTrigger("Die");

        AudioManager.Instance.StopBGM();
        AudioManager.Instance.Listener("Conflict");

        lineNow = RoadLine.MIDDLE;      // 초기화
        Debug.Log("Runner Ended!");
    }

    public void Synchronize()
    {
        float speedNow = SpeedManager.Instance.Speed / SpeedManager.Instance.InitSpeed;
        if (speedNow < 4)
        {
            runnerAnimator.SetFloat("runSPD", speedNow);
            Debug.Log("Synchronize!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if(obstacle != null)
        {
            State.Publish(Condition.FINISH);
        }
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, StartRunner);
        State.UnSubscribe(Condition.FINISH, EndRunner);
    }
}
