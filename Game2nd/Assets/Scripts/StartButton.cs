using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] bool Touch;
    Button startBtn;
    Runner runner;
    RoadManager roadManager;
    Camera mainCam;
    ObstacleManager obstacleManager;

    // Start is called before the first frame update
    void Start()
    {
        Touch = false;
        startBtn = GameObject.Find("StartButton").GetComponent<Button>();
        runner = GameObject.Find("Runner").GetComponent<Runner>();
        roadManager = GameObject.Find("RoadManager").GetComponent<RoadManager>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        obstacleManager = GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>();

        if (startBtn != null)
        {
            startBtn.onClick.AddListener(OnStart);
            startBtn.onClick.AddListener(runner.StartRunner);
            startBtn.onClick.AddListener(roadManager.StartRoad);
            startBtn.onClick.AddListener(mainCam.StartCamera);
            startBtn.onClick.AddListener(obstacleManager.StartObstacleManager);
        }
    }

    public void OnStart()
    {
        if (Touch == false)
        {
            gameObject.SetActive(false);
            Touch = true;

            Debug.Log("Btn Clicked!");
        }
    }
}
