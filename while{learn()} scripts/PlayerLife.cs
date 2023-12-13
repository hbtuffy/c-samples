using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody2D myRigidbody;
    [SerializeField] private AudioSource dieSoundEffect;
    // Start is called before the first frame update
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //call the die() function if you touch a trap
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }
    //function for die() 
    private void Die()
    {

        myAnimator.SetTrigger("death");
        myRigidbody.bodyType = RigidbodyType2D.Static;
        dieSoundEffect.Play();

    }
    //load the the level from beginning if you touch a trap in the scene
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
