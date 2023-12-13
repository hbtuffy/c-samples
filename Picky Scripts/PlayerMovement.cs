using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float jumpForce =10f;
    [SerializeField]
    private float walkSpeed = 10f;
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private AudioSource jumpAudio;

    private float walkDirection;
 

    private enum MovementState {idle,run,jump,fall }
    

    private Rigidbody2D myRigidbody;    
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;
    private CapsuleCollider2D myCapsuleCollider2D;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerJump();
        playerWalk();
        updateAnimation();
        
    }

    void playerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,jumpForce);
            jumpAudio.Play();
        }
    }

    void playerWalk()
    {
        walkDirection = Input.GetAxisRaw("Horizontal");
        myRigidbody.velocity = new Vector2(walkDirection * walkSpeed, myRigidbody.velocity.y);
        
    }
    void updateAnimation()
    {
        
        MovementState state;
        if (walkDirection < 0)
        {
            mySpriteRenderer.flipX = true;
            state = MovementState.run;
        }
        else if (walkDirection > 0)
        {
            mySpriteRenderer.flipX = false;
            state = MovementState.run;
        }
        else
        {
            state = MovementState.idle;

        }
        
        if (myRigidbody.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if(myRigidbody.velocity.y<-0.1f)
        {
            state = MovementState.fall;
        }
        myAnimator.SetInteger("animationState", (int)state);
    }
    private bool isGrounded()
    {
        bool groundCheck = Physics2D.BoxCast(myCapsuleCollider2D.bounds.center, myCapsuleCollider2D.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
        
        return groundCheck;
    }
}
