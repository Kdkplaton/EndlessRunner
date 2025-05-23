using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] int minute, second, milsec;
    float time;
    bool touch, start;

    // sting.Format()  |  목표 포맷  >>  00 : 00 : 00
    // {0:D2} : {1:D2} : {2:D2}  << 아마 이것이면 될것

    void Start()
    {
        minute = 0;
        second = 0;
        milsec = 0;
        timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, milsec);
        time = 0f;
        touch = false;
        start = false;
    }

    void Update()
    {
        if(touch)
        {
            if(!start)
            {
                StartCoroutine(setTimer());
                start = true;
            }
        }
    }

    IEnumerator setTimer()
    {
        while (true)
        {
            time += Time.deltaTime;
            minute = (int)(time / 60);
            second = (int)(time % 60);
            milsec = (int)(time % 1 * 100);

            timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, milsec);

            if (time % 0.05 == 0) { Debug.Log("Times from Game Start : " + timeText.text); }
            
            yield return null;
        }
    }

    public void StartTimer()
    {
        if(!touch) { touch = true; Debug.Log("Timer Started!"); }
    }

    public void EndTimer()
    {
        if (touch) {
            StopAllCoroutines(); 
            touch = false; Debug.Log("Timer Started!");
        }
    }
}
