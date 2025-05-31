using System;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    [SerializeField] GameObject endBtn;
    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        endBtn = GameObject.Find("End Button");
        endBtn.GetComponent<Button>().onClick.AddListener(OnClickEnd);
        gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.RESUME, DisableEndBtn);
    }

    public void OnClickEnd()
    {
        Application.Quit();
        //gameManager.GetComponent<GameManager>().Resume();
    }

    public void DisableEndBtn()
    {
        endBtn.SetActive(false);
        Debug.Log("EndBtn Disabled!");
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.RESUME, DisableEndBtn);
    }

}
