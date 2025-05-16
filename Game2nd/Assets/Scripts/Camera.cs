using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Animator cameraAnimator;
    bool Touch;

    // Start is called before the first frame update
    void Start()
    {
        cameraAnimator = GetComponent<Animator>();
        Touch = false;
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard();
    }

    void Keyboard()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Touch == false)
            {
                cameraAnimator.SetTrigger("Touch");
                Touch = true;
            }
        }
    }
}
