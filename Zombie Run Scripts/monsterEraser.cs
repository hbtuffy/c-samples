using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterEraser : MonoBehaviour
{
    private string monsterTag = "monster";
    private string playerTag = "player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(monsterTag) || collision.CompareTag(playerTag))
        {
            Destroy(collision.gameObject);
        }
    }
}
