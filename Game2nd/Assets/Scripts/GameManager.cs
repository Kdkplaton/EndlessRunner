using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startBtn;
    [SerializeField] GameObject endBtn;

    public void OnEnable()
    {
        //State.Subscribe(Condition.FINISH, EnableEndBtn);
    }

    public void OnDisable()
    {
        //State.UnSubscribe(Condition.FINISH, EnableEndBtn);
    }

    public void Execute()
    {
        State.Publish(Condition.START);

        Debug.Log("Excute!");
    }
    public void Finish()
    {
        State.Publish(Condition.FINISH);

        Debug.Log("Finish!");
    }
    public void Resume()
    {
        State.Publish(Condition.RESUME);

        Debug.Log("Resume!");
    }

    

}
