using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsters;

    private GameObject spawnedMonster;

    [SerializeField]    
    private Transform spawnerRightPosition,spawnerLeftPosition;

    private int randomIndex;
    private int randomSide;

    void Start()
    {
        StartCoroutine(spawnMonsters());
    }

    IEnumerator spawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsters.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsters[randomIndex]);
            if (randomIndex == 0)
            {
                spawnedMonster.transform.position = spawnerLeftPosition.position;
                spawnedMonster.GetComponent<monster>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedMonster.transform.position = spawnerRightPosition.position;
                spawnedMonster.GetComponent<monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
    void Update()
    {
        
    }
}
