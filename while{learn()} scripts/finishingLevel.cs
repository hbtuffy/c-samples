using UnityEngine;
using UnityEngine.SceneManagement;

public class finishingLevel : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidboy;
    [SerializeField] Animator playerAnimator;
    [SerializeField] AudioSource finishingSound;

    //call the object on trigger of finishing level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        playerRigidboy.simulated = false;
        finishingSound.Play();
        Invoke("finishLevel", 3f);
        playerAnimator.SetTrigger("finish");

    }

    //call the end level when level is finished
    private void finishLevel()
    {
        SceneManager.LoadScene("end");
    }
}
