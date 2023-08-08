using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

//define the direction of enemyShip flying
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyFlyingShip : MonoBehaviour
{
    
    public Transform BPos;
    public float maxFlyingSpeed=10f;
    private float flyingSpeed;
    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        //make the ship face the targetPosition
        transform.LookAt(this.BPos);
        flyingSpeed = Random.Range(2, maxFlyingSpeed);
    }

    /// <summary>
    /// fly from one  position to The other position
    /// </summary>
    /// <param name="APos">one direction position  </param>
    /// <param name="BPos">The other direction position</param>
    void A2BFly()
    {
        
        this.transform.position = Vector3.MoveTowards(this.transform.position, BPos.position, Time.deltaTime * flyingSpeed);
        
    }

    private void Update()
    {
        A2BFly();
        if (Vector3.Distance(transform.position, BPos.position) < 0.3)
        {
            Destroy(this.gameObject);
        }
    }
}