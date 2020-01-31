using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D Controller;
    public float movespeed = 40f;

    float horizontalMove;
    bool jump = false;
    void Update()
    {
        //move
        horizontalMove = Input.GetAxisRaw("Horizontal") * movespeed;

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        Controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
