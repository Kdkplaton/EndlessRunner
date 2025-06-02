using System;
using System.Collections;
using UnityEngine;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] float speed;
    [SerializeField] float accelerate;
    [SerializeField] float maxSpeed;
    int checker = 0, input;

    public float Speed { get { return speed; } }
    static SpeedManager instance;
    public static SpeedManager Instance { get { return instance; } }

    [SerializeField] TimeManager timeManager;

    override protected void Awake()
    {
        base.Awake();

        if(instance == null) { instance = this; }
    }

    private void Start()
    {
        speed = 30f;
        accelerate = 10f;
        maxSpeed = 120f;
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.START, StartSpeeder);
        State.Subscribe(Condition.FINISH, EndSpeeder);
    }

    void StartSpeeder()
    {
        StartCoroutine(setSpeed());
        Debug.Log("Speed Started!");
    }

    IEnumerator setSpeed()
    {
        while (true)
        {
            input = timeManager.Second;

            if (speed < maxSpeed)
            {
                if (checker == 55)
                { if (input == 0) { speed += accelerate; checker = input; } }
                else if (input - checker == 5) { speed += accelerate; checker = input; }
            }

            yield return null;
        }
    }

    void EndSpeeder()
    {
        StopAllCoroutines();
        speed = 30f;
        Debug.Log("Speed Ended!");
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, StartSpeeder);
        State.UnSubscribe(Condition.FINISH, EndSpeeder);
    }


}
