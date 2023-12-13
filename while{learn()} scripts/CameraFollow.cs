using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;

    //Camera limiter for keeping the camera in a limited frame
    void LateUpdate()
    {
        // camere frame limitter for robot 
        if (playerTransform.name == "Robot")
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 2, transform.position.z);
            if (transform.position.x < -1)
            {
                transform.position = new Vector3(-1, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > 271)
            {
                transform.position = new Vector3(271, transform.position.y, transform.position.z);
            }
            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }

        // camere frame limitter for astronaut and prof x 
        if (playerTransform.name == "Astronaut" || playerTransform.name == "Prof X")
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 2, transform.position.z);
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > 84)
            {
                transform.position = new Vector3(84, transform.position.y, transform.position.z);
            }
            if (transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
            else if (transform.position.y > 25)
            {
                transform.position = new Vector3(transform.position.x, 25, transform.position.z);
            }
        }
    }
}
