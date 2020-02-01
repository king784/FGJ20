using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D Controller;
    public float movespeed = 40f;

    float horizontalMove;
    bool jump = false;
    bool isMoving = false;
    private bool playDust;

    private void Start()
    {
        Controller = gameObject.GetComponent<CharacterController2D>();
    }
    void Update()
    {
        //move
        horizontalMove = Input.GetAxisRaw("Horizontal") * movespeed;

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Controller.Rigidbody2D.velocity.magnitude > 0f)
        {
            isMoving = true;
        }
        if (Controller.Rigidbody2D.velocity.magnitude > 0.1f)
        {
            playDust = true;
        }

    }

    private void FixedUpdate()
    {
        Controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
