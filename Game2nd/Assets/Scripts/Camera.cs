using Cinemachine;
using System.Collections;
using UnityEngine;

public class Camera : MonoBehaviour
{
    CinemachineVirtualCamera cinemachineCam;
    Animator cameraAnimator;
    GameObject runner;

    void Start()
    {
        cinemachineCam = GetComponent<CinemachineVirtualCamera>();
        cinemachineCam.Follow = null;
        cameraAnimator = GetComponent<Animator>();
        runner = GameObject.Find("Runner");
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
        endPos.z -= 5f;
        Debug.Log("endPos1 : " + endPos);

        StopAllCoroutines();
        cinemachineCam.Follow = null;
        Debug.Log("endPos2 : " + endPos);
        transform.position = endPos;

        cameraAnimator.SetTrigger("Die");
        Debug.Log("Cam Ended!");
    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, StartCamera);
        State.UnSubscribe(Condition.FINISH, EndCamera);
    }

}
