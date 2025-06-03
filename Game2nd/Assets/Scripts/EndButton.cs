using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    Button endBtn;
    Transform endText;

    void Awake()
    {
        gameObject.SetActive(true);
        endText = transform.Find("EndText");
        endText.gameObject.SetActive(false);

        endBtn = GetComponent<Button>();
        State.Subscribe(Condition.FINISH, EnableEndBtn);
        endBtn.gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.RESUME, DisableEndBtn);
        State.UnSubscribe(Condition.FINISH, EnableEndBtn);
        StartCoroutine(ActiveEndBtn());
    }

    public void OnClickEnd()
    {
        //State.Publish(Condition.RESUME);
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void EnableEndBtn()
    {
        gameObject.SetActive(true);
        StartCoroutine(ActiveEndBtn());
    }

    IEnumerator ActiveEndBtn()
    {
        yield return CoroutineCache.WaitForSecond(1f);
        endText.gameObject.SetActive(true);
        endBtn.onClick.AddListener(OnClickEnd);
        Debug.Log("EndBtn Enabled!");
    }

    public void DisableEndBtn()
    {
        StopAllCoroutines();
        endText.gameObject.SetActive(false);
        gameObject.SetActive(false);
        endBtn.onClick.RemoveAllListeners();
        Debug.Log("EndBtn Disabled!");
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.RESUME, DisableEndBtn);
        State.Subscribe(Condition.FINISH, EnableEndBtn);
    }

}
