using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] int minute, second, milsec;
    float timeflow;

    public int Second { get { return second; } }

    private void Start()
    {
        minute = 0;
        second = 0;
        milsec = 0;
        timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, milsec);
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.START, StartTimer);
        State.Subscribe(Condition.FINISH, EndTimer);
    }

    IEnumerator setTimer()
    {
        while (true)
        {
            timeflow += Time.deltaTime;
            minute = (int)(timeflow / 60);
            second = (int)(timeflow % 60);
            milsec = (int)(timeflow % 1 * 100);

            timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, milsec);
            
            yield return null;
        }
    }

    public void StartTimer()
    {
        StartCoroutine(setTimer());
        Debug.Log("Timer Started!");
    }

    public void EndTimer()
    {
        StopAllCoroutines();
        timeflow = 0f;
        Debug.Log("Timer Ended!");
    }

    public int getSecond() { return second; }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, StartTimer);
        State.UnSubscribe(Condition.FINISH, EndTimer);
    }
}
