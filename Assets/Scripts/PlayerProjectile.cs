using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Wait(2f, () => { Destroy(gameObject); });
    }


    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "EnemyShip")
        {
            Destroy(gameObject);
        }

    }


}
