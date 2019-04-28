﻿using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private PlayerController pController;

    [SerializeField, Header("Player Move Speed:")]
    private float playerSpeed = 5f;

    private bool isWalking = false;

    private void Start()
    {
        pController = GetComponent<PlayerController>();
    }

    public void playerMove(float _horDir, float _vertDir)
    {
        //Horizontal Movement
        if (_horDir < 0)
        {
            transform.position = new Vector3(transform.position.x - playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            pController.startWalkAnimation();
            pController.setPlayerBody("forward");
            isWalking = true;
        }
        else if (_horDir > 0)
        {
            transform.position = new Vector3(transform.position.x + playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
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
            transform.position = new Vector3(transform.position.x, transform.position.y - playerSpeed * Time.deltaTime, transform.position.z);
            pController.startWalkAnimation();
            pController.setPlayerBody("forward");
            isWalking = true;
        }
        else if (_vertDir > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + playerSpeed * Time.deltaTime, transform.position.z);
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

}