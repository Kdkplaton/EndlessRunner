using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{

    void Start()
    {

    }

    public void EndGame()
    {
        new WaitForSeconds(1f);

        gameObject.SetActive(true);

        Debug.Log("Btn Clicked!");
    }

}
