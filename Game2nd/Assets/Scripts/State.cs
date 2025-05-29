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

public static class State
{
    private static Dictionary<Condition, UnityEvent> dictionary = new Dictionary<Condition, UnityEvent>();

    static Action start;
    static Action finish;
    static Action resume;

    public static void Subscribe(Condition condition, UnityAction unityAction)
    {
        UnityEvent unityEvent = new UnityEvent();

        unityEvent.AddListener(unityAction);

        switch(condition)
        {
            case Condition.START:
                dictionary.Add(Condition.START, unityEvent);
                break;
            case Condition.FINISH:
                dictionary.Add(Condition.FINISH, unityEvent);
                break;
            case Condition.RESUME:
                dictionary.Add(Condition.RESUME, unityEvent);
                break;
        }

    }

    public static void Unsubscribe(Condition condition, UnityAction unityAction)
    {

    }

    public static void Publish(Condition condition)
    {

    }


}

