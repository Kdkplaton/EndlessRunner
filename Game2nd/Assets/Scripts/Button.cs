using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool Touch;

    // Start is called before the first frame update
    void Start()
    {
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
                gameObject.SetActive(false);
                Touch = true;
            }
        }
    }
}
