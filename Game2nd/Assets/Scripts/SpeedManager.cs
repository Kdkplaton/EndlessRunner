using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] float initSpeed;
    [SerializeField] float speed;
    [SerializeField] float accelerate;
    [SerializeField] float maxSpeed;
    int checker = 0, input;

    public float InitSpeed { get { return initSpeed; } }
    public float Speed { get { return speed; } }
    static SpeedManager instance;
    public static SpeedManager Instance { get { return instance; } }

    override protected void Awake()
    {
        base.Awake();

        if(instance == null) { instance = this; }
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        State.Subscribe(Condition.START, StartSpeeder);
        State.Subscribe(Condition.FINISH, EndSpeeder);
    }

    // Execute()
    void StartSpeeder()
    {
        StartCoroutine(setSpeed());
        Debug.Log("Speed Started!");
    }

    IEnumerator setSpeed()
    {
        while (true)
        {
            yield return CoroutineCache.WaitForSecond(1f);

            if(speed < maxSpeed) { speed += accelerate; }
        }
    }

    // Release()
    void EndSpeeder()
    {
        StopAllCoroutines();
        Debug.Log("Speed Ended!");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    { speed = 50f; }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, StartSpeeder);
        State.UnSubscribe(Condition.FINISH, EndSpeeder);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


}
