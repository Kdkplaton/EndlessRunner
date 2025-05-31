using System;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] Button startBtn;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startBtn.onClick.AddListener(OnClickStart);
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.START, DisableStartBtn);
        State.Subscribe(Condition.RESUME, EnableStartBtn);
    }

    public void OnClickStart()
    {
        gameManager.Execute();
    }

    public void DisableStartBtn()
    {
        gameObject.SetActive(false);
        Debug.Log("startBtn Disabled!");
    }

    public void EnableStartBtn()
    {
        gameObject.SetActive(true);
        Debug.Log("startBtn Enabled!");
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, DisableStartBtn);
        State.UnSubscribe(Condition.RESUME, EnableStartBtn);
    }
}
