using System.Collections;
using UnityEngine;

public class SpikeFreeFall : MonoBehaviour
{

    [SerializeField] private Rigidbody2D[] spike;
    [SerializeField] private int fallSpeed = 3;

    // start coroutine if player touch the collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(isGravity());
        }
    }

    //apply gravity to the spikes 
    IEnumerator isGravity()
    {
        for (int i = 0; i < spike.Length; i++)
        {
            spike[i].gravityScale += fallSpeed;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(4);
        Destroy(transform.parent.gameObject);
    }
}
