using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.FlowStateWidget;

public class StartButton : MonoBehaviour
{
    [SerializeField] bool Touch;
    GameObject eventList;
    List<Action> funcList;
    Button startBtn;

    // Start is called before the first frame update
    void Start()
    {
        Touch = false;
        eventList = GameObject.Find("EventSystem");
        funcList = eventList.GetComponent<FunctionList>().getList();
        startBtn = GetComponent<Button>();

        if (startBtn != null)
        {
            // Start Button 클릭시 실행될 이벤트 등록
            foreach (Action func in funcList)
            {
                startBtn.onClick.AddListener(() => func());
            }
        }
    }

    public void OnStart()
    {
        if (Touch == false)
        {
            gameObject.SetActive(false);
            Touch = true;

            Debug.Log("Btn Clicked!");
        }
    }
}
