using Cinemachine;
using System.Collections;
using UnityEngine;

public class Camera : MonoBehaviour
{
    CinemachineVirtualCamera virtualCam;
    Animator cameraAnimator;
    bool touch;

    void Start()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        virtualCam.Follow = null;
        cameraAnimator = GetComponent<Animator>();
        touch = false;
    }

    void Update()
    {
        if (touch) { StartCoroutine(SetCamera()); }
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

    IEnumerator SetCamera()
    {
        yield return CoroutineCache.WaitForSecond(1f);

        virtualCam.Follow = GameObject.Find("Runner").transform;
        
        Debug.Log("Cam Follow Activated!");
    }

    public void EndCamera()
    {
        Vector3 endPos;

        if (touch)
        {
            endPos = virtualCam.transform.position;
            StopAllCoroutines();
            virtualCam.transform.position = endPos;
            virtualCam.Follow = null;
            
            cameraAnimator.SetTrigger("Die");
            touch = false;

            Debug.Log("Cam Ended!");
        }
    }
}
