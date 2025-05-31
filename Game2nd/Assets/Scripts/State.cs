using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Condition
{
    START,
    FINISH,
    RESUME
}

// 이벤트버스 구조 - 클래스 State
public static class State
{
    private static Dictionary<Condition, UnityEvent> dictionary = new Dictionary<Condition, UnityEvent>();

    static Action start;
    static Action finish;
    static Action resume;

    public static void Subscribe(Condition condition, Action unityAction)
    {
        
        switch(condition)
        {
            case Condition.START:
                start += unityAction;
                /*for(int i = 0; i < start.GetInvocationList().Length; i++)
                {
                    Delegate[] handlers = start.GetInvocationList();
                    
                    foreach(var handler in handlers)
                    {
                        Debug.Log("test1:" + handler.Method.Name);
                    }
                }*/
                break;
            case Condition.FINISH:
                finish += unityAction;
                break;
            case Condition.RESUME:
                resume += unityAction;
                break;
        }

    }

    public static void UnSubscribe(Condition condition, Action unityAction)
    {
        switch (condition)
        {
            case Condition.START:
                start -= unityAction;
                break;
            case Condition.FINISH:
                finish -= unityAction;
                break;
            case Condition.RESUME:
                resume -= unityAction;
                break;
        }
    }

    public static void Publish(Condition condition)
    {
        // null이 아닌 경우 실행
        switch (condition)
        {
            case Condition.START:
                start?.Invoke();
                break;
            case Condition.FINISH:
                finish?.Invoke();
                break;
            case Condition.RESUME:
                resume?.Invoke();
                break;
        }
    }


}

