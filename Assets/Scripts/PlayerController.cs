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
    private Vector3 position;
    float XAxis = 0;

    float YAxis = 0;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        LimitPositionInBound();
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
    void LimitPositionInBound()
    {
        position = transform.position;
        XAxis = _camera.WorldToViewportPoint(position).x;
        YAxis = _camera.WorldToViewportPoint(position).y;
        if (_camera.WorldToViewportPoint(this.transform.position).y>1)
        {
            //Debug.Log(Camera.main.WorldToViewportPoint(this.transform.position).y);
            YAxis = 1;
        }

        if (_camera.WorldToViewportPoint(this.transform.position).y<0)
        {
            YAxis = 0;
        }

        if ( _camera.WorldToViewportPoint(this.transform.position).x<0)
        {
            XAxis = 0;
        }

        if (_camera.WorldToViewportPoint(this.transform.position).x>1)
        {
            XAxis = 1;
        }

        var currentWorldPoint = _camera.ViewportToWorldPoint(new Vector2(XAxis, YAxis));
        transform.position = new Vector3(currentWorldPoint.x, currentWorldPoint.y, 0);
    }

}
