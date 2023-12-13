using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueTrigger : MonoBehaviour
{
    Transform tempTrans;
    private GameObject npcParent;
    private bool playerInRange;
   
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] GameObject object1;
    [SerializeField] GameObject object2;
    [SerializeField] Transform cameraPosition;
     

    private void Awake()

    {
        playerInRange = false;
        npcParent = transform.parent.gameObject;      
    }

    private void Update()
    {
        //check if player in range and dialog is playing
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            //check if player press keycode to start the dialog
            if (Input.GetKeyDown(KeyCode.I))  
            {
                ChangeParent();
                DialogueManager.GetInstance().enterDialogeMode(inkJSON);
                if (GameObject.Find(npcParent.name) != null)
                {    //it exists}
                    Invoke("destroyNpc", 2);
                }
            }           
        }     
    }
    //check if the player in range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        } 
        
    }
    //check if the player out range

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }       
    }

    //destroy the npc parent object
    private void destroyNpc()
    {      
        Destroy(npcParent);      
    }

    //move the picture to another object to display
    void ChangeParent()
    {
        tempTrans = object2.transform.parent;
        object2.transform.parent = object1.transform;
        object2.transform.position = new Vector3(cameraPosition.transform.position.x-0.25f, cameraPosition.transform.position.y+1.25f, transform.position.z);
    }


    
}
