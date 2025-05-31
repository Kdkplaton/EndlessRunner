using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startBtn;
    [SerializeField] GameObject endBtn;

    public void OnEnable()
    {

    }

    public void OnDisable()
    {

    }

    public void EnableEndBtn()
    {
        new WaitForSeconds(1f);
        endBtn.SetActive(true);
        Debug.Log("EndBtn Enabled!");
    }

    public void Execute()
    {
        State.Publish(Condition.START);

        Debug.Log("Excute!");
    }
    public void Finish()
    {
        State.Publish(Condition.FINISH);
        EnableEndBtn();
        Debug.Log("Finish!");
    }
    public void Resume()
    {
        State.Publish(Condition.RESUME);

        Debug.Log("Resume!");
    }

    

}
