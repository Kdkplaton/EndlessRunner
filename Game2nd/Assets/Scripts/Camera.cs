using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Animator cameraAnimator;
    bool touch;

    void Start()
    {
        cameraAnimator = GetComponent<Animator>();
        touch = false;
    }

    public void StartCamera()
    {
        if (!touch)
        {
            cameraAnimator.SetTrigger("Touch");
            touch = true;

            Debug.Log("Cam Started!");
        }
    }

    public void EndCamera()
    {
        if (touch)
        {
            cameraAnimator.SetTrigger("Die");
            touch = false;

            Debug.Log("Cam Ended!");
        }
    }
}
