using System.Collections;
using UnityEngine;

public class laserTimer : MonoBehaviour
{
    private Animator myAnimation;
    private bool isActive = false;
    [SerializeField] private int timer;
    
    void Awake()
    {
        myAnimation = GetComponent<Animator>();
    }

    void Start()
    {
        //start the coroutine for the laserAnimation()
        StartCoroutine(laserAnimation());
    }

    void Update()
    {

    }
    //set timer for laser animation
    IEnumerator laserAnimation()
    {
        while (isActive == false)
        {

            myAnimation.SetBool("laserActive", true);
            yield return new WaitForSeconds(timer / 3);
            isActive = true;
            myAnimation.SetBool("laserActive", false);
            yield return new WaitForSeconds(timer / 3);
            isActive = false;
        }


    }

}
