using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController pController;
    private PlayerMotor pMotor;

    private void Awake()
    {
        pMotor = GetComponent<PlayerMotor>();
        pController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!pController.getIsDead())
        {
            float _horDir = Input.GetAxisRaw("Horizontal");
            float _vertDir = Input.GetAxisRaw("Vertical");

            pMotor.playerMove(_horDir, _vertDir);
        }
    }
}
