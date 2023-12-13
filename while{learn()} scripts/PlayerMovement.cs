using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;
    private Collider2D myCollider;

    private float myMovement;
    private bool isCrawling = false;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private float walkSpeed;
    [SerializeField] public int jumpForce;
    [SerializeField] private LayerMask jumpableGround;

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
    {
        //lock the controls if dialogue is playing
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
            mySpriteRenderer.flipX = false;
            myAnimator.SetBool("walk", true);
        }
        else if (myMovement > 0)
        {
            mySpriteRenderer.flipX = true;
            myAnimator.SetBool("walk", true);
        }
        else
        {
            myAnimator.SetBool("walk", false);
        }

        //crawl when the user press left CTRL

        if (Input.GetKey(KeyCode.LeftControl))
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


    //set a function to jump if touching ground and not crawling
    private void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !isCrawling)

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
}
