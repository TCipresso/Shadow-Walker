using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : MonoBehaviour
{

    public float speed;


    Vector3 pointA;
    Vector3 pointB;

    // Start is called before the first frame update
    void Start()
    {
        //Get current position then add 90 to its Y axis
        pointA = transform.eulerAngles + new Vector3(0f, 0f, 60f);

        //Get current position then substract -90 to its Y axis
        pointB = transform.eulerAngles + new Vector3(0f, 0f, -60f);
    }

    // Update is called once per frame
    void Update()
    {

        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.eulerAngles = Vector3.Lerp(pointA, pointB, time);
    }
}
