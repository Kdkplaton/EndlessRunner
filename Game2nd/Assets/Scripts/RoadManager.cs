using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roadList;
    [SerializeField] GameObject startButton;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < roadList.Count; i++)
        {
           roadList[i].transform.Translate(speed * Vector3.back * Time.deltaTime);
        }
        
    }
}
