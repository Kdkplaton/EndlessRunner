using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    [SerializeField] GameObject endButton;
    Button endBtn;
    Transform endText;

    void Awake()
    {
        endButton = GameObject.Find("End Button");

        gameObject.SetActive(true);
        endText = transform.Find("EndText");
        endText.gameObject.SetActive(false);

        endBtn = GetComponent<Button>();
        endBtn.onClick.AddListener(OnClickEnd);

        State.Subscribe(Condition.FINISH, EnableEndBtn);
        endButton.SetActive(false);
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.RESUME, DisableEndBtn);
        State.UnSubscribe(Condition.FINISH, EnableEndBtn);
    }

    public void OnClickEnd()
    {
        Application.Quit();
    }
    public void EnableEndBtn()
    {
        endButton.SetActive(true);
        StartCoroutine(ActiveEndBtn());
    }

    IEnumerator ActiveEndBtn()
    {
        yield return CoroutineCache.WaitForSecond(1f);
        endText.gameObject.SetActive(true);
        Debug.Log("EndBtn Enabled!");
    }

    public void DisableEndBtn()
    {
        StopAllCoroutines();
        endText.gameObject.SetActive(false);
        endButton.SetActive(false);
        Debug.Log("EndBtn Disabled!");
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.RESUME, DisableEndBtn);
        State.Subscribe(Condition.FINISH, EnableEndBtn);
    }

}
