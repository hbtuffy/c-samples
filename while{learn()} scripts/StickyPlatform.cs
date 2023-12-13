using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //setparent to stick with the platform when you touch it.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Astronaut" || collision.gameObject.name == "Robot")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    //setparent null when you do not touch it
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Astronaut" || collision.gameObject.name == "Robot")

        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
