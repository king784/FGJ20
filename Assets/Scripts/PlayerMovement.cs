using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D Controller;
    public ParticleSystem DustParticle;
    public float movespeed = 40f;

    Animator anim;
    float horizontalMove;
    bool jump = false;
    bool isMoving = false;
    private bool playDust = false;

    private void Start()
    {
        Controller = gameObject.GetComponent<CharacterController2D>();
        DustParticle.Stop();
        anim = GetComponent<Animator>();
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

        //velocity is more than 0, character is moving
        if (Controller.Rigidbody2D.velocity.magnitude > 0f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
            
        }

        if (Controller.Rigidbody2D.velocity.magnitude > 0.1f)//play dust if magnitude is more than 0.1
        {
            playDust = true;
            //play moving animation
            anim.SetBool("moving", true);
        }
        else if (playDust && Controller.Rigidbody2D.velocity.magnitude < 0.1f)//don't play dust if magnitude is less than .1f
        {
            playDust = false;
            anim.SetBool("moving", false);
        }

        if (DustParticle.isStopped && playDust)
        {
            DustParticle.Play();
        }
        if (DustParticle.isPlaying && !playDust)
        {
            DustParticle.Stop();
        }

        if (!Controller.Grounded)
        {//play jump animation
            anim.SetBool("inAir", true);
        }
        else
        {
            anim.SetBool("inAir", false);
        }

    }

    private void FixedUpdate()
    {
        Controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
