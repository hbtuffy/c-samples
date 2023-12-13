using UnityEngine;

public class ladderClimbing : MonoBehaviour
{

    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;
    private bool climbQuestion = false;


    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private Animator myAnimation;
    [SerializeField] private GameObject myClimbQuestion;

    // Update is called once per frame
    void Update()
    {
        //apply vertical power to climb on the ladder
        if (climbQuestion && myClimbQuestion == null)
        {
            vertical = Input.GetAxis("Vertical");
        }
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }
    private void FixedUpdate()
    {
        //check if the character is climbing
        if (isClimbing)
        {
            myRigidbody.gravityScale = 0f;
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, vertical * speed);
            myAnimation.SetBool("climb", true);

        }
        else
        {
            myRigidbody.gravityScale = 2f;
            myAnimation.SetBool("climb", false);

        }

    }

    //set bool when trigger the ladder
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("ladder"))
        {
            isLadder = true;
            climbQuestion = true;

        }
       


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLadder = false;
        isClimbing = false;
    }
}
