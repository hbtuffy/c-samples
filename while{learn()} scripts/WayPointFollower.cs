using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;

    public int currentWaypoinIndex = 0;

    private void Update()
    {
        //calculate which waypoint the platform is touching
        if (Vector2.Distance(waypoints[currentWaypoinIndex].transform.position, transform.position) < .1f)
        {

            currentWaypoinIndex = currentWaypoinIndex + 1;
            if (currentWaypoinIndex >= waypoints.Length)
            {
                currentWaypoinIndex = 0;
            }

        }

        //move the platform between the waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoinIndex].transform.position, Time.deltaTime * speed);
    }
}

