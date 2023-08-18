using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject playerShip;

    private Transform targetTF;

    private Vector3 position;
    float XAxis = 0;

    float YAxis = 0;

    // Start is called before the first frame update
    void Awake()
    {
        position = playerShip.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position = playerShip.transform.position;
        XAxis = position.x;
        YAxis = position.y;
        if (position.y >= 2.65f)
        {
            YAxis = 2.65f;
        }

        if (position.y <= -2.65f)
        {
            YAxis = -2.65f;
        }

        if (position.x <= -4.7f)
        {
            XAxis = -4.7f;
        }

        if (position.x >= 4.7f)
        {
            XAxis = 4.7f;
        }

        this.transform.position = new Vector3(XAxis, YAxis, -5);
    }
}