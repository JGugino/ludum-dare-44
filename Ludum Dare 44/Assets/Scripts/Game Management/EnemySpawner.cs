using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] possibleAliens = new GameObject[3];

    public float spawnDist = 3f;

    private float activeDist = 10.5f;

    private float spawnDelay = 0, maxSpawnDelay = 450;

    private int currentSpawned = 0, maxSpawned = 5;

    private Transform alienParent;

    private void Start()
    {
        maxSpawnDelay = maxSpawnDelay - GameController.instance.getCurrentLevel();

        spawnDelay = maxSpawnDelay;

        alienParent = GameObject.FindGameObjectWithTag("Aliens Parent").transform;

        maxSpawned = maxSpawned * GameController.instance.getCurrentLevel();

        spawnEnemy();
    }

    private void Update()
    {
        if (!GameController.instance.isPaused)
        {
            if (GameController.instance.currentPlayer != null)
            {
                float dist = Vector3.Distance(transform.position, GameController.instance.currentPlayer.position);

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
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void spawnEnemy()
    {
        int rand = Random.Range(0, possibleAliens.Length);

        Instantiate(possibleAliens[rand], new Vector3(transform.position.x + Random.Range(-spawnDist, spawnDist), transform.position.y + Random.Range(-spawnDist, spawnDist), 0), Quaternion.identity, alienParent);
        currentSpawned++;
        return;
    }
}
