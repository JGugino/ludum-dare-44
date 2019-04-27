using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private bool isDead = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool getIsDead()
    {
        return isDead;
    }
}
