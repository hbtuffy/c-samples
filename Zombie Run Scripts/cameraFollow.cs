using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPositon;

    [SerializeField]
    private float minX, maxX;
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
    }

    void LateUpdate()
    {
        cameraCalculator();
    }
    void cameraCalculator()
    {
        if (player == null)
            return;
        tempPositon = transform.position;
        tempPositon.x = player.position.x;
        if (tempPositon.x < minX)
        {
            tempPositon.x = minX;
        }
        if (tempPositon.x > maxX)
        {
            tempPositon.x = maxX;
        }
        transform.position = tempPositon;
    }
}
