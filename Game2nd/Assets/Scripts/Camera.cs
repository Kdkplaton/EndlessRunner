using Cinemachine;
using System.Collections;
using UnityEngine;

public class Camera : MonoBehaviour
{
    CinemachineVirtualCamera cinemachineCam;
    Animator cameraAnimator;
    Runner runner;

    void Start()
    {
        cinemachineCam = GetComponent<CinemachineVirtualCamera>();
        cameraAnimator = GetComponent<Animator>();
        runner = GameObject.Find("Runner").GetComponent<Runner>();
    }

    public void OnEnable()
    {
        State.Subscribe(Condition.START, StartCamera);
        State.Subscribe(Condition.FINISH, EndCamera);
    }

    public void StartCamera()
    {
        cameraAnimator.SetTrigger("Touch");
        StartCoroutine(SetCamera());
        Debug.Log("Cam Started!");
    }

    IEnumerator SetCamera()
    {
        yield return CoroutineCache.WaitForSecond(1.1f);
        cinemachineCam.Follow = runner.transform;
        Debug.Log("Cam Follow Activated!");
    }

    public void EndCamera()
    {
        Vector3 endPos;
        endPos = transform.position;
        endPos.z -= 5f;         // offset값 고려하여 보정

        cinemachineCam.gameObject.transform.position = endPos;
        Debug.Log("endPos : " + endPos);
        cinemachineCam.Follow = null;
        cinemachineCam.LookAt = runner.transform;

        cameraAnimator.SetTrigger("Die");
        Debug.Log("Cam Ended!");
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, StartCamera);
        State.UnSubscribe(Condition.FINISH, EndCamera);
    }

}
