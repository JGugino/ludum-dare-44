using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private PlayerMotor pMotor;
    private PlayerInput pInput;

    [SerializeField]
    private GameObject bloodPrefab;

    private int defaultMaxHealth = 5;

    private int playerCurrentHealth = 5, playerMaxHealth = 5;

    private bool isDead = false;

    private Animator pAnimator;

    [SerializeField]
    private SpriteRenderer playerBody = null;

    [SerializeField]
    private Sprite[] playerBodies = new Sprite[2];

    private int currentBloodAmmo = 0, maxBloodAmmo = 100;

    private bool hasDoubleShot = false;

    public bool hasSprint = false;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;

        pMotor = GetComponent<PlayerMotor>();

        pInput = GetComponent<PlayerInput>();

        pAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerCurrentHealth <= 0 || HealthController.instance.spawnedHearts.Count <= 0)
        {
            killPlayer();
        }
    }

    private void killPlayer()
    {
        gameObject.SetActive(false);
        GUIController.instance.toggleDeathScreen(true);
        //AudioManager.Instance.playSound("Player Die");
    }

    public void resetPlayerStats()
    {
        playerCurrentHealth = defaultMaxHealth;

        Debug.Log(playerCurrentHealth);

        HealthController.instance.resetHearts(playerCurrentHealth);
    }

    public void spawnBloodShot(Vector3 _dest)
    {
        if (bloodPrefab != null && _dest != Vector3.zero)
        {
            if (!hasDoubleShot)
            {
                GameObject currentShot = Instantiate(bloodPrefab, transform.position, Quaternion.identity);

                currentShot.GetComponent<BloodController>()._dest = _dest;
            }
            else if(hasDoubleShot)
            {
                GameObject currentShotOne = Instantiate(bloodPrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Quaternion.identity);

                GameObject currentShotTwo = Instantiate(bloodPrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), Quaternion.identity);

                currentShotOne.GetComponent<BloodController>()._dest = new Vector3(_dest.x + 0.5f, _dest.y, _dest.z);

                currentShotTwo.GetComponent<BloodController>()._dest = new Vector3(_dest.x - 0.5f, _dest.y, _dest.z);
            }

            //AudioManager.Instance.playSound("Blood Shoot");
        }
    }

    public void upgradePlayer(string _type)
    {
        switch (_type)
        {
            case "Extra Life":
                giveExtraLife();
                break;

            case "Double Shot":
                hasDoubleShot = true;
                break;

            case "Speed Boost":
                hasSprint = true;
                break;

            case "Steel Heart":
                break;
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

    private void giveExtraLife()
    {
        playerMaxHealth++;
        playerCurrentHealth = playerMaxHealth;
        HealthController.instance.addHeart(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pInput.debugMode)
        {
            if (collision.collider.CompareTag("Alien"))
            {
                if (playerCurrentHealth > 0)
                {
                    HealthController.instance.removeHearts(2);
                    playerMaxHealth -= 2;
                    playerCurrentHealth = playerMaxHealth;

                    //AudioManager.Instance.playSound("Player Hurt");

                    if (playerCurrentHealth <= 0)
                    {
                        killPlayer();
                    }
                }
            }

            if (collision.collider.CompareTag("Alien Two"))
            {
                if (playerCurrentHealth > 0)
                {
                    HealthController.instance.removeHearts(1);
                    playerMaxHealth--;
                    playerCurrentHealth = playerMaxHealth;

                    //AudioManager.Instance.playSound("Player Hurt");

                    if (playerCurrentHealth <= 0)
                    {
                        killPlayer();
                    }
                }
            }
        }

        if (collision.collider.CompareTag("Ladder"))
        {
            GameController.instance.createNewRooms();
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
                giveExtraLife();
                //Debug.Log(playerMaxHealth);
                Destroy(collision.gameObject);
            }

            //AudioManager.Instance.playSound("Item Pickup");
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

    public bool getHasSprint()
    {
        return hasSprint;
    }
}
