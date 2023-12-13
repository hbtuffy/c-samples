using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private AudioSource finishAudio;
    private bool levelCompleted;
    
    // Start is called before the first frame update
    void Start()
    {
        finishAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishAudio.Play();
            levelCompleted = true;
            Invoke("completeLevel", 2f);
            
        }
    }
    void completeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
