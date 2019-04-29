using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    [SerializeField]
    private int alienHealth = 4;

    private float triggerDistance = 10f;

    [SerializeField]
    private float alienSpeed = 3f;

    private int minDropAmount = 1, maxDropAmount = 4;

    [SerializeField]
    private string[] possibleDrops = null;

    private Animator alienAnimator;

    private void Start()
    {
        alienAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!GameController.instance.isPaused)
        {
            if (GameController.instance.currentPlayer != null)
            {
                float dist = Vector3.Distance(transform.position, GameController.instance.currentPlayer.position);

                if (dist <= triggerDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, GameController.instance.currentPlayer.position, alienSpeed * Time.deltaTime);
                    if (!alienAnimator.GetBool("isWalking"))
                    {
                        alienAnimator.SetBool("isWalking", true);
                    }
                }
                else
                {
                    if (alienAnimator.GetBool("isWalking"))
                    {
                        alienAnimator.SetBool("isWalking", false);
                    }
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

            GameController.instance.currentPlayer.GetComponent<PlayerController>().addAmmo(Random.Range(2, 8));

            //AudioManager.Instance.playSound("Alien Die");
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

                //AudioManager.Instance.playSound("Alien Hurt");
                return;
            }
        }
    }
}
