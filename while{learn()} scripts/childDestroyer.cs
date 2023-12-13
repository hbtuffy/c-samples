using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childDestroyer : MonoBehaviour
{
    
    [SerializeField] GameObject dialogPanel;
    //destroy unwanted child object of the questions
    private void Update()
    {
        if (dialogPanel.activeSelf == true)
        {
            while (transform.childCount > 1)
            {
                for (int i = 0; i < transform.childCount-1; i++)
                {
                    DestroyImmediate(transform.GetChild(i).gameObject);
                }
               
            }
        }
    }
}
