using UnityEngine;

public class rocketTracker : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;

    public int currentWaypoinIndex = 0;

    //rocket animation for main menu
    private void Update()
    {

        if (Vector2.Distance(waypoints[currentWaypoinIndex].transform.position, transform.position) < .1f)
        {

            currentWaypoinIndex = currentWaypoinIndex + 1;
            if (currentWaypoinIndex >= waypoints.Length)
            {
                transform.position = waypoints[0].transform.position;
                currentWaypoinIndex = 0;

            }

        }

        //update the position between the waypoints
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoinIndex].transform.position, Time.deltaTime * speed);
    }
}

