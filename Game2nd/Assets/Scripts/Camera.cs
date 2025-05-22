using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Animator cameraAnimator;
    bool Touch;

    void Start()
    {
        cameraAnimator = GetComponent<Animator>();
        Touch = false;
    }

    public void StartCamera()
    {
        if (!Touch)
        {
            cameraAnimator.SetTrigger("Touch");
            Touch = true;

            Debug.Log("Cam Started!");
        }
    }
}
