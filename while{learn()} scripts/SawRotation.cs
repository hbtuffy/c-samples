using UnityEngine;

public class SawRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;


    
    // create a saw rotation animation
    void Update()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime * rotationSpeed);
    }
   
}
