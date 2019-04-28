using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private int alienHealth = 4;

    private float triggerDistance = 5f;

    [SerializeField]
    private float alienSpeed = 3f;

    private int minDropAmount = 1, maxDropAmount = 4;

    private int dropOffset = 5;

    private string[] possibleDrops = { "lung", "lung", "lung", "liver", "liver", "liver", "kidney", "kidney", "heart" };

    void Update()
    {
        if (!GameController.instance.isPaused)
        {
            if (PlayerSpawner.instance.currentPlayer != null)
            {
                float dist = Vector3.Distance(transform.position, PlayerSpawner.instance.currentPlayer.position);

                if (dist <= triggerDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, PlayerSpawner.instance.currentPlayer.position, alienSpeed * Time.deltaTime);
                }
            }
        }

        if (alienHealth <= 0)
        {
            killAlien();
        }
    }

    void killAlien()
    {
        int amount = Random.Range(minDropAmount, maxDropAmount);

        for (int i = 0; i < amount; i++)
        {
            GameController.instance.createItem(possibleDrops[Random.Range(0, possibleDrops.Length)], transform.position);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BloodShot"))
        {
            if (alienHealth > 0)
            {
                Destroy(collision.gameObject);
                alienHealth--;
                return;
            }
        }
    }
}
