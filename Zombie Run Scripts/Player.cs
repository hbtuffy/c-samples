using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    [SerializeField]
    private AudioSource jumpSound;
   

    private float movementX;

    private Rigidbody2D myBody;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;


    private string walkAnimation = "Walk";
    private string jumpAnimation = "Jump";
    private bool isGround;
    private string groundTag = "ground";
    private string enemyTag = "monster";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Start()
    {
        
    }
    void FixedUpdate()
    {
        
    }

    void Update()
    {
        playerMovement();
        playerAnimation();
        playerJump();
        jumpAnimating();
    }

    void playerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime*moveForce;
        
    }
    void playerAnimation()
    {
        if(movementX > 0f)
        {
            myAnimator.SetBool(walkAnimation, true);
            mySpriteRenderer.flipX = false;
        }
        else if (movementX < 0f)
        {
            myAnimator.SetBool(walkAnimation, true);
            mySpriteRenderer.flipX = true;
        }
        else { myAnimator.SetBool(walkAnimation, false); }
    }

    void playerJump()
    {
        if (Input.GetButtonDown("Jump") && isGround) {
            isGround = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpSound.Play();
        }
        



    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag(enemyTag))
        {
            
            Destroy(gameObject);
                               }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            
            Destroy(gameObject);
             
        }
    }

    private void jumpAnimating()
    {
        if (!isGround)
        {
            myAnimator.SetBool(jumpAnimation, true);
        }
        else { myAnimator.SetBool(jumpAnimation, false); }
    }
}
