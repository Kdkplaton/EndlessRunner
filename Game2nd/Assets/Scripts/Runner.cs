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
    GameManager gameManager;
    [SerializeField] GameObject endBtn;

    // 러너가 스피드를 사용?
    float speed;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //endBtn = GameObject.Find("End Button");
        runnerAnimator = GetComponent<Animator>();
        moveX = 3;
        lineNow = RoadLine.MIDDLE;
        isMoving = false;
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.START, StartRunner);
        State.Subscribe(Condition.FINISH, EndRunner);
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard();
    }

    public void StartRunner()
    {
        runnerAnimator.SetTrigger("Touch");
        Debug.Log("Runner Started!");
    }

    void Keyboard()
    {
        Vector3 targetPos = new Vector3(0,0,5);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lineNow != RoadLine.LEFT && isMoving == false) {
                lineNow--;
                targetPos = new Vector3((float)lineNow * moveX, 0, 5);
                
                StartCoroutine(MoveOverSeconds(targetPos, 0.5f));
                runnerAnimator.SetTrigger("moveLeft");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lineNow != RoadLine.RIGHT && isMoving == false) {
                lineNow++;
                targetPos = new Vector3((float)lineNow * moveX, 0, 5);

                StartCoroutine(MoveOverSeconds(targetPos, 0.5f));
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

    public void EndRunner()
    {
        transform.position += new Vector3(0, 0, -0.5f);
        StopAllCoroutines();
        runnerAnimator.SetTrigger("Die");
        lineNow = RoadLine.MIDDLE;
        Debug.Log("Runner Ended!");
    }

    void OnTriggerEnter(Collider other)
    {
        gameManager.Finish();
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, StartRunner);
        State.UnSubscribe(Condition.FINISH, EndRunner);
    }
}
