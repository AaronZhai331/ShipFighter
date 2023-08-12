using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MoveSpeed = 7;


    private Vector2 MoveDirection;


    private Vector2 MousePosition;



    public Rigidbody2D RB;

    public Camera Camera;

    public PlayerWeapon Weapon;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

     void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs ()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");

        MoveDirection = new Vector2(moveX, moveY).normalized;

        MousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButtonDown(0)) 
        {
            Weapon.Shoot();
        }
    }

    void Move()
    {
        RB.velocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed );

        Vector2 aimDirection = MousePosition - RB.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90F;
        RB.rotation = aimAngle;
    }

}
