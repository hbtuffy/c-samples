using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateSaw();
    }

    private void rotateSaw()
    {
        transform.Rotate(0,0,360*rotationSpeed*Time.deltaTime);
    }
}
