using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] bool Touch;
    Button startBtn;
    FunctionList funcList;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        startBtn = GetComponent<Button>();
        funcList = GameObject.Find("EventSystem").GetComponent<FunctionList>();



        Touch = false;
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
