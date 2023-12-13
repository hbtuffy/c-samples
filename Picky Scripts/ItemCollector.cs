using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherryCount = 0;
    [SerializeField]
    private Text countDisplay;
    // Start is called before the first frame update

    [SerializeField]
    private AudioSource collectAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectable"))
        {
            Destroy(collision.gameObject);
            cherryCount++;
            countDisplay.text = "Fruits: " + cherryCount;
            collectAudio.Play();
        }
    }
}
