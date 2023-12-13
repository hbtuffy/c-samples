using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionPopUp : MonoBehaviour
{
    [SerializeField] GameObject VisualImage;
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        VisualImage.SetActive(false);
    }

    private void Update()
    {
        //make the dialogue active/inactive
        if ( DialogueManager.GetInstance().dialogueIsPlaying)
        {

            VisualImage.SetActive(true);
        }
        else
        {
            VisualImage.SetActive(false);
        }
    }

    //check if player in range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    //check if player out range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }

    }
}
