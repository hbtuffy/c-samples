using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class profMovements : MonoBehaviour
{
    //SPECIAL SCRIPT FOR PROF X MOVEMENTS

    private Rigidbody2D myRigidBody;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;
    private Collider2D myCollider;


    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private GameObject myJumpQuestion;
    [SerializeField] private GameObject myCrawlQuestion;
    [SerializeField] private float walkSpeed;
    [SerializeField] public int jumpForce;
    [SerializeField] private LayerMask jumpableGround;

    private float myMovement;
    private bool isCrawling = false;
    private bool jumpQuestion = false;
    private bool crawlQuestion = false;


    private void Awake()
    {
        //get player' components
        myRigidBody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

    }
 

    // Update is called once per frame
    void Update()
    {//lock the controls if dialogue is playing

        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        //call movement function in per frame
        playerWalk();
        playerJump(); 
    }

    //function for walking with the player
    private void playerWalk()
    {

        myMovement = Input.GetAxisRaw("Horizontal");
        myRigidBody.velocity = new Vector2(myMovement * walkSpeed, myRigidBody.velocity.y);

        // flip the character picture for facing the way you walk ( because of the sprite used in the project)
        if (myMovement < 0)
        {
            mySpriteRenderer.flipX = true;
            myAnimator.SetBool("walk", true);
        }
        else if (myMovement > 0)
        {
            mySpriteRenderer.flipX = false;
            myAnimator.SetBool("walk", true);
        }
        else
        {
            myAnimator.SetBool("walk", false);
        }

        //crawl when the user press left CTRL
        if (Input.GetKey(KeyCode.LeftControl) && crawlQuestion ==true && myCrawlQuestion == null)
        {
            myAnimator.SetBool("crawl", true);
            isCrawling = true;

        }
        else
        {
            myAnimator.SetBool("crawl", false);

            isCrawling = false;
        }

    }
    //set a function to jump 
    private void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !isCrawling && jumpQuestion && myJumpQuestion==null)

        {
            jumpSoundEffect.Play();
            myRigidBody.AddForce(new Vector2(myRigidBody.velocity.x, jumpForce), ForceMode2D.Impulse);

        }
    }

    //check if the player touching ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(myCollider.bounds.center, myCollider.bounds.size, 0f, Vector2.down, 0.02f, jumpableGround);
    }

    //check which question the prof x answers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("jumpQuestion"))
        {
            jumpQuestion = true;
        }
        if (collision.gameObject.CompareTag("crawlQuestion"))
        {
            crawlQuestion = true;
        }
    }




}
