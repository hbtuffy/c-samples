using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody2D myRigidbody;

    [SerializeField] private AudioSource dieAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            kill();
        }
    }

    private void kill()
    {
        dieAudio.Play();  
        myAnimator.SetTrigger("animationDeath");
        myRigidbody.bodyType = RigidbodyType2D.Static;
        
    }


    private void RestartLevel()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}
