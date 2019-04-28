using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] possibleAliens = new GameObject[1];

    public float spawnDist = 3f;

    private float activeDist = 10.5f;

    private float spawnDelay = 0, maxSpawnDelay = 600;

    private int currentSpawned = 0, maxSpawned = 5;

    private void Start()
    {
        spawnDelay = maxSpawnDelay;

        spawnEnemy();
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, PlayerSpawner.instance.currentPlayer.position);

        //Debug.Log(dist);

        if (currentSpawned < maxSpawned)
        {
            if (dist <= activeDist)
            {
                if (spawnDelay <= 0)
                {
                    spawnEnemy();
                    spawnDelay = maxSpawnDelay;
                }
                else
                {
                    spawnDelay--;
                    //Debug.Log("delay: " + spawnDelay);
                }
            }
        }
    }

    public void spawnEnemy()
    {
        int rand = Random.Range(0, possibleAliens.Length);

        Instantiate(possibleAliens[rand], new Vector3(transform.position.x + Random.Range(-spawnDist, spawnDist), transform.position.y + Random.Range(-spawnDist, spawnDist), 0), Quaternion.identity);
        currentSpawned++;
        return;
    }
}
