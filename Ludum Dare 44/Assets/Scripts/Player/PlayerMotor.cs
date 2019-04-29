using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private PlayerController pController;

    [SerializeField, Header("Player Move Speed:")]
    private float playerWalkSpeed = 3.5f, playerSprintSpeed = 10f;

    private bool isWalking = false;

    private bool isSprinting = false;
    private void Start()
    {
        pController = GetComponent<PlayerController>();
    }

    public void playerMove(float _horDir, float _vertDir)
    {
        //Horizontal Movement
        if (_horDir < 0)
        {
            if (pController.hasSprint)
            {
                transform.position = new Vector3(transform.position.x - playerSprintSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - playerWalkSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }

            pController.startWalkAnimation();
            pController.setPlayerBody("forward");
            isWalking = true;
        }
        else if (_horDir > 0)
        {
            if (pController.hasSprint)
            {
                transform.position = new Vector3(transform.position.x + playerSprintSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + playerWalkSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }

            pController.startWalkAnimation();
            pController.setPlayerBody("forward");
            isWalking = true;
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
            }
        }



        //Vertical Movement
        if (_vertDir < 0)
        {
            if (isSprinting)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - playerSprintSpeed * Time.deltaTime, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - playerWalkSpeed * Time.deltaTime, transform.position.z);
            }
            
            pController.startWalkAnimation();
            pController.setPlayerBody("forward");
            isWalking = true;
        }
        else if (_vertDir > 0)
        {
            if (isSprinting)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + playerSprintSpeed * Time.deltaTime, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + playerWalkSpeed * Time.deltaTime, transform.position.z);
            }

            pController.startWalkAnimation();
            pController.setPlayerBody("backward");
            isWalking = true;
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
            }
        }

        if (!isWalking)
        {
            pController.stopWalkAnimation();
        }

    }

    public bool getIsSprinting()
    {
        return isSprinting;
    }

    public void toggleSprint(bool _on)
    {
        isSprinting = _on;
    }

}
