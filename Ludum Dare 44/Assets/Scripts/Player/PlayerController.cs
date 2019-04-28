using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject bloodPrefab;

    private int playerCurrentHealth = 5, playerMaxHealth = 5;

    private bool isDead = false;

    private Animator pAnimator;

    [SerializeField]
    private SpriteRenderer playerBody = null;

    [SerializeField]
    private Sprite[] playerBodies = new Sprite[2];

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;

        pAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            killPlayer();
        }
    }

    private void killPlayer()
    {
        //Debug.Log("Dead");
    }

    public void spawnBloodShot(Vector3 _dest)
    {
        if (bloodPrefab != null && _dest != Vector3.zero)
        {
            GameObject currentShot = Instantiate(bloodPrefab, transform.position, Quaternion.identity);

            currentShot.GetComponent<BloodController>()._dest = _dest;
        }
    }

    public void setPlayerBody(string _direction)
    {
        if (_direction == "forward")
        {
            playerBody.sprite = playerBodies[0];
        }else if (_direction == "backward")
        {
            playerBody.sprite = playerBodies[1];
        }
    }

    public void startWalkAnimation()
    {
        if (!pAnimator.GetBool("isWalking"))
        {
            pAnimator.SetBool("isWalking", true);
        }
    }

    public void stopWalkAnimation()
    {
        if (pAnimator.GetBool("isWalking"))
        {
            pAnimator.SetBool("isWalking", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Alien"))
        {
            if (playerCurrentHealth > 0 && (playerCurrentHealth - 1) >= 0)
            {
                HealthController.instance.removeHearts(1);
                playerCurrentHealth--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            string itemType = collision.GetComponent<ItemController>().itemType;

            if (itemType != "health")
            {
                GameController.instance.addOrgans(itemType, 1);

                Destroy(collision.gameObject);
            }
            else
            {
                playerMaxHealth++;
                playerCurrentHealth = playerMaxHealth;
                HealthController.instance.addHeart(1);
                Debug.Log(playerMaxHealth);
                Destroy(collision.gameObject);
            }
        }
    }

    public Animator getAnimator()
    {
        return pAnimator;
    }

    public bool getIsDead()
    {
        return isDead;
    }

    public int getPlayerCurrentHealth()
    {
        return playerCurrentHealth;
    }
}
