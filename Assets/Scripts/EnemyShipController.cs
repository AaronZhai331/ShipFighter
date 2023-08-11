using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

enum shipDirection
{
    Horizontal,
    Vertical
}

public class EnemyShipController : MonoBehaviour
{
    public GameObject[] enemyShips;
    public int spawnCount=4; // the spawn position could spawn quantity every time 
    public int maxSpawnIntervalTime=5; //
    private float timer = 0;
    public float interval = 2f;
    private int wave = 1;
    [Header("ShotShipPosition")]
//  we need to building four Empties objects in every direction
    public Transform[] leftTF;

    public Transform[] rightTF;

    public Transform[] topTF;

    public Transform[] bottomTF;
    private Transform APos;
    private Transform BPos;

    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnShip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnShip();
            }
            timer = 0;
            interval = Random.Range(0, maxSpawnIntervalTime);
        }
//control wave change
        if (GameManager.Instance.score > 20*wave)
        {
            wave++;
            spawnCount++;

            if (maxSpawnIntervalTime <= 3)
            {
                maxSpawnIntervalTime = 3;
            }
            else
            {
                maxSpawnIntervalTime--;
            }
            
        }

    }
/// <summary>
/// spawn a random ship and transmit APos and BPos to ship
/// </summary>
    void SpawnShip()
    {
        int randomIndex = Random.Range(0, enemyShips.Length);
        FlyingShip();
        //todo get the initial position of spawned ship
        GameObject go = Instantiate(enemyShips[randomIndex],APos.position,Quaternion.identity);
        go.name = enemyShips[randomIndex].name;
        go.AddComponent<EnemyFlyingShip>();
        go.GetComponent<EnemyFlyingShip>().BPos = BPos;

    }
/// <summary>
/// get the direction randomly and set the A position and B position for transfer
/// </summary>
    void FlyingShip()
    {
        //choose a value of Direction randomly
        shipDirection[] values = (shipDirection[])Enum.GetValues(typeof(shipDirection));
        shipDirection randomDirection = values[Random.Range(0, values.Length)];
        switch (randomDirection)
        {
            case shipDirection.Horizontal:
                setABPos(leftTF, rightTF);
                break;
            case shipDirection.Vertical:
                setABPos(topTF, bottomTF);
                break;
        }
    }

    /// <summary>
    /// set direction from A to B or B to A randomly
    /// </summary>
    private void setABPos(Transform[] A, Transform[] B)
    {
        int aPos = Random.Range(0, 2);
        if (aPos == 0)
        {
            APos = A[Random.Range(0, A.Length)];
            BPos = B[Random.Range(0, B.Length)];
        }
        else
        {
            APos = B[Random.Range(0, B.Length)];
            BPos = A[Random.Range(0, A.Length)];
        }
    }
//create ships after specific time
    IEnumerator RandomSpawn(int customTime)
    {
        yield return new WaitForSeconds(customTime);
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnShip();
        }
    }
}