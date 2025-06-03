using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineCamera : MonoBehaviour
{
    [SerializeField] Runner runner;
    [SerializeField] CinemachineVirtualCamera virtualCam;
    [SerializeField] Animator cameraAnimator;

    public void OnEnable()
    {
        State.Subscribe(Condition.FINISH, EndCamera);
    }

    public void EndCamera()
    {
        virtualCam.Follow = null;
        virtualCam.LookAt = runner.transform;
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.FINISH, EndCamera);
    }
}
