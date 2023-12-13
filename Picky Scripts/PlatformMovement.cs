using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] wayPoints;
    [SerializeField]
    private int currentWayPointIndex = 0;

    [SerializeField] 
    private float platformSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moviePlatform();

    }

    void moviePlatform()
    {
        if (Vector2.Distance(wayPoints[currentWayPointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= wayPoints.Length)
            {
                currentWayPointIndex = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position, Time.deltaTime * platformSpeed);
    }
}
