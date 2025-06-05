using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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
