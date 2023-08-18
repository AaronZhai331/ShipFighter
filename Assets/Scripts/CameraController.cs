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
        if (position.y >= 1.38f)
        {
            YAxis = 1.38f;
        }

        if (position.y <= -1.38f)
        {
            YAxis = -1.38f;
        }

        if (position.x <= -2.45f)
        {
            XAxis = -2.45f;
        }

        if (position.x >= 2.45f)
        {
            XAxis = 2.45f;
        }

        this.transform.position = new Vector3(XAxis, YAxis, -5);
    }
}