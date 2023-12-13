using UnityEngine;

public class TrampolineThrower : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private int addForce;

    private Animator myAnimation;


    private void Awake()
    {
        myAnimation = GetComponent<Animator>();

    }
    //call the throwplayer with delay when you touch the collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("throwPlayer", 1f);
            myAnimation.SetBool("throw", false);
        }
    }

    //function to add force on player for throwing up
    private void throwPlayer()
    {
        myAnimation.SetBool("throw", true);
        player.AddForce(new Vector2(player.velocity.x, addForce), ForceMode2D.Impulse);

    }

}
