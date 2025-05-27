using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float accelerate;
    [SerializeField] float maxSpeed;
    int checker = 0, input;

    public float Speed { get { return speed; } }
    static SpeedManager instance;
    public static SpeedManager Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null) { instance = this; }
    }

    void Update()
    {
        input = GameObject.Find("TimeManager").GetComponent<TimeManager>().getSecond();
        
        if(speed < maxSpeed)
        {
            if (checker == 55)
            { if (input == 0) { speed += accelerate; checker = input; } }
            else if (input - checker == 5) { speed += accelerate; checker = input; }
        }

        
    }

    // 이게 필요하지 않음
    // public float getSpeed() { return speed; }

}
