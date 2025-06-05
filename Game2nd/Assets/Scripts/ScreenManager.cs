using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject scorePanel;
    [SerializeField] GameObject resultPanel;
    [SerializeField] GameObject startBtn;

    void OnEnable()
    {
        State.Subscribe(Condition.START, ExecuteInterface);
        State.Subscribe(Condition.FINISH, FinishInterface);
    }

    public void ExecuteInterface()
    {
        startBtn.SetActive(false);
    }

    public void FinishInterface()
    {
        scorePanel.SetActive(false);
        resultPanel.SetActive(true);
    }

    void OnDisable()
    {
        State.UnSubscribe(Condition.START, ExecuteInterface);
        State.UnSubscribe(Condition.FINISH, FinishInterface);
    }

}
