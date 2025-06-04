using Cinemachine;
using System.Collections;
using UnityEngine;

public class CinemachineCamera : MonoBehaviour
{
    [SerializeField] Runner runner;
    [SerializeField] CinemachineVirtualCamera virtualCam;
    [SerializeField] Animator cameraAnimator;

    public void OnEnable()
    {
        State.Subscribe(Condition.START, InitCamera);
        State.Subscribe(Condition.FINISH, EndCamera);
    }

    public void InitCamera()
    {
        virtualCam.LookAt = null;
        virtualCam.Follow = runner.transform;
    }

    public void EndCamera()
    {
        Vector3 endPos = virtualCam.transform.position;
        endPos.z -= 1f;

        virtualCam.Follow = null;
        virtualCam.transform.position = endPos;
        virtualCam.LookAt = runner.transform;
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, InitCamera);
        State.UnSubscribe(Condition.FINISH, EndCamera);
    }
}
